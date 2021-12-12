using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log("script loaded!"); 
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("trigger");
    }
}
