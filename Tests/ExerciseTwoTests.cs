using Exercises.ExerciseOne;
using Exercises.ExerciseTwo;
using Microsoft.VisualBasic;

namespace Tests;

public class ExerciseTwoTests
{
    [Fact]
    public void BinarySearchTree_Insert_ShouldDistributeNodesCorrectly()
    {
        // Arrange
        var bst = new BinarySearchTree();

        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(7);

        // Act

        // Assert
        Assert.True(bst.Root is not null && bst.Root.Value == 5);
        Assert.True(bst.Root.Left is not null && bst.Root.Left.Value == 3);
        Assert.True(bst.Root.Left.Left is not null && bst.Root.Left.Left.Value == 1);
        Assert.True(bst.Root.Left.Right is not null && bst.Root.Left.Right.Value == 4);
        Assert.True(bst.Root.Right is not null && bst.Root.Right.Value == 8);
        Assert.True(bst.Root.Right.Left is not null && bst.Root.Right.Left.Value == 7);
    }

    [Fact]
    public void BinarySearchTree_InsertAndContains_ShouldReturnCorrectValues()
    {
        // Arrange
        var bst = new BinarySearchTree();

        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);

        // Act

        // Assert
        Assert.True(bst.Search(5));
        Assert.True(bst.Search(3));
        Assert.True(bst.Search(1));
        Assert.False(bst.Search(999));
    }

    [Fact]
    public void BinarySearchTree_DeleteAndContains_ShouldReturnCorrectValues()
    {
        // Arrange
        var bst = new BinarySearchTree();

        bst.Insert(5);
        bst.Insert(1);
        bst.Insert(6);

        // Act

        // Assert
        Assert.True(bst.Root is not null && bst.Root.Value == 5);
        Assert.True(bst.Search(5));
        Assert.True(bst.Search(1));
        Assert.True(bst.Search(6));

        bst.Delete(1);

        Assert.True(bst.Root.Left is null);
        Assert.True(bst.Root.Right is not null && bst.Root.Right.Value == 6);

        bst.Delete(6);

        Assert.True(bst.Root.Left is null);
        Assert.True(bst.Root.Right is null);

        bst.Delete(5);

        Assert.True(bst.Root is null);
    }
}