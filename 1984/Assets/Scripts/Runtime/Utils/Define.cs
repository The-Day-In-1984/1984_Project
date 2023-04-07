namespace Enums
{
    //test
    enum GameState
    {
        None,
        Start,
        Playing,
        Pause,
        End,
    }
}

namespace Structs
{
    //test
    struct GameData
    {
        public int score;
        public int level;
    }
}

namespace Const
{
    //test
    static class Consts
    {
        public const int MAX_SCORE = 100;
        public const int MAX_LEVEL = 10;

        public const string DIALOGUE_EXCEL_PATH = "Assets/Resources/Dialogue/Dialogue.xlsx";
        public const string DIALOGUE_JSON_PATH = "Assets/Resources/Dialogue/DialogueJson.json";
    }
}
