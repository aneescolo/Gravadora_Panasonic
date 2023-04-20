using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REC_Manager : MonoBehaviour
{
    [Header("----- Variables -----")]
    public bool isREC_Active;
    public bool isPLAY_Active;

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
    
    IEnumerator Coroutine_PLAY()
    {
        int current_index = 0;
        int maxIndex = times_list.Count;

        while (isPLAY_Active)
        {
            counter += Time.deltaTime;
            
            if (current_index < maxIndex)
            {
                if (counter >= times_list[current_index])
                {
                    Audio_Manager.instance.PlaySong(soundNames_list[current_index]);
                    ++current_index;
                    counter = 0;
                }
            }
            else
            {
                isPLAY_Active = false;
                yield break;
            }
            
            yield return null;
        }
    }

    public void AddNewTime()
    {
        // Fem la comporvació per seguretat que el REC és actiu
        if (isREC_Active)
        {
            times_list.Add(counter);
            
            counter = 0;
        }
    } 
    
    public void AddNewSound(string songName)
    {
        // Fem la comporvació per seguretat que el REC és actiu
        if (isREC_Active)
        {
            soundNames_list.Add(songName);
            
            counter = 0;
        }
    }
}