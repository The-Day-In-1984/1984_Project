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

    enum DialogueHeader
    {
        Scene,
        Branch,
        Name,
        Script,
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
        public string name;
        public string script;

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
    }
}
