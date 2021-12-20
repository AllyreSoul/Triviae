using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class SlimeAI : MonoBehaviour, Enemy
{
    private enum State {
        Idle,
        Move,
        Shoot
    }
    public Transform player, self, point;
    public GameObject pointObject;
    public Seeker seeker;
    private State state;
    private float Atk = 5f;
    public float maxHP = 100, hp = 100;
    public EnemyShoot pointShoot;
    public Slider slider;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        state = State.Idle;
        pointShoot.Atk = Atk;
        StartCoroutine(Loop());
    }

    IEnumerator Loop(){
        for(;;){
            switch(state){
                case State.Idle:
                    yield return new WaitForSeconds(Random.Range(1, 3));
                    state = State.Shoot;
                    break;
                case State.Move:
                    var p = Instantiate(pointObject, new Vector3(player.position.x + Random.Range(-2.5f, 2.5f), player.position.y + Random.Range(-2.5f, 2.5f), self.position.z), Quaternion.identity);
                    seeker.StartPath(self.position, p.transform.position);
                    GameObject.Destroy(p);
                    state = State.Idle;
                    break;
                case State.Shoot:
                    findAngle();
                    Shoot();
                    yield return new WaitForSeconds(0.2f);
                    findAngle();
                    Shoot();
                    state = State.Move;
                    yield return new WaitForSeconds(Random.Range(1, 3));
                    break;
            }
            
        }
    }
    public void TakeDamage(float dmg){
        hp = hp - dmg;
        if(hp <= 0){
            Data.kills++;
            GameObject.Destroy(this.gameObject);
        }
        UpdateUI();
    }

    private void findAngle(){
        Vector2 SelfToMouse = (Vector2)player.position - (Vector2)point.position;
        float angle = Mathf.Atan2(SelfToMouse.y, SelfToMouse.x) * Mathf.Rad2Deg - 90f;
        point.rotation = Quaternion.Euler(0,0,angle);
    }

    private void Shoot(){
        pointShoot.Shoot();
    }
    private void UpdateUI(){
        slider.value = hp/maxHP;
    }
}
