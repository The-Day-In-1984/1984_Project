using System.Collections.Generic;
using Const;
using Newtonsoft.Json;
using Structs;
using UnityEngine;
using DialogueDictionary = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Structs.DialogueData>>;

public class DialogueConverter
{
    public DialogueDictionary GetDictionary(string path = Consts.ResourcesDialogueJsonPath)
    {
        var dictionary = new DialogueDictionary();
        string errorMessage = "Dialogue JSON not found!";
        TextAsset dialogueJson = LoadJson(path, errorMessage);

        if (dialogueJson != null)
        {
            ConvertJsonToDictionary(dictionary, dialogueJson.text);
        }
        return dictionary;
    }
    private TextAsset LoadJson(string path, string errorMessage)
    {
        TextAsset dialogueJson = Resources.Load<TextAsset>(path);
        if (dialogueJson == null)
        {
            Debug.LogError(errorMessage);
        }
        return dialogueJson;
    }
    private void ConvertJsonToDictionary(DialogueDictionary dictionary, string jsonText)
    {
        var jsonData = JsonConvert.DeserializeObject<List<DialogueData>>(jsonText);
        AddDictionary(dictionary, jsonData);
    }
    private void AddDictionary(DialogueDictionary dictionary, List<DialogueData> jsonData)
    {
        foreach (var data in jsonData)
        {
            if (!dictionary.ContainsKey(data.id))
            {
                dictionary[data.id] = new List<DialogueData>();
            }
            dictionary[data.id].Add(data);
        }
    }
}