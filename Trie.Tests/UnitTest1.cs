using Trie;

namespace Trie.Tests;

public class UnitTest1
{
    [Fact]
    public void Trie_InsertAndStartsWith_ShouldReturnCorrectValues()
    {
        // Arrange
        var trie = new Triee();
        trie.Insert("app");
        trie.Insert("apple");
        trie.Insert("orange");

        // Act

        var startsWithA = trie.StartsWith("a");
        var startsWithApp = trie.StartsWith("app");
        var startsWithApple = trie.StartsWith("apple");
        var startsWithOrange = trie.StartsWith("orange");
        var startsWithOr = trie.StartsWith("or");

        var startsWithPotato = trie.StartsWith("potato");

        // Assert
        Assert.True(startsWithA);
        Assert.True(startsWithApp);
        Assert.True(startsWithApple);
        Assert.True(startsWithOrange);
        Assert.True(startsWithOr);

        Assert.False(startsWithPotato);
    }

        [Fact]
    public void Trie_InsertAndContains_ShouldReturnCorrectValues()
    {
        // Arrange
        var trie = new Triee();
        trie.Insert("app");
        trie.Insert("apple");
        trie.Insert("orange");

        // Act

        var startsWithA = trie.StartsWith("a");
        var startsWithApp = trie.StartsWith("app");
        var startsWithApple = trie.StartsWith("apple");
        var startsWithOrange = trie.StartsWith("orange");
        var startsWithOr = trie.StartsWith("or");
        var startsWithPotato = trie.StartsWith("potato");

        // Assert
        Assert.False(startsWithA);
        Assert.True(startsWithApp);
        Assert.True(startsWithApple);
        Assert.True(startsWithOrange);
        Assert.False(startsWithOr);
        Assert.False(startsWithPotato);
    }
}