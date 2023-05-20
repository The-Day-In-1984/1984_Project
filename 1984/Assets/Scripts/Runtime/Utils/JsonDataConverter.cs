using System.Collections.Generic;
using Const;
using Newtonsoft.Json;
using UnityEngine;

public class JsonDataConverter<T> where T : IJsonData
{
    public Dictionary<string, Dictionary<string, List<T>>> GetDictionariesFromJson(string path)
    {
        var dictionaries = new Dictionary<string, Dictionary<string, List<T>>>();
        TextAsset json = LoadJsonFile(path);
        if (IsJsonNull(json)) return null;

        var dataDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<T>>>(json.text);

        foreach (var key in dataDictionary.Keys)
        {
            List<T> dataList = dataDictionary[key];
            var dictionary = new Dictionary<string, List<T>>();
            FillDataToDictionary(dictionary, dataList);
            dictionaries[key] = dictionary;
        }

        return dictionaries;
    }
    public Dictionary<string, List<T>> GetDictionaryFromJson(string path)
    {
        var dictionary = new Dictionary<string, List<T>>();
        TextAsset json = LoadJsonFile(path);
        if (IsJsonNull(json)) return null;
        
        List<T> dataList = JsonConvert.DeserializeObject<List<T>>(json.text);
        FillDataToDictionary(dictionary, dataList);
        return dictionary;
    } 
    
    private TextAsset LoadJsonFile(string path)
    {
        var json = Resources.Load<TextAsset>(path);
        return json;
    }
    
    private Dictionary<string, TextAsset> LoadJsonFiles(string path, List<string> sheetNames)
    {
        var jsonFiles = new Dictionary<string, TextAsset>();
        foreach (var sheetName in sheetNames)
        {
            var json = Resources.Load<TextAsset>($"{path}/{sheetName}");
            if(IsJsonNull(json)) continue;
            else jsonFiles[sheetName] = json;
        }
        return jsonFiles;
    }
    
    private bool IsJsonNull(TextAsset json)
    {
        if (json != null) return false;
        Debug.LogError("Json not found!");
        return true;
    }

    private void FillDataToDictionary(Dictionary<string, List<T>> dictionary, List<T> dataList) 
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