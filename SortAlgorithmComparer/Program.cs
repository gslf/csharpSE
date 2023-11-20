using System.Collections.Generic;
using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();
Console.WriteLine("------------------------------------------------");
Console.WriteLine("Test all algorithms with lists of 10000 elements");

List<string> testlist = SortAlgorithmComparer.Comparer.GenerateTestList(10000);
List<string> testlist2 = new List<string>(testlist);
List<string> testlist3 = new List<string>(testlist);
List<string> testlist4 = new List<string>(testlist);


// Test Bubble Sorter
Console.WriteLine("Start Bubble Sorter Test . . .");
stopwatch.Start();
Algorithm.BubbleSort.BubbleSort<string>.Sort(testlist);
stopwatch.Stop();
Console.WriteLine($"Bubble Sort timing: {stopwatch.ElapsedMilliseconds} ms");

// Test Insertion Sort
Console.WriteLine("Start Insertion Sorter Test . . .");
stopwatch.Restart();
Algorithm.InsertionSort.InsertionSort<string>.Sort(testlist2);
stopwatch.Stop();
Console.WriteLine($"Insetion Sort timing: {stopwatch.ElapsedMilliseconds} ms");

// Test Merge Sort
Console.WriteLine("Start Merge Sorter Test . . .");
stopwatch.Restart();
Algorithm.MergeSort.MergeSort<string>.Sort(testlist3);
stopwatch.Stop();
Console.WriteLine($"Merge Sort timing: {stopwatch.ElapsedMilliseconds} ms");

// Test Quick Sort
Console.WriteLine("Start Quick Sorter Test . . .");
stopwatch.Restart();
Algorithm.QuickSort.QuickSort<string>.Sort(testlist4);
stopwatch.Stop();
Console.WriteLine($"Quick Sort timing: {stopwatch.ElapsedMilliseconds} ms");

//////////////////////////////////////////////////////////////

Console.WriteLine("");
Console.WriteLine("--------------------------------------------------------------");
Console.WriteLine("Test divide & conquer algoritms with lists of 1000000 elements");
List<string> testlist5 = SortAlgorithmComparer.Comparer.GenerateTestList(1000000);
List<string> testlist6 = new List<string>(testlist5);

// Test Merge Sort
Console.WriteLine("Start Merge Sorter Test . . .");
stopwatch.Restart();
Algorithm.MergeSort.MergeSort<string>.Sort(testlist5);
stopwatch.Stop();
Console.WriteLine($"Merge Sort timing: {stopwatch.ElapsedMilliseconds} ms");

// Test Quick Sort
Console.WriteLine("Start Quick Sorter Test . . .");
stopwatch.Restart();
Algorithm.QuickSort.QuickSort<string>.Sort(testlist6);
stopwatch.Stop();
Console.WriteLine($"Quick Sort timing: {stopwatch.ElapsedMilliseconds} ms");
