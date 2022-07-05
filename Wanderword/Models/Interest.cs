namespace Wanderword_programming_test.Models
{
    public static class Interest
    {
        /// <summary>
        /// A collection of interests where the key is the name of the interest and the value is a bitfield value for the key.
        /// </summary>
        public static readonly Dictionary<string, uint> interests = new() { { "quiz", 1 }, { "online", 2 }, { "detective", 4 }, { "tech", 8 }, { "horror", 16}, { "western", 32 }, { "music", 64 }, { "cooking", 128 }, { "rpg", 256 } };
    }
}