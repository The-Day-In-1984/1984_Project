using TMPro;
using UnityEngine;

public class PlatformerView : UIView 
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private TextMeshProUGUI reliabilityText;
    
    private void OnEnable()
    {
        playerData.reliability.onChange += UpdateReliabilityUI;
    }
    
    private void OnDisable()
    {
        playerData.reliability.onChange -= UpdateReliabilityUI;
    }

    private void UpdateReliabilityUI(int hp)
    {
        // Update UI
        reliabilityText.text = hp.ToString();
    }
}