using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class NegativeLight : MonoBehaviour
{
    public Light2D light;
    public float intensity;
    void Start()
    {
        light.intensity = intensity;
    }
}
