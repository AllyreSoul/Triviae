using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AnswerObject : MonoBehaviour
{
    public Sprite correct, incorrect;
    public Image image;
    public TMP_Text text;
    public void updateObject(bool i, string q){
        if(i){
            image.sprite = correct;
        } else image.sprite = incorrect;
        text.SetText(q);
    }
}
