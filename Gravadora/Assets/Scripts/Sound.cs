using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private bool changeSprite;

    public Sprite highlight;
    
    public IEnumerator currentCoroutine;

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
    
    public void ChangeSprite_Timer()
    {
        if (!gameObject.GetComponent<Sound>().mute)
        {
            changeSprite = true;
            currentCoroutine = Coroutine_ChangeSprite();
            StartCoroutine(currentCoroutine);
        }
    }
    
    public void ChangeSprite_List()
    {
        changeSprite = true;
        currentCoroutine = Coroutine_ChangeSprite();
        StartCoroutine(currentCoroutine);
    }
    
    IEnumerator Coroutine_ChangeSprite()
    {
        float timer = 0;
        Sprite imageBtn = gameObject.GetComponent<Image>().sprite;
        gameObject.GetComponent<Image>().sprite = highlight;

        while (changeSprite)
        {
            timer += Time.deltaTime;
            
            if (timer >= 0.6f)
            {
                gameObject.GetComponent<Image>().sprite = imageBtn;
                changeSprite = false;
            }
            
            yield return null;
        }
    }
}
