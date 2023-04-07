using Aspose.Cells;
using UnityEditor;
public class ExcelToJsonConverter
{
    private const string DialogueExcelPath = "Assets/Resources/Dialogue/Dialogue.xlsx";
    private const string DialogueJsonPath = "Assets/Resources/Dialogue/DialogueJson.json";
    
    private static void Convert(string inputPath, string outputPath)
    {
        var workbook = new Workbook(inputPath);
        workbook.Save(outputPath);
    }

    [InitializeOnLoadMethod]
    private static void ConvertDialogue()
    {
        Convert(DialogueExcelPath, DialogueJsonPath);
    }
}
