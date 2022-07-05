using FluentAssertions;
using Wanderword_programming_test.Models;

namespace WanderwordTests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void ParseEmployee_WithValidString_ReturnsEmployee()
        {
            string input = "Anton, skills: programming 87, writing 23, game design 38, audio 13, project management 68. interests: quiz, online";

            Employee expected = new("Anton", 87, 23, 38, 13, 68, 3);
            Employee actual = Employee.ParseEmployee(input);
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void ParseEmployee_WithInvalidString_ThrowsArgumentException()
        {
            string input = "Anton, skills: programming abc, writing 23, game design 38. interests: quiz, online";

            Employee expected = new("Anton", 87, 23, 38, 13, 68, 3);
            Func<object> resultFunc = () => Employee.ParseEmployee(input);
            resultFunc.Should().Throw<ArgumentException>();
        }
    }
}
