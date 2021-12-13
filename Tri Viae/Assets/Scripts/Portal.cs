using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    GameHandler GameHandler;
    public int id;
    void Start()
    {
        GameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameHandler.Reload(id);
    }
}
