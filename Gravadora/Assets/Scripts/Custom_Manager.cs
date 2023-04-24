using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Manager : MonoBehaviour
{

    public void Activate_Deactivate_MODE_MUTE(GameObject button)
    {    
          button.GetComponent<Sound>().mute = !button.GetComponent<Sound>().mute;
          button.GetComponent<AudioSource>().mute = button.GetComponent<Sound>().mute; 
    }    
    
    public void Activate_Deactivate_MODE_LOOP(GameObject button)
    {    
          button.GetComponent<Sound>().loop = !button.GetComponent<Sound>().loop;
          button.GetComponent<AudioSource>().loop = button.GetComponent<Sound>().loop; 
    }
}
