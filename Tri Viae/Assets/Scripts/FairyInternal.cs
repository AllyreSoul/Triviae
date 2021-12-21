using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class FairyInternal : MonoBehaviour
{
    public float mod, Delay;
    public RGBVal rgb;
    Light2D light;
    public FairyLerp fairyLerp;
    bool executed = false;
    // Start is called before the first frame update
    void Start()
    {
        light = this.gameObject.GetComponent<Light2D>();
        StartCoroutine(AnimateFairy());
    }
    private void Update() {
        if(executed){
            if(light.intensity < 0){
                Suicide();
            } 
        }
    }
    IEnumerator AnimateFairy(){
        
        light.color = new Color32((byte)rgb.R, (byte)rgb.G, (byte)rgb.B, 255);
        for(float i = 0; i <= 0.80f; i += mod ){
            light.intensity = i;
            yield return new WaitForSeconds(Delay);
        }
        if(light.intensity >= 0.75f){
            yield return StartCoroutine(FadeFairy(light));
        }
        
    }
    IEnumerator FadeFairy(Light2D light){
        StopCoroutine("AnimateFairy");
        for(float i = 0.75f; i >= -0.5f; i -= mod){
            light.intensity = i;
            yield return new WaitForSeconds(Delay);
            executed = true;
        }
        if(light.intensity <= 0){
            Suicide();
            yield return null;
        }
        
    }

    void Suicide(){
        fairyLerp.Suicide();
        GameObject.Destroy(this.gameObject);
    }
}
