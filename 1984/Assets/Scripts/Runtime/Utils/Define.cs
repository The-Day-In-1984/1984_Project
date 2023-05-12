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
    public struct StoryData : IJsonData
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Goto { get; set; }
        public string Character { get; set; }
        public string State { get; set;}
        public string Text { get;  set;}
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
