using System;
using UnityEngine;
using System.Collections.Generic;

public class PlatformerViewController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private Queue<UIView> _uiViews = new Queue<UIView>();

    private void Start()
    {
        playerData.reliability.Value = 100;
        
        
    }

    private void Update()
    {
        //temp
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerData.reliability.Value -= 10;
            var popup = GameManager.UI.PopupPush("UIMission_Money", _uiViews);
            
            popup.gameObject.transform.SetParent(this.transform);
            popup.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
}