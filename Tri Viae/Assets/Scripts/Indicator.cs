using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public TextWriterQArray[] textWriterQArrays = new TextWriterQArray[3];
    public void onAnswered(string text, int id){
        textWriterQArrays[id].updateText(text);
    }
}
