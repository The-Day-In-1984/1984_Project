using System.Collections.Generic;
using Structs;
public class DataManager
{
    public Dictionary<string, List<DialogueData>> DialogueData { get; private set; } = new Dictionary<string, List<DialogueData>>();
    private readonly JsonToDictionaryConverter<DialogueData> _jsonToDictionaryConverter = new JsonToDictionaryConverter<DialogueData>();

    public void Init()
    {
        LoadDialogueData();
    }

    private void LoadDialogueData()
    {
        DialogueData = _jsonToDictionaryConverter.GetDictionary(Const.Consts.ResourcesDialogueJsonPath);
    }
}
