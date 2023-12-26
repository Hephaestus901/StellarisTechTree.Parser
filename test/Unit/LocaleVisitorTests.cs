using FluentAssertions;
using StellarisTechTree.Infrastructure.Parsers;
using StellarisTechTree.Infrastructure.Services.ContextService;
using Xunit;

namespace Unit;

public class LocaleVisitorTests
{
    [Fact]
    public void VisitLocaleFile_ShouldNotThrow()
    {
        // Arrange
        const string filePath = "test_data.yml";
        var context = new ContextService().GetLocaleFileContext(filePath);
        var visitor = new LocaleVisitor(LocaleTopic.Names);

        // Act
        var result = () => visitor.VisitLocaleFile(context);

        // Assert
        result.Should().NotThrow();
    }

    [Fact]
    public void VisitLocaleFile_ShouldParseCorrectly()
    {
        // Arrange
        const string filePath = "test_data.yml";
        var context = new ContextService().GetLocaleFileContext(filePath);
        var visitor = new LocaleVisitor(LocaleTopic.Names);

        // Act
        var result = visitor.VisitLocaleFile(context);

        // Assert
        result.Should().Contain(x => x.Key == "tech_bio_reactor");
    }
}