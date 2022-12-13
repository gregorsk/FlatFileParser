namespace FlatFileParser.Test;

[TestFixture]
public class FlatFileParserTests
{
    [Test]
    public void ParseAsync_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var flatFileParser = new FlatFileParser<TestRecord>();
        Stream input = null!;

        // Act

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () => { await flatFileParser.ParseAsync(input); });
    }

    [Test]
    public void Configure_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var flatFileParser = new FlatFileParser<TestRecord>();
        Action<Configurator<TestRecord>> value = (_) => { };

        // Act
        flatFileParser.Configure(value);

        // Assert
        Assert.That(flatFileParser, !Is.Null);
    }
}
