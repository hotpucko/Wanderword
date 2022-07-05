using Wanderword_programming_test.Models;

string[] input;
try
{
    // If an args variable is declared use it as path, otherwise use default input.txt
    input = File.ReadAllLines(args.Length > 0 ? args[0] : @"input.txt");
}
catch (Exception e)
{
    Console.WriteLine("Error initializing with input data. {0}", e);
    return;
}

ParseEmployeesAndGroups(input,
                        out Dictionary<string, Employee> employees,
                        out List<Group> groups);

// Print the main assignment
foreach (Group group in groups)
{
    Console.WriteLine(group.ToString());
}

Console.ReadLine();


/// <summary>
/// Parses an input string array into employees and creates groups out of said employees.
/// </summary>
/// <param name="input">The array to parse.</param>
/// <param name="employees">A collection of employees.</param>
/// <param name="groups">A collection of groups containing employees.</param>
static void ParseEmployeesAndGroups(string[] input, out Dictionary<string, Employee> employees, out List<Group> groups)
{
    employees = new();
    groups = new();
    bool parseGroups = false;
    foreach (string line in input)
    {
        if (line == "Groups:")
        {
            parseGroups = true;
            continue;
        }

        if (parseGroups)
        {
            groups.Add(Group.ParseGroup(employees, line));
            continue;
        }

        Employee employee = Employee.ParseEmployee(line);
        employees.Add(employee.Name, employee);
    }
}