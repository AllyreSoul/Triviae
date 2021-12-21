using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealPickup : MonoBehaviour
{
    public Text text;   
    public string stringText;
    void Start()
    {
        text.text = stringText;
    }

}
