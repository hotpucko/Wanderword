namespace Wanderword_programming_test.Models
{
    /// <summary>
    /// A collection of attributes relevant to an employee.
    /// </summary>
    public struct Skills
    {
        public uint Programming { get; private set; }
        public uint Writing { get; private set; }
        public uint GameDesign { get; private set; }
        public uint Audio { get; private set; }
        public uint ProjectManagement { get; private set; }

        /// <summary>
        /// Initializes a <c>Skills</c> object based on input skills.
        /// </summary>
        /// <param name="programming">The programming skill.</param>
        /// <param name="writing">The writing skill.</param>
        /// <param name="gameDesign">The game design skill.</param>
        /// <param name="audio">The audio skill.</param>
        /// <param name="projectManagement">The project management skill.</param>
        public Skills(uint programming, uint writing, uint gameDesign, uint audio, uint projectManagement)
        {
            Programming = programming;
            Writing = writing;
            GameDesign = gameDesign;
            Audio = audio;
            ProjectManagement = projectManagement;
        }
        
        /// <summary>
        /// Gets the minimum attribute.
        /// </summary>
        /// <returns>The lowest attribute.</returns>
        public uint GetLowest()
        {
            return new uint[] { Programming, Writing, GameDesign, Audio, ProjectManagement }.Min();
        }
    }
}
