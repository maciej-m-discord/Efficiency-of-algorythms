namespace Efficiency_of_algorythms;

public abstract class SortingAlgorythms
{
    internal static int[] InsertionSort(int[] arr)
    {
        var n = arr.Length;
        for (var i = 1; i < n; i++) {
            var key = arr[i];
            var j = i - 1;
            while (j >= 0 && arr[j] > key) {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
        return arr;
    }

    internal static int[] MergeSort(int[] arr, int left, int right)
    {
        if (left >= right) return arr;
        // Find the middle point
        var middle = left + (right - left) / 2;

        // Sort first and second halves
        MergeSort(arr, left, middle);
        MergeSort(arr, middle + 1, right);

        // Merge the sorted halves
        Merge(arr, left, middle, right);
        return arr;
    }
    private static void Merge(int[] arr, int l, int m, int r)
    {
        var partOne = m - l + 1;
        var partTwo = r - m;

        var left = new int[partOne];
        var right = new int[partTwo];
        int i, j;

        for (i = 0; i < partOne; ++i) left[i] = arr[l + i];
        for (j = 0; j < partTwo; ++j) right[j] = arr[m + 1 + j];

        i = 0;
        j = 0;

        var k = l;
        while (i < partOne && j < partTwo)
        {
            if (left[i] <= right[j])
            {
                arr[k] = left[i];
                i++;
            }
            else
            {
                arr[k] = right[j];
                j++;
            }

            k++;
        }

        while (i < partOne)
        {
            arr[k++] = left[i++];
        }

        while (j < partTwo)
        {
            arr[k++] = right[j++];
        }
    }

    internal static int[] QuickSort(int[] arr, int low, int high)
    {
        if (low >= high) return arr;

        var pi = Partition(arr, low, high);

        QuickSort(arr, low, pi - 1);
        QuickSort(arr, pi + 1, high);
        return arr;
    }
    private static int Partition(int[] arr, int low, int high)
    {
        var pivot = arr[high];

        var i = low - 1;

        for (var j = low; j <= high - 1; j++)
        {
            if (arr[j] >= pivot) continue;
            i++;
            Swap(arr, i, j);
        }
        Swap(arr, i + 1, high);
        return i + 1;
    }
    private static void Swap(int[] arr, int i, int j)
    {
        if (i == j) return;

        var temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}