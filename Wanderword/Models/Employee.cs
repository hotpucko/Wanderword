namespace Wanderword_programming_test.Models
{
    /// <summary>
    /// A representation of an employee handling basic attributes, interests, and functionality.
    /// </summary>
    public class Employee
    {
        public string Name { get; private set; }
        public Skills Skills { get; private set; }
        public uint Interests { get; private set; }

        /// <summary>
        /// Initializes an <c>Employee</c> object based on input skills and interests.
        /// </summary>
        /// <param name="name">The name of the Employee.</param>
        /// <param name="programming">The programming skill of the employee.</param>
        /// <param name="writing">The writing skill of the employee.</param>
        /// <param name="gameDesign">The game design skill of the employee.</param>
        /// <param name="audio">The audio skill of the employee.</param>
        /// <param name="projectManagement">The project management skill of the employee.</param>
        /// <param name="interests">the interests of the employee in a bit field, <example>for example: 1101 = 8 + 4 + 1 = 13</example></param>
        public Employee(string name, uint programming, uint writing, uint gameDesign, uint audio, uint projectManagement, uint interests)
        {
            this.Name = name;
            Skills = new(programming, writing, gameDesign, audio, projectManagement);
            this.Interests = interests;
        }

        /// <summary>
        /// Parses an employee input string and returns an <c>Employee</c> object.
        /// <para>
        /// <example>
        /// For example:
        /// <c>"Anton, skills: programming 87, writing 23, game design 38, audio 13, project management 68. interests: quiz, online"</c>
        /// </example>
        /// </para>
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <returns>An Employee based on input</returns>
        /// <exception cref="ArgumentException">Thrown when the input string is formatted incorrectly</exception>
        public static Employee ParseEmployee(string input)
        {
            Employee employee;

            string[] words = input.Replace(",", "").Replace(".", "").Split(' ');

            string[] interestWords = words.TakeLast(words.Length - 14).ToArray();
            uint interests = 0;
            foreach (string interestWord in interestWords)
            {
                Interest.interests.TryGetValue(interestWord, out uint value);
                interests += value;
            }

            try
            {
                employee = new(name: words[0],
                           programming: uint.Parse(words[3]),
                           writing: uint.Parse(words[5]),
                           gameDesign: uint.Parse(words[8]),
                           audio: uint.Parse(words[10]),
                           projectManagement: uint.Parse(words[13]),
                           interests: interests);
            }
            catch { throw new ArgumentException("The employee input is incorrect."); }
            
            return employee;
        }
    }
}
