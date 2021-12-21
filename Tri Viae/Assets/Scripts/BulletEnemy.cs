using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float Atk;
    private void Awake() {
        SoundHandler.SoundHandlerPlay("Shoot", true);
        GameObject.Destroy(this.gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerCombat player = other.GetComponent<PlayerCombat>();
        player.TakeDamage(Atk);
        GameObject.Destroy(this.gameObject);
    }
}
