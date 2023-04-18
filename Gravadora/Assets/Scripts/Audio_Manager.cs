using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    // Singleton
    public static Audio_Manager instance;

    // Col.lecció d'elements sound (script)
    public Sound[] soundsList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        // Omplim l'informació en els audioSource a partir del array de Sound
        foreach (Sound currentSound in soundsList)
        {
            currentSound.audioSource = currentSound.gameObject.AddComponent<AudioSource>();
            currentSound.audioSource.clip = currentSound.audioClip;
            currentSound.audioSource.volume = currentSound.volume;
            currentSound.audioSource.playOnAwake = currentSound.playOnAwake;
            currentSound.audioSource.loop = currentSound.loop;
            currentSound.audioSource.mute = currentSound.mute;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
