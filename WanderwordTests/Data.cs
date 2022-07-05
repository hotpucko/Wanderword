using Wanderword_programming_test.Models;

namespace WanderwordTests
{
    internal class Data
    {
        public static Dictionary<String, Employee> employees = new() 
        { 
            { "Anton", new("Anton", 87, 23, 38, 13, 68, 1 + 2) },
            { "Filip", new("Filip", 99, 12, 29, 50, 7, 1 + 4 + 8 + 16) },
            { "Karin", new("Karin", 44, 51, 88, 51, 91, 8 + 16 + 32) },
            { "Maria", new("Maria", 18, 64, 50, 56, 76, 16 + 64 + 128) }
        };
    }
}
