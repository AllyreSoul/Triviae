using System.Collections;
using UnityEngine;

public class FairyLerp : MonoBehaviour 
{
    public GameObject point;
    public Transform self, end, origin;
    public float time;
    [SerializeField] private float startTime;
    [SerializeField] private float journeyLength;
    private void Start(){
        startTime = Time.time;
        end = Instantiate(point, new Vector2(self.position.x + Random.Range(-1, 1), self.position.y + Random.Range(-1 , 1)), Quaternion.identity);
        journeyLength = Vector3.Distance(self.position, end.position);
        speed = journeyLength/time;
    }
    IEnumerator Lerp1(){
        for(;;){
            float Distance = (Time.time - startTime) * speed;
            float Fraction = Distance/journeyLength;
            if(Fraction >= 1){
                break;
            }
            self.position = Vector3.Lerp(self.position, end.position, Fraction);
            yield return new WaitForSeconds(0.05f);
        }
        
    }

    IEnumerator Lerp2(){
        journeyLength = Vector3.Distance(self.position, origin.position);
        for(;;){
            float Distance = (Time.time - startTime) * speed;
            float Fraction = Distance/journeyLength;
            if(Fraction >= 1){
                break;
            }
            self.position = Vector3.Lerp(self.position, origin.position, Fraction);
            yield return new WaitForSeconds(0.05f);
        }
    }
}