using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuffLocal : MonoBehaviour
{
    public Image icon;
    public Text text;   
    public Sel sel;
    public Sprite Atk, Def, HP;
    public string stringText;
    void Start()
    {
        
        switch(sel){
            case Sel.Atk:
                icon.sprite = Atk;
                break;
            case Sel.Def:
                icon.sprite = Def;
                break;
            case Sel.HP:
                icon.sprite = HP;
                break;
        }
        text.text = stringText;
    }

}
