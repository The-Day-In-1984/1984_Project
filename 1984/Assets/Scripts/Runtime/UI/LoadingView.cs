using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class LoadingView : UIView
{
    [SerializeField] private TextMeshProUGUI loadingTitleText;
    [SerializeField] private TextMeshProUGUI loadingBodyText;
    
    public async void SetLoadingText(string title, string body)
    {
        loadingTitleText.text = title;
        loadingBodyText.text = body;

        await Task.Delay(5000);
    }
}
