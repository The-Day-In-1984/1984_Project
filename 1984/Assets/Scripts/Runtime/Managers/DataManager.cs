
using System.Collections.Generic;
using Structs;
public class DataManager
{
    public Dictionary<string, List<DialogueData>> dialogueData = new Dictionary<string, List<DialogueData>>();

    public void Init()
    {
        LoadDialogueData();
    }

    private void LoadDialogueData()
    {
        DialogueConverter dialogueConverter = new DialogueConverter();
        dialogueData = dialogueConverter.GetDictionary();
    }
}
