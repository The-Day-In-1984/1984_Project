using Aspose.Cells;
using UnityEditor;
public static class ExcelToJsonConverter
{
    private const string DialogueExcelPath = "Assets/Resources/Dialogue/Dialogue.xlsx";
    private const string DialogueJsonPath = "Assets/Resources/Dialogue/DialogueJson.json";
    
 
    /// <param name="inputPath">Assets/.../file.xlsx</param>
    /// <param name="outputPath">Assets/.../file.json</param>
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