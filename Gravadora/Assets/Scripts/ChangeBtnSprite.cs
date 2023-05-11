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
    
    public void ChangeSpritePlay()
    {
        if (REC_Manager.instance.isPLAY_Active)
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
    
    public void ChangeSpriteREC()
    {
        if (REC_Manager.instance.isREC_Active)
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
    
    public void ChangeSpritePause()
    {
        if (REC_Manager.instance.isPAUSE_Active)
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
}
