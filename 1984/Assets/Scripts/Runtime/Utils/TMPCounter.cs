using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPCounter : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _textMeshProUGUI.text = "0";
    }

    public void AddCount()
    {
        _textMeshProUGUI.text = (int.Parse(_textMeshProUGUI.text) + 1).ToString();
    }
}
