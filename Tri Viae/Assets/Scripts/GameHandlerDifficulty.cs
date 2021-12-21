using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandlerDifficulty : MonoBehaviour
{   
    public float difficulty = 1f;
    public GameHandler gameHandler;
    public List<enemyData> local;
    public Text text;
    public List<enemyData> generateEnemyData(){
        Debug.Log("generating data...");
        List<enemyData> end = new List<enemyData>();
        int trueDifficulty = (int)Math.Round(difficulty);
        if(trueDifficulty > 5){
            trueDifficulty = 5;
        }
        Debug.Log(trueDifficulty);
        switch(trueDifficulty){
            case 1:
                local = new List<enemyData>();
                local.Add(new enemyData());
                local[0].id = 0;
                local[0].amount = UnityEngine.Random.Range(1, 4);
                end.Add(local[0]);
                break;
            case 2:
                local = new List<enemyData>();
                local.Add(new enemyData());
                local.Add(new enemyData());
                local[0].id = 0;
                local[0].amount = UnityEngine.Random.Range(1, 3);
                local[1].id = 1;
                local[1].amount = 1;
                foreach(enemyData i in local){
                    end.Add(i);
                }
                break;
            case 3:
                local = new List<enemyData>();
                local.Add(new enemyData());
                local.Add(new enemyData());
                local.Add(new enemyData());
                local[0].id = 0;
                local[0].amount = UnityEngine.Random.Range(1, 4);
                local[1].id = 1;
                local[1].amount = 1;
                local[2].id = 2;
                local[2].amount = 1;
                foreach(enemyData i in local){
                    end.Add(i);
                }
                break;
            case 4:
                local = new List<enemyData>();
                local.Add(new enemyData());
                local.Add(new enemyData());
                local.Add(new enemyData());
                local[0].id = 0;
                local[0].amount = UnityEngine.Random.Range(1, 3);
                local[1].id = 1;
                local[1].amount = UnityEngine.Random.Range(1, 3);
                local[2].id = 2;
                local[2].amount = 1;
                foreach(enemyData i in local){
                    end.Add(i);
                }
                break;
            case 5:
                local = new List<enemyData>();
                local.Add(new enemyData());
                local.Add(new enemyData());
                local[0].id = 1;
                local[0].amount = UnityEngine.Random.Range(1, 4);
                local[1].id = 2;
                local[1].amount = UnityEngine.Random.Range(1, 3);
                foreach(enemyData i in local){
                    end.Add(i);
                }
                break;
        }
        text.text = "Difficulty: " + trueDifficulty.ToString();
        return end;
    }
}
