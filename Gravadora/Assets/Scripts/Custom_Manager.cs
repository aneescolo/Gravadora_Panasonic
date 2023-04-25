using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Custom_Manager : MonoBehaviour
{
    
    [SerializeField] private Slider _sliderMaster;
    [SerializeField] private Slider _sliderSound;
    
    void Start()
    {
        
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            StartCoroutine(ChargeSavedMusicVolume());
        }
        
        _sliderMaster.onValueChanged.AddListener(val => ChangeMaster_VOLUME(val));
    }
    
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
    
    public void ChargeSound_VOLUME(GameObject button)
    { 
        _sliderSound.value = button.GetComponent<Sound>().volume; 
    }
    
    public void ChangeSound_VOLUME(GameObject button)
    {    
        button.GetComponent<Sound>().volume = _sliderSound.value; 
        button.GetComponent<AudioSource>().volume = button.GetComponent<Sound>().volume; 
    }
    
    private void ChangeMaster_VOLUME(float value)
    {
        AudioListener.volume = value;
        
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
    
    IEnumerator ChargeSavedMusicVolume()
    {
        yield return new WaitForSeconds(0.3f);
        ChangeMaster_VOLUME(PlayerPrefs.GetFloat("MasterVolume"));
        _sliderMaster.value = PlayerPrefs.GetFloat("MasterVolume");
    }
}
