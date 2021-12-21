using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerCombat : MonoBehaviour
{
    public float MaxHP, Hp, Atk, Def;
    public Slider slider;
    public TMP_Text HealthText;
    // Start is called before the first frame update
    void Start()
    {
        Data.playerData = new PlayerData();
        MaxHP = 100;
        Hp = 100;
        Atk = 5;
        Def = 1;
        SyncData();
    }
    public void TakeDamage(float Damage){
        int trueDamage = (int)(Damage* (1 - (Def+10f)/100));
        if(trueDamage <= 0){
            trueDamage = 1;
        }
        Hp -= trueDamage;
        if(Hp < 0){
            Hp = 0;
        }
        if(Hp == 0){
            GameOver();    
        }
        UpdateUI();
        SyncData();
    }
    public void UpdateUI(){
        slider.value = Hp/MaxHP;
        HealthText.SetText(Hp + "/" + MaxHP);
    }
    private void GameOver(){
        SyncData();
        SceneManager.LoadScene("End Screen");
    }
    public void SyncData(){
        Data.playerData.Atk = Atk;
        Data.playerData.Def = Def;
        Data.playerData.Hp = Hp;
        Data.playerData.MaxHP = MaxHP;
    }
    
}
