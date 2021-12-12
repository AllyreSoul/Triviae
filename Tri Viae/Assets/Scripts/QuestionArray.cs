using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionArray : MonoBehaviour
{
    public ButtonStep[] buttonSteps = new ButtonStep[4];
    public TextWriterQArray textWriterQArray;
    public string questionName;
    // Start is called before the first frame update
    public void _onQuestionsAssigned(){
        textWriterQArray.updateText(questionName);
    }
}
