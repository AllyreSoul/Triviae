using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public Transform spawn, player, Anchor;
    public GameObject fourPickArray, twoPickArray, gate, indicatorObject, questionArray, buffObject;
    public QuestionArray qArray;
    public question assignedQuestion;
    public question[] questions;
    public int length, trueLength;
    public randomizedList[] randomizedLists;
    public Indicator indicator;
    public RealScore realScore;
    public Transform[] EnemyAnchors;
    public int[] DiceRoll;
    public GameObject[] Enemies;
    public GameHandlerDifficulty gameHandlerDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        length = int.Parse(Resources.Load<TextAsset>("Questions/index").ToString());
        initialize();
    }

    void initialize(){
        ReInitializeData();
        DiceRoll= new int[7];
        for(int i = 0; i <= 6; i++){
            DiceRoll[i] = i;
        }
        int index = 0;
        int[] list = new int[length];
        randomizedLists = new randomizedList[3];
        randomizedLists[0].listOrder = 1;
        randomizedLists[1].listOrder = 2;
        randomizedLists[2].listOrder = 3;
        randomizedLists[0].id = new List<int>();
        randomizedLists[1].id = new List<int>();
        randomizedLists[2].id = new List<int>();
        randomizedLists[0].internalIndex = 0;
        randomizedLists[1].internalIndex = 0;
        randomizedLists[2].internalIndex = 0;
        for(int i = 0; i <= length - 1; i++){
            list[i] = i + 1;
        }
        var random = new System.Random();
        random.Shuffle<int>(list);
        foreach(int i in list){
            randomizedLists[index].id.Add(i);
            if(index < 2){
                index++;
            } else index = 0;
        }
        if(randomizedLists[0].id.Count < randomizedLists[1].id.Count){
            trueLength = randomizedLists[0].id.Count;
        } else trueLength = randomizedLists[1].id.Count;
        if(trueLength > randomizedLists[2].id.Count){
            trueLength = randomizedLists[2].id.Count;
        }
        foreach(randomizedList r in randomizedLists){
            if(r.id.Count > trueLength){
                r.id.RemoveAt(trueLength - 1);
            }
        }
        Data.correct = new bool[trueLength];
        Data.questions = new List<question>();
        Data.length = trueLength;
        realScore.length = trueLength;
        realScore.UpdateProgress(0);
        createIndicator();
        readNextQuestions();
        SoundHandler.SoundHandlerPlay("Journey", false, true);
    }
    public void Reload(int id){
        GameObject.Destroy(indicator.gameObject);
        GameObject.Destroy(questionArray);
        player.position = spawn.position;
        SetQuestions(id);
    }
    void SetQuestions(int id){
        gate.gameObject.SetActive(true);
        assignedQuestion = questions[id];
        var random = new System.Random();
        random.Shuffle<answers>(assignedQuestion.answers);
        if(assignedQuestion.fourPick){
            questionArray = Instantiate(fourPickArray, Anchor);
            questionArray.transform.parent = Anchor;
            qArray = questionArray.GetComponent<QuestionArray>();
            qArray.questionName = assignedQuestion.title;
            qArray._onQuestionsAssigned();
            for(int i = 0; i <= 3; i++){
                qArray.buttonSteps[i].assignedAnswer = assignedQuestion.answers[i];
                qArray.buttonSteps[i]._onQuestionsAssigned();
            }
        } else{
            questionArray = Instantiate(twoPickArray, Anchor);
            questionArray.transform.parent = Anchor;
            qArray = questionArray.GetComponent<QuestionArray>();
            qArray.questionName = assignedQuestion.title;
            qArray._onQuestionsAssigned();
            for(int i = 0; i <= 1; i++){
                qArray.buttonSteps[i].assignedAnswer = assignedQuestion.answers[i];
                qArray.buttonSteps[i]._onQuestionsAssigned();
            }
        }
        Data.questions.Add(assignedQuestion);
    }
    question readJSON(string fileName){
        var file = Resources.Load<TextAsset>($"Questions/{fileName}");
        question question = JsonUtility.FromJson<question>(file.text);
        return question;
    }

    public void answered(int answer){
        if(answer == assignedQuestion.correct)
        {
            Data.correct[randomizedLists[0].internalIndex] = true;
            Data.score++;
            SoundHandler.SoundHandlerPlay("Correct");
            CorrectAnswer();
            InitializeNextQuestions();
        } else 
        {
            Data.correct[randomizedLists[0].internalIndex] = false;
            SoundHandler.SoundHandlerPlay("Incorrect");
            gameHandlerDifficulty.difficulty += 0.125f;
            List<enemyData> assignedEnemies = new List<enemyData>();
            assignedEnemies = gameHandlerDifficulty.generateEnemyData();
            foreach(enemyData i in assignedEnemies){
                InitializeEnemies(i);
            }
            StartCoroutine(CheckEnemies());
        }
    }
    public void InitializeNextQuestions(){
        StopAllCoroutines();
        for(int i = 0; i <= qArray.buttonSteps.Length - 1; i++){
            qArray.buttonSteps[i].buttonEnabled = false;
            qArray.buttonSteps[i].updateColor(assignedQuestion.correct);
        }
        gate.gameObject.SetActive(false);
        createIndicator();
        if(trueLength <= randomizedLists[1].internalIndex + 1){
            GameObject.Destroy(indicator.gameObject);
            GameObject.Destroy(questionArray);
            player.position = spawn.position;
            Data.completed = true;
            SceneManager.LoadScene("End Screen");
        } else {
            randomizedLists[0].internalIndex++;
            randomizedLists[1].internalIndex++;
            randomizedLists[2].internalIndex++;
            realScore.UpdateProgress(randomizedLists[0].internalIndex);
            readNextQuestions();
        }
    }
    public void readNextQuestions(){
        questions = new question[3];
            for(int i = 0; i <= 2; i++){
                int path = randomizedLists[i].id[randomizedLists[i].internalIndex];
                questions[i] = readJSON(path.ToString());
                indicator.onAnswered(questions[i].theme, i);
            } 
        if(randomizedLists[0].internalIndex <= 15){
        }
        
    }

    void createIndicator(){
        var indication = Instantiate(indicatorObject, Anchor);
        indication.transform.parent = Anchor;
        indicator = indication.GetComponent<Indicator>();
    }
    private void InitializeEnemies(enemyData data){
        GameObject.Destroy(questionArray);
        Index.Shuffle<int>(new System.Random(), DiceRoll);
        for(int i = 0; i <= data.amount - 1; i++){
            Instantiate(Enemies[data.id], new Vector3(EnemyAnchors[DiceRoll[i]].position.x, EnemyAnchors[DiceRoll[i]].position.y, -0.2f), Quaternion.identity);
        }
    }

    IEnumerator CheckEnemies(){
        for(;;){
            if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0){
                InitializeNextQuestions();
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private void CorrectAnswer(){
        float Rand = UnityEngine.Random.Range(0, 2f);
        if(Rand > 0.65)
        {
            Buff assignedBuff = Index.GenerateBuff();
            GenerateBuff(assignedBuff);
            }
    }
    public void GenerateBuff(Buff c){
        GameObject BuffObj = Instantiate(buffObject, player);
        BuffObject b = BuffObj.GetComponent<BuffObject>();
        b.buff = c;
    }
    public void ReInitializeData(){
        Data.completed = false;
        Data.score = 0;
        Data.kills = 0;
    }

}
