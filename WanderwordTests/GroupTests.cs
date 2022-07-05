using Wanderword_programming_test.Models;
using FluentAssertions;

namespace WanderwordTests
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void GetMaximumSkills_ShouldMaxSkills()
        {
            Group group = new(new List<Employee>() { Data.employees["Anton"], Data.employees["Filip"] });
            Skills expected = new(99, 23, 38, 50, 68);
            Skills actual = group.MaximumSkills;
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void ParseGroup_WithViableInput_ReturnsGroup()
        {
            string input = "Anton, Filip";
            Group actual = Group.ParseGroup(Data.employees, input);
            Group expected = new(new List<Employee>() { Data.employees["Anton"], Data.employees["Filip"] });
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void ParseGroup_WithInvalidInput_ThrowsKeyNotFoundException()
        {
            string input = "Anton, karina";
            Func<object> resultFunc = () => Group.ParseGroup(Data.employees, input);
            resultFunc.Should().Throw<KeyNotFoundException>();
        }

        [TestMethod]
        public void IsGroupCompatible_withCommonInterests_ReturnsTrue()
        {
            List<Employee> Group1 = new () 
            { 
                Data.employees["Anton"],
                Data.employees["Filip"]
            };
            List<Employee> Group2 = new()
            {
                Data.employees["Filip"],
                Data.employees["Karin"]
            };
            List<Employee> Group3 = new()
            {
                Data.employees["Filip"],
                Data.employees["Maria"],
                Data.employees["Karin"]
            };
            Group.IsGroupCompatible(Group1).Should().BeTrue();
            Group.IsGroupCompatible(Group2).Should().BeTrue();
            Group.IsGroupCompatible(Group3).Should().BeTrue();
        }

        [TestMethod]
        public void IsGroupCompatible_WithoutCommonInterests_ReturnsFalse()
        {
            List<Employee> group = new()
            {
                Data.employees["Anton"],
                Data.employees["Filip"],
                Data.employees["Maria"]
            };
            Group.IsGroupCompatible(group).Should().BeFalse();
        }

        [TestMethod]
        public void ToString_GroupIsCompatible_ReturnsScore()
        {
            List<Employee> employees = new()
            {
                Data.employees["Anton"],
                Data.employees["Filip"]
            };
            Group group1 = new(employees);
            employees = new()
            {
                Data.employees["Filip"],
                Data.employees["Karin"]
            };
            Group group2 = new(employees);
            employees = new()
            {
                Data.employees["Filip"],
                Data.employees["Maria"],
                Data.employees["Karin"]
            };
            Group group3 = new(employees);

            group1.ToString().Should().Match("23");
            group2.ToString().Should().Match("51");
            group3.ToString().Should().Match("56");
        }

        [TestMethod]
        public void ToString_GroupIsIncompatible_ReturnsInvalid()
        {
            List<Employee> employees = new()
            {
                Data.employees["Anton"],
                Data.employees["Filip"],
                Data.employees["Maria"]
            };

            Group group = new(employees);

            group.ToString().Should().Match("invalid");
        }
    }
}
