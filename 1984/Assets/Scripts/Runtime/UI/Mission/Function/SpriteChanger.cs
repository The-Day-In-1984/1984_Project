using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite changeSprite;

    private Image _image;
    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    
    public void ChangeSprite()
    {
        _image.sprite = changeSprite;
    }
}
