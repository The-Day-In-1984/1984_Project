using System.Collections.Generic;
using Structs;
public class DataManager
{
    public Dictionary<string, List<StoryData>> StoryData { get; private set; }
    private readonly JsonDataConverter<StoryData> _storyDataConverter = new JsonDataConverter<StoryData>();

    public void Init()
    {
        LoadStoryData();
    }

    private void LoadStoryData()
    {
        StoryData = _storyDataConverter.GetDictionaryFromJson(Const.Consts.ResourcesStoryJsonPath);
    }
}
