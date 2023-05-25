using UnityEngine;
 
[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    private Data<int> _reliability = new Data<int>();
    private Data<bool> _isMission = new Data<bool>();

    public Data<int> Reliability
    {
        get { return _reliability;}
        set
        {
            Mathf.Clamp(value.Value, 0, 100);
        }
    }
    
    public Data<bool> IsMission
    {
        get { return _isMission;}
        set
        {
            _isMission.Value = value.Value;
        }
    }
}