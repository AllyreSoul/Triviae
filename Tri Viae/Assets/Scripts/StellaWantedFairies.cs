using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StellaWantedFairies : MonoBehaviour
{
    public GameObject[] FairyPositions;
    public GameObject Fairy;
    public RGBVal[] RGBVal;
    public float time;
    public float mod;
    private float Delay;
    private void Start() {
        Delay = time/(0.8f/mod);
        StartCoroutine("GenerateFairy");
    }
    IEnumerator GenerateFairy(){
        for(;;){
            for(int i = 0; i < 2; i++)
            {
                Transform pos = FairyPositions[Random.Range(0, FairyPositions.Length)].transform;
                var fae = Instantiate(Fairy, new Vector2(pos.position.x + Random.Range(1, 3), pos.transform.position.y + Random.Range(1, 3)), Quaternion.identity, pos);
                FairyInternal faeInternal = fae.gameObject.GetComponent<FairyInternal>();
                faeInternal.Delay = Delay;
                faeInternal.rgb = RGBVal[Random.Range(0, RGBVal.Length)];
                faeInternal.mod = mod;
                }
        yield return new WaitForSeconds(Random.Range(1, 5));    
        }
        
    }
}
[System.Serializable]
public struct RGBVal{
    public int R, G, B;
}