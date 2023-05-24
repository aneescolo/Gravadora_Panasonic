using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    // Singleton
    public static Audio_Manager instance;

    [Tooltip("Array de Btns amb l'escrip de Sound")]
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

    public void PlaySong(string songName)
    {
        // Busquem el que tingui el mateix nom que hem passat
        foreach (Sound currentSound in soundsList)
        {
            if (currentSound.songName == songName)
            {
                currentSound.audioSource.Play();
                break;
            }
        }
    }   
    
    public void StopSong(string songName)
    {
        // Busquem el que tingui el mateix nom que hem passat
        foreach (Sound currentSound in soundsList)
        {
            if (currentSound.songName == songName)
            {
                currentSound.audioSource.Stop();
                break;
            }
        }
    }
    
    public void PlayAudio(Sound sound)
    {
        // Busquem el que tingui el mateix nom que hem passat
        foreach (Sound currentSound in soundsList)
        {
            if (currentSound.songName == sound.songName)
            {
                currentSound.audioSource.Play();
                break;
            }
        }
    }
}
