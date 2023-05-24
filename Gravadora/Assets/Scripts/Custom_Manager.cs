
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Custom_Manager : MonoBehaviour
{
    public static Custom_Manager instance;
    
    [SerializeField] private Slider _sliderMaster;
    [SerializeField] private Slider _sliderSound;
    
    [SerializeField] private TMP_Text selectedSound_txt;
    [SerializeField] private TMP_Text currentSound_txt;

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
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            StartCoroutine(ChargeSavedMusicVolume());
        }
    }
    
    public void Update_MODE_MUTE(GameObject button)
    {
        button.GetComponent<Sound>().Activate_Deactivate_MODE_MUTE();
    }    
    
    public void Update_MODE_LOOP(GameObject button)
    { 
        button.GetComponent<Sound>().Activate_Deactivate_MODE_LOOP();
    }    
    
    public void ChargeSound_VOLUME(Sound button)
    { 
        _sliderSound.value = button.GetComponent<Sound>().volume; 
    }
    
    public void ChangeSound_VOLUME()
    {    
        UI_Manager.instance.SelectedSoundBtn.volume = _sliderSound.value; 
        UI_Manager.instance.SelectedSoundBtn.audioSource.volume = UI_Manager.instance.SelectedSoundBtn.volume; 
    }
    
    public void ChangeMaster_VOLUME()
    {
        AudioListener.volume = _sliderMaster.value;
        Debug.Log(PlayerPrefs.GetFloat("MasterVolume"));
        
        PlayerPrefs.SetFloat("MasterVolume", _sliderMaster.value);
    }

    IEnumerator ChargeSavedMusicVolume()
    {
        yield return new WaitForSeconds(0.3f);
        _sliderMaster.value = PlayerPrefs.GetFloat("MasterVolume");
        AudioListener.volume = _sliderMaster.value;
    }

    public void RefreshSelectedSoundTxt(string soundName)
    {
        selectedSound_txt.text = soundName;
    }    
    
    public void RefreshCurrentSoundTxt(string soundName)
    {
        currentSound_txt.text = soundName;
    }
}
