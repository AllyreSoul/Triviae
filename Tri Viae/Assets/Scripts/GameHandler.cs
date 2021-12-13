using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public Transform spawn;
    public Transform player;
    public Transform Anchor;
    public GameObject fourPickArray;
    public question assignedQuestion;
    public question[] questions;
    public int length;
    public int trueLength;
    public QuestionArray qArray;
    public GameObject gate;
    public GameObject indicatorObject;
    public randomizedList[] randomizedLists;
    public Indicator indicator;
    public GameObject questionArray;
    // Start is called before the first frame update
    void Start()
    {
        length = int.Parse(Resources.Load<TextAsset>("Questions/index").ToString());
        initialize();
        readNextQuestions();
    }

    void initialize(){
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
            Debug.Log(i + 1);
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
        }
    }
    question readJSON(string fileName){
        var file = Resources.Load<TextAsset>($"Questions/{fileName}");
        Debug.Log(fileName);
        question question = JsonUtility.FromJson<question>(file.text);
        return question;
    }

    public void answered(int answer){
        if(answer == assignedQuestion.correct)
        {

        } else 
        {

        }
        for(int i = 0; i <= 3; i++){
            qArray.buttonSteps[i].buttonEnabled = false;
            qArray.buttonSteps[i].updateColor(assignedQuestion.correct);
        }
        gate.gameObject.SetActive(false);
        readNextQuestions();
    }

    public void readNextQuestions(){
        var indication = Instantiate(indicatorObject, Anchor);
        indication.transform.parent = Anchor;
        indicator = indication.GetComponent<Indicator>();
        questions = new question[3];
        if(trueLength <= randomizedLists[1].internalIndex){
            GameObject.Destroy(indicator.gameObject);
            GameObject.Destroy(questionArray);
            player.position = spawn.position;
        } else {
            for(int i = 0; i <= 2; i++){
                int path = randomizedLists[i].id[randomizedLists[i].internalIndex];
                questions[i] = readJSON(path.ToString());
                Debug.Log(questions[i].theme);
                randomizedLists[i].internalIndex++;
                indicator.onAnswered(questions[i].theme, i);
            } 
        }
        Debug.Log("True Length: " + trueLength + "Current Index: " + randomizedLists[1].internalIndex + "\nCurrent IDs:" + randomizedLists[0].id?[randomizedLists[0].internalIndex] + " " + randomizedLists[1].id?[randomizedLists[1].internalIndex]+" " + randomizedLists[2].id?[randomizedLists[2].internalIndex]);
    }
}
