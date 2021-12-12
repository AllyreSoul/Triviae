using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWriterQArray : MonoBehaviour
{
    public TextMesh textMesh;
    public void updateText(string text){
        textMesh.text = text;
    }
    public void updateColour(Color32 color){
        textMesh.color = color;
    }
}
