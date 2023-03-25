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

    struct DialogueData
    {
        public string name;
        public string script;
    }
}

namespace Const
{
    //test
    static class Consts
    {
        public const int MAX_SCORE = 100;
        public const int MAX_LEVEL = 10;
    }
}