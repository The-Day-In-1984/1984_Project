
using System.Collections.Generic;
using Structs;
public class DataManager
{
    public Dictionary<string, List<DialogueData>> DialogueData { get; private set; } = new();
    private readonly JsonToDictionaryConverter<DialogueData> _jsonToDictionaryConverter = new();

    public void Init()
    {
        LoadDialogueData();
    }

    private void LoadDialogueData()
    {
        DialogueData = _jsonToDictionaryConverter.GetDictionary(Const.Consts.ResourcesDialogueJsonPath);
    }
}
