using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{

    [Header("----- Panels -----")]
    [SerializeField] private GameObject sound_custon_panel;
    
    [Header("----- Web Request -----")]
    public List<Sound> soudlist = new List<Sound>();
    public GameObject content_soud_list;
    public Item_sound_list item_soud_list;

    
    public void Refresh_Sound_List()
    {
        Clean_Sound_List();

        foreach (Sound score in soudlist)
        {
            Item_sound_list _item_sound_list;
            _item_sound_list = Instantiate(item_soud_list, content_soud_list.transform);
            _item_sound_list.songName = score.songName;
            _item_sound_list.audioClip = score.audioClip;
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
