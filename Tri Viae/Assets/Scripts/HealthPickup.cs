using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject healPickup, healAnchor;
    private void Start() {
        healAnchor = GameObject.Find("HealAnchor");
    }
        private void OnTriggerStay2D(Collider2D other) {
            PlayerCombat player = other.gameObject.GetComponent<PlayerCombat>();
            GameObject n = Instantiate(healPickup, healAnchor.transform);
            HealPickup nInternal = n.GetComponent<HealPickup>();
            float prevHP = player.Hp;
            player.Hp += 20;
            if(player.Hp > player.MaxHP){
                player.Hp = player.MaxHP;
            }
            player.UpdateUI();
            nInternal.stringText = "+ " + (player.Hp - prevHP).ToString();
            GameObject.Destroy(this.gameObject, 1f);
            GameObject.Destroy(n, 1f);
            this.gameObject.SetActive(false);
    }
}
