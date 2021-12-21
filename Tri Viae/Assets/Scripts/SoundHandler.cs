using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundHandler : MonoBehaviour
{
    private static SoundHandler instance;
    public Sound[] Sounds;
    private void Awake() {
        instance = this;
        foreach(Sound s in Sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip; 
        }
    }
    public void PlaySound(string name, bool ignorePlay = false, bool loop = false){
        Sound s = Array.Find(Sounds, sound => sound.name == name);
        if(s.source.isPlaying == false || ignorePlay){
            s.source.Play();
            s.source.loop = loop;
        }
    }

    public static void SoundHandlerPlay(string name, bool ignorePlay = false, bool loop = false){
        instance.PlaySound(name, ignorePlay, loop);
    }
}
