
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
        
        _sliderMaster.onValueChanged.AddListener(val => ChangeMaster_VOLUME(val));
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
    
    public void ChangeSound_VOLUME(Sound button)
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

    public void RefreshSelectedSoundTxt(string soundName)
    {
        selectedSound_txt.text = soundName;
    }    
    
    public void RefreshCurrentSoundTxt(string soundName)
    {
        currentSound_txt.text = soundName;
    }
    
    public void ChangeBtnSprite(GameObject selectedBtn, Sprite image, Sprite pressed)
    {
        SpriteState pressedBtn = new SpriteState();
        pressedBtn.pressedSprite = pressed;
        selectedBtn.GetComponent<Image>().sprite = image;
        selectedBtn.GetComponent<Button>().spriteState = pressedBtn;
    }
}
