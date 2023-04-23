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

    public struct DialogueData
    {
        public readonly string name;
        public readonly string script;

        public DialogueData(string name, string script)
        {
            this.name = name;
            this.script = script;
        }
    }
}

namespace Const
{
    //test
    static class Consts
    {
        public const int MAX_SCORE = 100;
        public const int MAX_LEVEL = 10;

        public const int SCENE = 0;
        public const int BRANCH = 1;
        public const int NAME = 2;
        public const int SCRIPT = 3;
    }
}
