using System.Collections.Generic;
using System.IO;
using Const;
using Structs;
using UnityEngine;

public class CSVReader
{
    public Dictionary<string, List<DialogueData>> Read(string filePath)
    {
        var reader = new StreamReader(filePath);
        var dictionary = new Dictionary<string, List<DialogueData>>();
        
        // Header 제거
        reader.ReadLine();
        while (!reader.EndOfStream)
        {
            var cells = new List<string>();
            bool isQuoteFront;
            bool isQuoteEnd;

            do
            {
                string line = reader.ReadLine();
                if (line == null) break;
                string[] splitLine = line.Split(",");
                
                // 콤마 예외 처리
                if (splitLine.Length > Consts.SCRIPT)
                {
                    for (int i = Consts.SCRIPT + 1; i < splitLine.Length; i++)
                    {
                        splitLine[Consts.SCRIPT] += splitLine[i];
                    }
                }
                
                if (cells.Count == 0)
                {
                    for (int i = 0; i <= Consts.SCRIPT; i++)
                    {
                        cells.Add(splitLine[i]);
                    }
                }
                else
                    cells[^1] += '\n'+line;

                // 줄바꿈 예외 처리
                isQuoteFront = cells[^1][0] == '\"';
                isQuoteEnd = cells[^1][^1] == '\"';
            } while (isQuoteFront ^ isQuoteEnd);

            // key : Scnen + Branch
            string key = cells[Consts.SCENE] + cells[Consts.BRANCH];
            
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, new List<DialogueData>());
            
            // key를 기준으로 Name과 Script 저장
            var data = new DialogueData(cells[Consts.NAME], cells[Consts.SCRIPT]);
            dictionary[key].Add(data);
        }
        reader.Close();

        return dictionary;
    }
}