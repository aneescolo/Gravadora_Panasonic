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
    private Sound listSoundBtn;
    public string songName_bck;
    public AudioClip audioClip_bck;
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
            opencloseCutomPanel = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            selectedSoundBtn.songName = Audio_Manager.instance.soundsList[Audio_Manager.instance.soundsList.Length -1].songName;
            listSoundBtn.songName = songName_bck;
        }
    }

    public void OpenCutsomPanel()
    {
        opencloseCutomPanel = !opencloseCutomPanel;    
        
        if (opencloseCutomPanel)
        {
            ExchangeSoundVariables();
            sound_custom_panel.SetActive(false);
        }
        else
        {
            selectedSound = 1;
            selectedSoundTxt.text = $"{selectedSound}";
            selectedSoundBtn = Audio_Manager.instance.soundsList[selectedSound - 1];
            songName_bck = selectedSoundBtn.songName;
            audioClip_bck = selectedSoundBtn.audioClip;
            Custom_Manager.instance.ChargeSound_VOLUME(selectedSoundBtn);
            Custom_Manager.instance.RefreshCurrentSoundTxt(selectedSoundBtn.songName);
            Refresh_Sound_Edit();
            sound_custom_panel.SetActive(true);
        }
    }

    private void RefreshCurrentSound()
    {
        selectedSoundBtn = Audio_Manager.instance.soundsList[selectedSound - 1];
        songName_bck = selectedSoundBtn.songName;
        audioClip_bck = selectedSoundBtn.audioClip;
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
    
    public void Refresh_Sound_Edit()
    {
        foreach (Sound score in Audio_Manager.instance.soundsList)
        {
            if (!score.active)
            {
                SelectSoundEdit(score.songName);
                Custom_Manager.instance.RefreshSelectedSoundTxt(score.songName);
                break;
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

    private void ExchangeSoundVariables()
    {
        /*selectedSoundBtn.songName = listSoundBtn.songName;
        selectedSoundBtn.audioClip = listSoundBtn.audioClip;

        foreach (var sound in Audio_Manager.instance.soundsList)
        {
            if (sound.songName.Equals(listSoundBtn.songName))
            {
                sound.songName = songName_bck;
                sound.audioClip = audioClip_bck;
                break;
            }
        }*/
        
        selectedSoundBtn.songName = listSoundBtn.songName;
        selectedSoundBtn.audioClip = listSoundBtn.audioClip;
        selectedSoundBtn.audioSource.clip = selectedSoundBtn.audioClip;
        listSoundBtn.songName = songName_bck;
        listSoundBtn.audioClip = audioClip_bck;
    }

    

    public void SelectSoundEdit(string songName)
    {
        foreach (var sound in Audio_Manager.instance.soundsList)
        {
            if (sound.songName == songName)
            {
                listSoundBtn = sound;
                break;
            }
        }
    }
}
