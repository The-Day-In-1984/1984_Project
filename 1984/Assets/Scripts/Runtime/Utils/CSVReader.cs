using System.Collections.Generic;
using System.IO;
using Enums;
using Structs;

public class CSVReader
{
    
    // Dialogue CSV Read
    public Dictionary<string, List<DialogueData>> Read(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        var dictionary = new Dictionary<string, List<DialogueData>>();
        
        // Header 제거
        reader.ReadLine();
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            
            // key를 기준으로 name, script 저장
            // key : Scnen + Branch, ex) 윈스턴의 방 + 1-2
            string key = values[(int)DialogueHeader.Scene] + values[(int)DialogueHeader.Branch];
            
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, new List<DialogueData>()); 
            var data = new DialogueData(values[(int)DialogueHeader.Name], values[(int)DialogueHeader.Script]);
            dictionary[key].Add(data);
        }
        reader.Close();

        return dictionary;
    }
}