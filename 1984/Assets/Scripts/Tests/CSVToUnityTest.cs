using System.Collections.Generic;
using Structs;
using UnityEngine;

public class CSVToUnityTest : MonoBehaviour
{
    public Dictionary<string, List<DialogueData>> dictionary;
    private void Start()
    {
        var csvReader = new CSVReader();

        dictionary = csvReader.Read("Assets/Documentation/Dialogue.csv");

        foreach (var value in dictionary)
        {
            foreach (var list in value.Value)
            {
                Debug.Log(list.name + " : " + list.script);
            }
        }
    }
}