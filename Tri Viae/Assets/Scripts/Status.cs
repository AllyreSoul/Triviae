using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        if(Data.completed){
            text.text = "Status: Completed.";
        } else text.text = "Status: Not Completed.";
    }

}
