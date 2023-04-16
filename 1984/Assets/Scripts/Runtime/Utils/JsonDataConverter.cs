using System.Collections.Generic;
using Const;
using Newtonsoft.Json;
using UnityEngine;

public class JsonDataConverter<T> where T : IJsonData
{
    public Dictionary<string, List<T>> GetDictionaryfromJson(string path)
    {
        var dictionary = new Dictionary<string, List<T>>();
        TextAsset json = LoadJsonFile(path);
        if (IsJsonNull(json)) return null;
        
        List<T> dataList = DeserializeJson(json.text);
        FillDictionary(dictionary, dataList);
        return dictionary;
    } 
    private TextAsset LoadJsonFile(string path)
    {
        var json = Resources.Load<TextAsset>(path);
        return json;
    }
    
    private bool IsJsonNull(TextAsset json)
    {
        if (json != null) return false;
        Debug.LogError("JSON not found!");
        return true;
    }

    private List<T> DeserializeJson(string jsonText)
    {
        return JsonConvert.DeserializeObject<List<T>>(jsonText);
    }

    private void FillDictionary(Dictionary<string, List<T>> dictionary, List<T> dataList)
    {
        foreach (var data in dataList)
        {
            AddDataToDictionary(dictionary, data);
        }
    }
    private void AddDataToDictionary(Dictionary<string, List<T>> dictionary, T data)
    {
        string id = data.Id;
        if (!dictionary.ContainsKey(id))
        {
            dictionary[id] = new List<T>();
        }
        dictionary[id].Add(data);
    }
}