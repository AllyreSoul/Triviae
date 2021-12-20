using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public PlayerCombat host;
    public Transform self;
    public GameObject bullet;
    public float bulletForce = 3f;
    public Camera cam;
    private bool CanShoot = true;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Fire();
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate() {
        Vector2 SelfToMouse = mousePos - (Vector2)self.position;
        float angle = Mathf.Atan2(SelfToMouse.y, SelfToMouse.x) * Mathf.Rad2Deg - 90f;
        self.rotation = Quaternion.Euler(0,0,angle);
    }

    void Fire(){
        if(CanShoot)
        {
            StopCoroutine(Cooldown());
            GameObject pew = Instantiate(bullet, self.position, self.rotation);
            Rigidbody2D rb = pew.GetComponent<Rigidbody2D>();
            rb.AddForce(self.up * bulletForce, ForceMode2D.Impulse);
            pew.GetComponent<AlliedBullet>().Atk = host.Atk;
            StartCoroutine(Cooldown());
            }
    }
    IEnumerator Cooldown(){
        CanShoot = false;
        yield return new WaitForSeconds(0.3f);
        CanShoot = true;
    }
}
