using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenHandler : MonoBehaviour
{
    public GameObject AnswerObject;
    public GameObject AnswerSheet;
    public GameObject Canvas;
    public int y, index, size;
    void Start()
    {
        size = 0;
        index = 0;
        y = -50;
        foreach(question i in Data.questions){
            var answerObjectObj = Instantiate(AnswerObject, new Vector2(0, y), Quaternion.identity);
            answerObjectObj.transform.localScale = new Vector3(1, 1, 1);
            answerObjectObj.transform.SetParent(AnswerSheet.transform, false);
            AnswerObject ans = answerObjectObj.GetComponent<AnswerObject>(); 
            Debug.Log(i);
            y -= 125;
            Debug.Log(i.title);
            Debug.Log(Data.correct[index]);
            ans.updateObject(Data.correct[index], i.title);
            index++;
            size += 125;
        }
        AnswerSheet.GetComponent<RectTransform>().sizeDelta = new Vector2(AnswerSheet.GetComponent<RectTransform>().sizeDelta.x, size);
    }
}
