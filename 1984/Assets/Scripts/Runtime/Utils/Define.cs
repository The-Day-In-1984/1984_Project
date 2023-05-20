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
    public enum GameState
    {
        Ttitle,
        Platformer,
        Dialogue, 
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
    public struct StoryData : IJsonData
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Goto { get; set; }
        public string Character { get; set; }
        public string State { get; set;}
        public string Text { get;  set;}
        public string Scene { get;  set;}
    }
} 

namespace Const
{
    //test
    static class Consts
    {
        public const string ResourcesStoryJsonPath = "Story/StoryJson";
    }
}
