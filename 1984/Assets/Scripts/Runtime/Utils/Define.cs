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
    public struct DialogueData
    {
        public string id;
        public string character;
        public string text;
    }
} 

namespace Const
{
    //test
    static class Consts
    {
        public const string ResourcesDialogueJsonPath = "Dialogue/DialogueJson";
    }
}
