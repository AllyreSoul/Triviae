using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform point;
    public GameObject bullet;
    public float bulletForce = 15f;
    public float Atk;
    public void Shoot(){
        GameObject pew = Instantiate(bullet, point.position, point.rotation);
        Rigidbody2D rb = pew.GetComponent<Rigidbody2D>();
        rb.AddForce(point.up * bulletForce, ForceMode2D.Impulse);
        pew.GetComponent<BulletEnemy>().Atk = Atk;
    }
}
