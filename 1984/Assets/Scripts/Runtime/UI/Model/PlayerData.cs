using UnityEngine;
 
[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    public Data<int> reliability = new Data<int>();
}