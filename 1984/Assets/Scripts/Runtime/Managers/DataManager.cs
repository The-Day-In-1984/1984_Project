using System.Collections.Generic;
using Structs;
public class DataManager
{
    public Dictionary<string, List<StoryData.DialogueData>> DialogueData { get; private set; }
    public Dictionary<string, List<StoryData.OptionData>> OptionData { get; private set; }
    public Dictionary<string, List<StoryData.CharacterData>> CharacterData { get; private set; }
    public Dictionary<string, List<StoryData.SceneData>> SceneData { get; private set; }
    private readonly JsonDataConverter<StoryData.DialogueData> _dialogueDataConverter = new JsonDataConverter<StoryData.DialogueData>();
    private readonly JsonDataConverter<StoryData.OptionData> _optionDataConverter = new JsonDataConverter<StoryData.OptionData>();
    private readonly JsonDataConverter<StoryData.CharacterData> _characterDataConverter = new JsonDataConverter<StoryData.CharacterData>();
    private readonly JsonDataConverter<StoryData.SceneData> _sceneDataConverter = new JsonDataConverter<StoryData.SceneData>();

    public void Init()
    {
        LoadStoryData();
    }

    private void LoadStoryData()
    {
        DialogueData = _dialogueDataConverter.GetDictionariesFromJson(Const.Consts.ResourcesStoryJsonPath)["Dialogue"];
        OptionData = _optionDataConverter.GetDictionariesFromJson(Const.Consts.ResourcesStoryJsonPath)["Option"];
        CharacterData = _characterDataConverter.GetDictionariesFromJson(Const.Consts.ResourcesStoryJsonPath)["Character"];
        SceneData = _sceneDataConverter.GetDictionariesFromJson(Const.Consts.ResourcesStoryJsonPath)["Scene"];
    }
}
