using System.Collections.Generic;
using Structs;
public class DataManager
{
    public Dictionary<string, List<DialogueData>> DialogueData { get; private set; } = new Dictionary<string, List<DialogueData>>();
    private readonly JsonDataConverter<DialogueData> _jsonToDictionaryConverter = new JsonDataConverter<DialogueData>();

    public void Init()
    {
        LoadDialogueData();
    }

    private void LoadDialogueData()
    {
        DialogueData = _jsonToDictionaryConverter.GetDictionaryfromJson(Const.Consts.ResourcesDialogueJsonPath);
    }
}
