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
        Delay = time/(0.4f/mod);
        StartCoroutine("GenerateFairy");
        Debug.Log(RGBVal.Length);
    }
    IEnumerator GenerateFairy(){
        for(;;){
            var fae = Instantiate(Fairy, FairyPositions[Random.Range(0, FairyPositions.Length)].transform);
            FairyInternal faeInternal = fae.gameObject.GetComponent<FairyInternal>();
            faeInternal.Delay = Delay;
            faeInternal.rgb = RGBVal[Random.Range(0, RGBVal.Length)];
            faeInternal.mod = mod;
            Debug.Log("done");
        yield return new WaitForSeconds(Random.Range(1, 5));    
        }
        
    }
}
[System.Serializable]
public struct RGBVal{
    public int R, G, B;
}