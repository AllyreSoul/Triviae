using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStep : MonoBehaviour
{   
    [SerializeField] private Sprite buttonOn;
    [SerializeField] private Sprite buttonOff;
    public GameHandler gameHandler;
    public SpriteRenderer localrenderer;
    public answers assignedAnswer;
    public TextWriterQArray textWriterQArray;
    public bool buttonEnabled = true;
    private void Start() {
        buttonEnabled = true;
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(buttonEnabled){
        localrenderer.sprite = buttonOff;
        gameHandler.answered(assignedAnswer.id);
        }
    }

    public void _onQuestionsAssigned(){
        textWriterQArray.updateText(assignedAnswer.text);
    }

    public void updateColor(int id){
        if(id == assignedAnswer.id){
            textWriterQArray.updateColour(new Color32(37, 65, 23, 255));
        }else
        textWriterQArray.updateColour(new Color32(153, 2, 9, 255));
        
    }
}
