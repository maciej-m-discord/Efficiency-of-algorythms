namespace Efficiency_of_algorythms;

public abstract class Generators
{
    internal static int[] GenerateRandom(int size, int minVal, int maxVal)
    {
        var random = new Random();
        var a = new int[size];
        for (int i = 0; i < size; i++)
        {
            a[i] = random.Next(minVal, maxVal);
        }
        return a;
    }
    internal static int[] GenerateSorted(int size, int minVal, int maxVal)
    {
        var a = GenerateRandom(size, minVal, maxVal);
        Array.Sort(a);
        return a;
    }
    internal static int[] GenerateReversed(int size, int minVal, int maxVal)
    {
        var a = GenerateSorted(size, minVal, maxVal);
        Array.Reverse(a);
        return a;
    }
    internal static int[] GenerateNearlySorted(int size, int minVal, int maxVal)
    {
        var random = new Random();
        var a = GenerateRandom(size, minVal, maxVal);
        Array.Sort(a);
        var randomized = (int)Math.Sqrt(size);
        var n = random.Next(1, randomized);
        for (var i = 0; i < n; i++)
        {
            var j = random.Next(0, size - 1);
            a[j] ^= a[j + 1];
            a[j + 1] ^= a[j];
            a[j] ^= a[j + 1];
        }
        return a;
    }
}