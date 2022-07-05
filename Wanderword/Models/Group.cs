namespace Wanderword_programming_test.Models
{
    /// <summary>
    /// A collection of employees, relevant group information & functions.
    /// </summary>
    public class Group
    {
        public List<Employee> Employees { get; private set; }
        public uint Score { get; private set; }
        public Skills MaximumSkills { get; private set; }
        public bool IsCompatible { get; private set; }

        /// <summary>
        /// Initializes a <c>Group</c> object using a list of employees.
        /// </summary>
        /// <param name="employees">A list of employees to be part of the group.</param>
        public Group(List<Employee> employees)
        {
            this.Employees = employees;
            this.MaximumSkills = GetMaximumSkills(this);
            this.Score = MaximumSkills.GetLowest();
            this.IsCompatible = IsGroupCompatible(employees);
        }

        /// <summary>
        /// returns the maximum of each skill across a group
        /// </summary>
        /// <param name="group">The group to interpret</param>
        /// <returns>a <c>Skills</c> object containing the maximum skills of the group</returns>
        private static Skills GetMaximumSkills(Group group)
        {
            uint maxProgramming = 0;
            uint maxWriting = 0;
            uint maxGameDesign = 0;
            uint maxAudio = 0;
            uint maxProjectManagement = 0;

            foreach (Employee employee in group.Employees)
            {
                maxProgramming = Math.Max(employee.Skills.Programming, maxProgramming);
                maxWriting = Math.Max(employee.Skills.Writing, maxWriting);
                maxGameDesign = Math.Max(employee.Skills.GameDesign, maxGameDesign);
                maxAudio = Math.Max(employee.Skills.Audio, maxAudio);
                maxProjectManagement = Math.Max(employee.Skills.ProjectManagement, maxProjectManagement);
            }

            return new(maxProgramming,
                       maxWriting,
                       maxGameDesign,
                       maxAudio,
                       maxProjectManagement);
        }

        /// <summary>
        /// Parses a comma-seperated list of employees in a string of input and returns a group object.
        /// </summary>
        /// <param name="employees">A dictionary containing all relevant employees.</param>
        /// <param name="input">The string to parse.</param>
        /// <returns>A group of employees.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the referenced employee is not part of the dictionary.</exception>
        public static Group ParseGroup(Dictionary<string, Employee> employees, string input)
        {
            List<Employee> employeeList = new();
            input = input.Replace(",", "");
            string[] names = input.Split(' ');
            foreach (string name in names)
            {
                if (employees.TryGetValue(name, out Employee? employee))
                    employeeList.Add(employee);
                else
                    throw new KeyNotFoundException(); //if it reaches here there's either a problem with employeeparser or input data
            }

            return new(employeeList);
        }

        /// <summary>
        /// checks if a group is compatible by the entire group sharing at least one interest
        /// </summary>
        /// <returns>true if all members of the group share at least one common interest, false otherwise</returns>
        public static bool IsGroupCompatible(List<Employee> employees)
        {
            //if group size is 1 or less it's garantueed to be common interests
            if (employees.Count <= 1)
                return true;

            uint commonInterests = employees[0].Interests;

            // Biwise 'and' between every person to find out if any interests are shared among the group
            for (int i = 1; i < employees.Count; i++)
            {
                commonInterests &= employees[i].Interests;
            }

            return commonInterests != 0;
        }

        /// <summary>
        /// Returns the score of the group
        /// </summary>
        /// <returns>Returns the score of the group if it's compatible, otherwise "invalid"<./returns>
        public override string ToString()
        {
            if (!this.IsCompatible)
                return "invalid";
            return this.Score.ToString();
        }
    }
}
