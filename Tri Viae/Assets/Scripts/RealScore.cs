using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealScore : MonoBehaviour
{
    public Text text;
    public int length;
    public void UpdateProgress(int i){
        text.text = "Progress: " + i + "/" + length;
    }
}
