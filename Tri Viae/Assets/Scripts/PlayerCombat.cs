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
        MaxHP = 100;
        Hp = 100;
        Atk = 5;
        Def = 1;
    }
    public void TakeDamage(float Damage){
        Hp -= (int)Damage - Def;
        if(Hp <= 0){
            GameOver();    
        }
        UpdateUI();
    }
    private void UpdateUI(){
        slider.value = Hp/MaxHP;
        HealthText.SetText(Hp + "/" + MaxHP);
    }
    private void GameOver(){
        SceneManager.LoadScene("End Screen");
    }
    
}
