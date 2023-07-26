using UnityEngine;
 
[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    private Data<int> _reliability = new Data<int>();
    private Data<int> _contributions = new Data<int>();
    private Data<bool> _isMission = new Data<bool>();
    private Data<float> _timer = new Data<float>();

    public Data<int> Reliability
    {
        get { return _reliability;}
        set
        {
            Mathf.Clamp(value.Value, 0, 100);
        }
    }

    public Data<int> Contributions
    {
        get { return _contributions; }
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
    
    public Data<float> Timer
    {
        get { return _timer;}
        set
        {
            _timer.Value = value.Value;
        }
    }
}