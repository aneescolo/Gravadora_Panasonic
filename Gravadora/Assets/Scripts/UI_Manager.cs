using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    [Header("----- Panels -----")]
    [SerializeField] private GameObject sound_custom_panel;
    private bool opencloseCutomPanel;
    
    [Header("----- Sounds List -----")]
    [SerializeField] private GameObject content_soud_list;
    [SerializeField] private Item_sound_list item_soud_list;

    [Header("----- Custom Panel -----")] 
    private int selectedSound = 1;
    private Sound selectedSoundBtn;
    [SerializeField] private TMP_Text selectedSoundTxt;

    public Sound SelectedSoundBtn
    {
        get {return selectedSoundBtn; }
        set {selectedSoundBtn = value; }
    }
    
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
    
    public void OpenCutsomPanel()
    {
        if (opencloseCutomPanel)
        {
            sound_custom_panel.SetActive(false);
        }
        else
        {
            selectedSound = 1;
            selectedSoundTxt.text = $"{selectedSound}";
            selectedSoundBtn = Audio_Manager.instance.soundsList[selectedSound - 1];
            Custom_Manager.instance.ChargeSound_VOLUME(selectedSoundBtn);
            Custom_Manager.instance.RefreshCurrentSoundTxt(selectedSoundBtn.songName);
            sound_custom_panel.SetActive(true);
        }
        
        opencloseCutomPanel = !opencloseCutomPanel;    
    }

    private void RefreshCurrentSound()
    {
        selectedSoundBtn = Audio_Manager.instance.soundsList[selectedSound - 1];
        Custom_Manager.instance.ChargeSound_VOLUME(selectedSoundBtn);
        Custom_Manager.instance.RefreshCurrentSoundTxt(selectedSoundBtn.songName);
    }

    public void AddIndexSound()
    {
        if (selectedSound != 9)
        {
            ++selectedSound;
            selectedSoundTxt.text = $"{selectedSound}";
            RefreshCurrentSound();
        }
        else
        {
            selectedSound = 1;
            selectedSoundTxt.text = $"{selectedSound}";
            RefreshCurrentSound();
        }
    }    
    
    public void TakeIndexSound()
    {
        if (selectedSound != 1)
        {
            --selectedSound;
            selectedSoundTxt.text = $"{selectedSound}";
            RefreshCurrentSound();
        }
        else
        {
            selectedSound = 9;
            selectedSoundTxt.text = $"{selectedSound}";
            RefreshCurrentSound();
        }
    }
    
    public void Refresh_Sound_List()
    {
        Clean_Sound_List();

        foreach (Sound score in Audio_Manager.instance.soundsList)
        {
            if (!score.active)
            {
                Item_sound_list _item_sound_list;
                _item_sound_list = Instantiate(item_soud_list, content_soud_list.transform);
                _item_sound_list.songName = score.songName;
                _item_sound_list.audioClip = score.audioClip; 
            }
        }
    }

    /// Destrueix els elements de la llista
    private void Clean_Sound_List()
    {
        foreach (Transform child in content_soud_list.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
