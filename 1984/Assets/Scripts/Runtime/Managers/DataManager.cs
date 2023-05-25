using System.Collections.Generic;
using Structs;
using UnityEngine;

public class DataManager
{
    public Dictionary<string, List<StoryData>> StoryData { get; private set; }
    private readonly JsonDataConverter<StoryData> _storyDataConverter = new JsonDataConverter<StoryData>();
    private PlayerData _playerData;
    
    private const string PlayerDataPath = "Data/PlayerData";

    public void Init()
    {
        LoadStoryData();
        LoadPlayerData();
    }

    private void LoadStoryData()
    {
        StoryData = _storyDataConverter.GetDictionaryFromJson(Const.Consts.ResourcesStoryJsonPath);
    }
    
    private void LoadPlayerData()
    {
        _playerData = Resources.Load<PlayerData>(PlayerDataPath);
    }
    
    public void SetReliability(int reliability)
    {
        _playerData.Reliability.Value += reliability;
    }
    
}
