using Exercises.ExerciseTwo;
using Exercises.ExerciseThree;
using Exercises.ExerciseOne;

BasicExerciseOneTest();
BasicExerciseTwoTest();
BasicExerciseThreeTest();

void BasicExerciseOneTest()
{
    var prefixTree = new PrefixTree();

    prefixTree.Insert("apple");
    prefixTree.Insert("app");
    prefixTree.Insert("orange");

    Console.WriteLine(prefixTree.Contains("apple")); // true
    Console.WriteLine(prefixTree.Contains("app")); // true
    Console.WriteLine(prefixTree.Contains("orange")); // true
    Console.WriteLine(prefixTree.Contains("potato")); // false

    Console.WriteLine(prefixTree.StartsWith("a")); // true
    Console.WriteLine(prefixTree.Contains("p")); // false
}

void BasicExerciseTwoTest()
{
    // Binary Search Tree example
    BinarySearchTree bst = new BinarySearchTree();
    bst.Insert(5);
    bst.Insert(3);
    bst.Insert(2);
    bst.Insert(10);
    bst.Insert(8);
    bst.Insert(16);

    bst.Delete(8);

    // false, because 8 got deleted
    Console.WriteLine(bst.Search(8));

    // true, because 8 is inside the tree
    Console.WriteLine(bst.Search(3));

    // The path of value 2 in the tree is - (5)>(3)>(2)
    Console.WriteLine(bst.Path(2));
}

void BasicExerciseThreeTest()
{
    var dnaPrefixTree = new DnaPrefixTree();

    dnaPrefixTree.InsertDnaFragment("ACCGT");
    dnaPrefixTree.InsertDnaFragment("GCCAT");

    dnaPrefixTree.InsertDnaFragment("AACGTT");
    dnaPrefixTree.InsertDnaFragment("AC");


    var nodesByDepth = dnaPrefixTree.GetNodesByDepth(4);

    var contigs = dnaPrefixTree.GetContigs();

    var adjacencyList = dnaPrefixTree.CreateAdjacencyList();
}

