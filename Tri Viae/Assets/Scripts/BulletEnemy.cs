using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float Atk;
    private void Awake() {
        GameObject.Destroy(this.gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerCombat player = other.GetComponent<PlayerCombat>();
        player.TakeDamage(Atk);
        GameObject.Destroy(this.gameObject);
    }
}
