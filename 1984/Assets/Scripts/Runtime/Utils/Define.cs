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
    public struct DialogueData : IJsonData
    {
        public string Id { get; set; }
        public string character { get; set; }
        public string Text { get; set; }
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
