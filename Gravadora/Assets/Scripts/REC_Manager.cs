using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REC_Manager : MonoBehaviour
{
    [Header("----- Variables -----")]
    public bool isREC_Active;
    public bool isPLAY_Active;
    public bool isLOOP_Active;
    public bool isPAUSE_Active;

    [Tooltip("Variable float que respresenta el contador (temps) desde que cliquem un btn fins que cliquem el seguent")]
    public float counter;

    // Llistes per a guardar l'informació quan grabem
    public List<float> times_list;
    public List<string> soundNames_list;

    public IEnumerator currentCoroutine;

    public void Activate_Deactivate_MODE_REC()
    {
        // Estata que el nou valor de la variable sigui la negació de si mateixa (la bool només te dues variables)
        isREC_Active = !isREC_Active;

        if (isREC_Active)
        {
            // Reset counter
            counter = 0;

            // Resetear les llistes
            times_list = new List<float>();
            soundNames_list = new List<string>();
            
            // Iniciem la coroutine
            currentCoroutine = Coroutine_REC_Activated();
            StartCoroutine(currentCoroutine);
            Check_Sound_MODE_LOOP();
        }
        else
        {
            StopCoroutine(currentCoroutine);
        }
    }

    IEnumerator Coroutine_REC_Activated()
    {
        // Mentres el REC sigui true realitzarem la lògica
        while (isREC_Active)
        {
            counter += Time.deltaTime;
            yield return null;
        }
    }
    
    private void Check_Sound_MODE_LOOP()
    {
        foreach (Sound score in Audio_Manager.instance.soundsList)
        {
            if (score.loop && score.active && !score.mute)
            {
                Audio_Manager.instance.StopSong(score.songName);
                currentCoroutine = Coroutine_LOOP(score);
                StartCoroutine(currentCoroutine);
            }
        }
    }
    
    IEnumerator Coroutine_LOOP(Sound loopedSound)
    {
        float timer = 0;

        while (isREC_Active)
        {
            timer += Time.deltaTime;
            
            if (timer >= loopedSound.audioClip.length + 0.5f)
            {
                soundNames_list.Add(loopedSound.songName);
                times_list.Add(counter);

                Audio_Manager.instance.PlaySong(loopedSound.songName);
                
                timer = 0;
                counter = 0;
            }
            
            yield return null;
        }
    }
    
    public void Activate_MODE_PLAY()
    {
        isPLAY_Active = true;
        
        currentCoroutine = Coroutine_PLAY();
        StartCoroutine(currentCoroutine);
    }
    
    public void Activate_PAUSE()
    {
        isPAUSE_Active = !isPAUSE_Active;
    }  
      
    public void Activate_LOOP()
    {
        isLOOP_Active = !isLOOP_Active;
    }

    IEnumerator Coroutine_PLAY()
    {
        int current_index = 0;
        int maxIndex = times_list.Count;

        while (isPLAY_Active)
        {
            if (!isPAUSE_Active)
            {
                counter += Time.deltaTime;
            }

            if (current_index < maxIndex)
            {
                if (counter >= times_list[current_index])
                {
                    Debug.Log(soundNames_list[current_index] + "/" + times_list[current_index]);

                    Audio_Manager.instance.PlaySong(soundNames_list[current_index]);
                    ++current_index;
                    counter = 0;
                }
            }
            else
            {
                if (isLOOP_Active)
                {
                    counter = 0;
                    current_index = 0;
                }
                else
                {
                    isPLAY_Active = false;
                    yield break;
                }
            }
            
            yield return null;
        }
    } 
    
    public void AddNewTime(GameObject button)
    {
        // Fem la comporvació per seguretat que el REC és actiu
        if (isREC_Active && !button.GetComponent<Sound>().mute)
        {
            times_list.Add(counter);
            
            counter = 0;
        }
    } 
    
    public void AddNewSound(GameObject button)
    {    
        // Fem la comporvació per seguretat que el REC és actiu
        if (isREC_Active && !button.GetComponent<Sound>().mute)
        {
            soundNames_list.Add(button.GetComponent<Sound>().songName);
            
            counter = 0;
        }
    }
    
    public void EXIT()
    {
         Application.Quit();
    }
}
