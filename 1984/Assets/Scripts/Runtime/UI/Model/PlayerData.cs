using UnityEngine;
 
[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    private Data<int> _reliability = new Data<int>();
    
    public Data<int> Reliability
    {
        get { return _reliability;}
        set
        {
            Mathf.Clamp(value.Value, 0, 100);
        }
    }
}