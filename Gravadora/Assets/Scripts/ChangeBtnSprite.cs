using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBtnSprite : MonoBehaviour
{
    public static ChangeBtnSprite instance;
    
    private bool highlight;
    private Sprite imageNormal;
    private Sprite pressedNormal;
    [SerializeField] private Sprite imageHihglight;
    [SerializeField] private Sprite pressedHihglight;
    
    private bool numberBtn;

    public IEnumerator currentCoroutine;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        imageNormal = gameObject.GetComponent<Image>().sprite;
        pressedNormal = gameObject.GetComponent<Button>().spriteState.pressedSprite;
    }

    public void ChangeSprite()
    {
        highlight = !highlight;
        
        if (highlight)
        {
            SpriteState pressedBtn = new SpriteState();
            pressedBtn.pressedSprite = pressedHihglight;
            gameObject.GetComponent<Image>().sprite = imageHihglight;
            gameObject.GetComponent<Button>().spriteState = pressedBtn;
        }
        else
        {
            SpriteState pressedBtn = new SpriteState();
            pressedBtn.pressedSprite = pressedNormal;
            gameObject.GetComponent<Image>().sprite = imageNormal;
            gameObject.GetComponent<Button>().spriteState = pressedBtn;
        }
    }
    
    public void ChangeSprite_Timer(Sprite image)
    {
        if (!gameObject.GetComponent<Sound>().mute)
        {
            numberBtn = true;
            currentCoroutine = Coroutine_ChangeSprite(image, gameObject);
            StartCoroutine(currentCoroutine);
        }
    }    
    public void ChangeSprite_List(Sprite image, GameObject sound)
    {
        numberBtn = true;
        currentCoroutine = Coroutine_ChangeSprite(image, sound);
        StartCoroutine(currentCoroutine);
    }
    
    IEnumerator Coroutine_ChangeSprite(Sprite numberHighlight, GameObject btn)
    {
        float timer = 0;
        Sprite imageBtn = btn.GetComponent<Image>().sprite;
        btn.GetComponent<Image>().sprite = numberHighlight;

        while (numberBtn)
        {
            timer += Time.deltaTime;
            
            if (timer >= 0.6f)
            {
                btn.GetComponent<Image>().sprite = imageBtn;
                numberBtn = false;
            }
            
            yield return null;
        }
    }
}
