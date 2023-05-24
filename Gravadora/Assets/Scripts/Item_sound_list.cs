using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_sound_list : MonoBehaviour
{
    public string songName;
    public AudioClip audioClip;
    [SerializeField] private AudioSource _audioSource;

    void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = songName;
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(PlaySound);
        gameObject.GetComponent<Button>().onClick.AddListener(Refresh_Selected_Sound);
    }

    private void PlaySound()
    {
        _audioSource.PlayOneShot(audioClip);
    }
    
    private void Refresh_Selected_Sound()
    {
        Custom_Manager.instance.RefreshSelectedSoundTxt(songName);
        UI_Manager.instance.SelectSoundEdit(songName);
    }
}
