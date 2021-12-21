using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTabScript : MonoBehaviour
{
    public Text HP,Atk,Def,Kills;
    void Start()
    {
        HP.text = "Health: " + Data.playerData.Hp + "/" + Data.playerData.MaxHP;
        Atk.text = "Attack: " + Data.playerData.Atk;
        Def.text = "Defense: " + Data.playerData.Def;
        Kills.text = "Kills: " + Data.kills;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
