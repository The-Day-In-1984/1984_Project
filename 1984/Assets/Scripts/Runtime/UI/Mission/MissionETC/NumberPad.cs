using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberPad : MonoBehaviour
{
    private TextMeshProUGUI _numberPadText;
    void Start()
    {
        _numberPadText = GetComponent<TextMeshProUGUI>();
    }

    public void AddNumberPadText(string number)
    {
        _numberPadText.text += number;
    }
}
