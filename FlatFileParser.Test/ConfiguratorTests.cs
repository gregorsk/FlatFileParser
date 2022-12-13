using FlatFileParser;
using NUnit.Framework;
using System;

namespace FlatFileParser.Test
{
    [TestFixture]
    public class ConfiguratorTests
    {  
        [Test]
        public void AddColumn_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var configurator = new Configurator<TestRecord>();
            string name = "name";
            int length = 10;
            Action<string, TestRecord> assignFunc = (s, t) => t.Id = 1;

            // Act
            var result = configurator.AddColumn(
                name,
                length,
                assignFunc);

            // Assert
            Assert.That(result.Columns, !Is.Null);
            Assert.That(result.Columns.Count, Is.EqualTo(1));
            Assert.That(result.Columns[0].Name, Is.EqualTo(name));
            Assert.That(result.Columns[0].Length, Is.EqualTo(length));
            Assert.That(result.Columns[0].AssignFunc, Is.EqualTo(assignFunc));
        }
    }
}
