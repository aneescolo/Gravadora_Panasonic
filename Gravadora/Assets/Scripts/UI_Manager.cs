using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{

    [Header("----- Panels -----")]
    [SerializeField] private GameObject sound_custom_panel;
    private bool opencloseCutomPanel;
    
    [Header("----- Sounds List -----")]
    public GameObject content_soud_list;
    public Item_sound_list item_soud_list;

    [Header("----- Custom Panel -----")] 
    public int selectedSound;
    public Sound selectedSoundBtn;
    public TMP_Text selectedSoundTxt;

    public void OpenCutsomPanel()
    {
        if (opencloseCutomPanel)
        {
            Custom_Manager.instance.ChangeSound_VOLUME(selectedSoundBtn);
            sound_custom_panel.SetActive(false);
        }
        else
        {
            Custom_Manager.instance.ChargeSound_VOLUME(selectedSoundBtn);
            sound_custom_panel.SetActive(true);
        }
        
        opencloseCutomPanel = !opencloseCutomPanel;    
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
