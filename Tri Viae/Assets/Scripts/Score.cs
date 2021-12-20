    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    void Start()
    {
        text.text = "Score: " + Data.score + "/" + Data.length;
    }
}
