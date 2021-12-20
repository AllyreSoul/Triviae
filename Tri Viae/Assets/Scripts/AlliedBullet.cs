using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliedBullet : MonoBehaviour
{
    public float Atk;
    private void Awake() {
        GameObject.Destroy(this.gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Enemy enemyObj = other.GetComponent<Enemy>();
        enemyObj.TakeDamage(Atk);
        GameObject.Destroy(this.gameObject);
    }
}
