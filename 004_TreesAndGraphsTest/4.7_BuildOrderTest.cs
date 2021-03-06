using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _004_TreesAndGraphsTest
{
    [TestClass]
    public class Question_4_7_Test
    {
        [DataTestMethod]
        [DataRow(0, new string[] { "a", "b", "c", "d", "e", "f" }, new string[] { "e", "f", "b", "a", "d", "c" })]
        [DataRow(1, new string[] { "a", "b", "c", "d", "e", "f" }, new string[] { "e", "f", "a", "b", "d", "c" })]
        [DataRow(2, new string[] { "a", "b", "c", "d" }, new string[] { "d", "a", "b", "c" })]
        [DataRow(3, new string[] { "a", "b", "c", "d" }, null)]
        [DataRow(4, new string[] { "a", "b", "c", "d", "e", "f", "g" }, new string[] { "d", "f", "g", "b", "c", "a", "e" })]
        public void GetProjectsBuildOrderTest(int testCaseIndex, string[] projects, string[] expectedBuildOrder)
        {
            // Arrange
            var dependencies = GetTestDependencies(testCaseIndex);

            // Act
            var resultBuildOrder = Question_4_7.GetProjectsBuildOrder(projects, dependencies);

            // Assert
            if (expectedBuildOrder == null)
            {
                Assert.IsNull(resultBuildOrder, "Invalid build order is not detected.");
            }
            else
            {
                Assert.AreEqual(expectedBuildOrder.Length, resultBuildOrder.Count, "Result count mismatch.");
                for (int i = 0; i < expectedBuildOrder.Length; i++)
                {
                    Assert.AreEqual(expectedBuildOrder[i], resultBuildOrder[i], $"Project does not match at sequence {i}.");
                }
            }
        }

        private (string, string)[] GetTestDependencies(int testCaseIndex)
        {
            var testCases = new List<(string, string)[]>()
            {
                // Test Case 0
                new (string, string)[] { ("a", "d"), ("f", "b"), ("b", "d"), ("f", "a"), ("d", "c") },
                // Test Case 1
                new (string, string)[] { ("a", "d"), ("f", "b"), ("b", "d"), ("f", "a"), ("d", "c"), ("a", "b") },
                // Test Case 2
                new (string, string)[] { ("d", "a"), ("a", "c"), ("b", "c"), ("a", "b") },
                // Test Case 3
                new (string, string)[] { ("d", "a"), ("a", "b"), ("b", "c"), ("c", "a") },
                // Test Case 4
                new (string, string)[] { ("d", "g"), ("f", "a"), ("f", "b"), ("f", "c"), ("b", "a"), ("c", "a"), ("a", "e"), ("b", "e") }
            };
            return testCases[testCaseIndex];
        }
    }
}
