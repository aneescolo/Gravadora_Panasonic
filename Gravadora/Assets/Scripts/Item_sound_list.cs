using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_sound_list : MonoBehaviour
{
    public string songName;
    public AudioClip audioClip;

    void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = songName;
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
}
