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
}

namespace Structs
{
    //test
    struct GameData
    {
        public int score;
        public int level;
    }
    public struct StoryData
    {
        public struct DialogueData : IJsonData{
            public string Id { get; set; }
            public string Index { get; set; }
            public string Option { get; set; }
            public string Character { get; set; }
            public string State { get; set;}
            public string Text { get;  set;}
        }
        public struct OptionData : IJsonData{
            public string Id { get; set; }
            public string Index { get; set; }
            public string Dialogue { get; set; }
            public string Character { get; set; }
            public string State { get; set;}
            public string Text { get;  set;}
        } 
        public struct CharacterData : IJsonData{
            
            public string Id { get; set; }
            public string Name { get; set; }
            public string State { get; set;}
            public string Art { get;  set;}
        }
        public struct SceneData : IJsonData{
            
            public string Id { get; set; }
            public string Description { get;  set;}
        }
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
