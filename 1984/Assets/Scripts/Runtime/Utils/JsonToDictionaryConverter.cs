using System.Collections.Generic;
using Const;
using Newtonsoft.Json;
using UnityEngine;

public class JsonToDictionaryConverter<T> where T : IJsonData
{
    public Dictionary<string, List<T>> GetDictionary(string path = Consts.ResourcesDialogueJsonPath)
    {
        var dictionary = new Dictionary<string, List<T>>();
        string errorMessage = "JSON not found!";
        TextAsset json = LoadJson(path, errorMessage);

        if (json != null)
        {
            ConvertJsonToDictionary(dictionary, json.text);
        }
        return dictionary;
    }

    private TextAsset LoadJson(string path, string errorMessage)
    {
        TextAsset json = Resources.Load<TextAsset>(path);
        if (json == null)
        {
            Debug.LogError(errorMessage);
        }
        return json;
    }

    private void ConvertJsonToDictionary(Dictionary<string, List<T>> dictionary, string jsonText)
    {
        List<T> jsonData = JsonConvert.DeserializeObject<List<T>>(jsonText);
        AddDictionary(dictionary, jsonData);
    }

    private void AddDictionary(Dictionary<string, List<T>> dictionary, List<T> jsonData)
    {
        foreach (var data in jsonData)
        {
            string id = data.Id;
            if (!dictionary.ContainsKey(id))
            {
                dictionary[id] = new List<T>();
            }
            dictionary[id].Add(data);
        }
    }
}
