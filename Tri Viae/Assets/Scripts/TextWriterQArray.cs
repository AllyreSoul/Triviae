using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriterQArray : MonoBehaviour
{
    public TMP_Text textMesh;
    public void updateText(string text){
        textMesh.SetText(text);
    }
    public void updateColour(Color32 color){
        textMesh.color = color;
    }
}
