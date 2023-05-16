namespace Enums
{
    public enum PLAYER_STATE
    {
        IDLE,
        RUN,
        JUMP,
        CLIMB
    }

    //test
    enum GameState
    {
        None,
        Start,
        Playing, 
        Pause,
        End,
    }

    public enum TeleScreenType
    {
        Ready,
        On,
        Off
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
        public string Character { get; set;}
        public string Text { get;  set;}
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
