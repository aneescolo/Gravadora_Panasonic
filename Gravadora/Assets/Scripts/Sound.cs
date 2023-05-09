using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound : MonoBehaviour
{
    public string songName;

    public AudioClip audioClip;

    // Apareix com slider en el inspector
    [Range(0f, 1f)]
    public float volume;

    public bool playOnAwake;

    public bool loop;

    public bool mute;
    
    public bool active;

    public AudioSource audioSource;

    public Sprite highlight;
    
    public void Activate_Deactivate_MODE_MUTE()
    { 
        mute = !mute; 
        audioSource.mute = mute; 
    }    
    
    public void Activate_Deactivate_MODE_LOOP()
    { 
        loop = !loop; 
        audioSource.loop = loop; 
    }  
}
