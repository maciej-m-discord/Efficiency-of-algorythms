using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Efficiency_of_algorythms;

internal class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        Console.WriteLine(summary);
    }
}

[MemoryDiagnoser]
public class Benchmarks
{
    private int[] _arrRandom = [];
    private int[] _arrSorted = [];
    private int[] _arrReversed = [];
    private int[] _arrNearlySorted = [];
    private int[] _arrFewUnique = [];

    private const int Size = 500000;
    private const int MinVal = 0;
    private const int MaxVal = 1000000;

    [GlobalSetup]
    public void Setup()
    {
        _arrRandom = Generators.GenerateRandom(Size, MinVal, MaxVal);
        _arrSorted = Generators.GenerateSorted(Size, MinVal, MaxVal);
        _arrReversed = Generators.GenerateReversed(Size, MinVal, MaxVal);
        _arrNearlySorted = Generators.GenerateNearlySorted(Size, MinVal, MaxVal);
        _arrFewUnique = Generators.GenerateRandom(Size, MinVal, (int)Math.Sqrt(MaxVal));
    }

    //InsertionSort ============================================================
    [Benchmark]
    public void InsertionSortRandom() { SortingAlgorythms.InsertionSort((int[])_arrRandom.Clone()); }

    [Benchmark]
    public void InsertionSortSorted() { SortingAlgorythms.InsertionSort((int[])_arrSorted.Clone()); }

    [Benchmark]
    public void InsertionSortReversed() { SortingAlgorythms.InsertionSort((int[])_arrReversed.Clone()); }

    [Benchmark]
    public void InsertionSortNearlySorted() { SortingAlgorythms.InsertionSort((int[])_arrNearlySorted.Clone()); }

    [Benchmark]
    public void InsertionSortFewUnique() { SortingAlgorythms.InsertionSort((int[])_arrFewUnique.Clone()); }

    // MergeSort ===============================================================
    [Benchmark]
    public void MergeSortRandom() { SortingAlgorythms.MergeSort((int[])_arrRandom.Clone(), 0, _arrRandom.Length - 1); }

    [Benchmark]
    public void MergeSortSorted() { SortingAlgorythms.MergeSort((int[])_arrSorted.Clone(), 0, _arrSorted.Length - 1); }

    [Benchmark]
    public void MergeSortReversed() { SortingAlgorythms.MergeSort((int[])_arrReversed.Clone(), 0, _arrReversed.Length - 1); }

    [Benchmark]
    public void MergeSortNearlySorted() { SortingAlgorythms.MergeSort((int[])_arrNearlySorted.Clone(), 0, _arrNearlySorted.Length - 1); }

    [Benchmark]
    public void MergeSortFewUnique() { SortingAlgorythms.MergeSort((int[])_arrFewUnique.Clone(), 0, _arrFewUnique.Length - 1); }

    // QuickSort ===============================================================
    [Benchmark]
    public void QuickSortRandom() { SortingAlgorythms.QuickSort((int[])_arrRandom.Clone(), 0, _arrRandom.Length - 1); }

    [Benchmark]
    public void QuickSortSorted() { SortingAlgorythms.QuickSort((int[])_arrSorted.Clone(), 0, _arrSorted.Length - 1); }

    [Benchmark]
    public void QuickSortReversed() { SortingAlgorythms.QuickSort((int[])_arrReversed.Clone(), 0, _arrReversed.Length - 1); }

    [Benchmark]
    public void QuickSortNearlySorted() { SortingAlgorythms.QuickSort((int[])_arrNearlySorted.Clone(), 0, _arrNearlySorted.Length - 1); }

    [Benchmark]
    public void QuickSortFewUnique() { SortingAlgorythms.QuickSort((int[])_arrFewUnique.Clone(), 0, _arrFewUnique.Length - 1); }

    [GlobalCleanup]
    public void Cleanup()
    {
        _arrRandom = [];
        _arrSorted = [];
        _arrReversed = [];
        _arrNearlySorted = [];
        _arrFewUnique = [];
    }
}
