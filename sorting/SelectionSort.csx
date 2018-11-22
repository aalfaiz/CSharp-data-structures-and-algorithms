public static class SelectionSort
{
    private static void Swap<T>(T[] array, int first, int second)
    {
        T temp = array[first];
        array[first] = array[second];
        array[second] = temp;
    }

    public static void Sort<T>(T[] array, bool isAscending = true) where T : IComparable
    {
        for(int i=0; i<array.Length-1; i++)
        {
            int minMaxIndex = i;
            T minMaxValue = array[i];
            for(int j = i + 1; j<array.Length; j++)
            {
                if(isAscending && array[j].CompareTo(minMaxValue) < 0 || !isAscending && array[j].CompareTo(minMaxValue) > 0)
                {
                    minMaxIndex = j;
                    minMaxValue = array[j];
                }
            }
            Swap(array, i, minMaxIndex);        
        }
    }
}

int[] integerValues = { -11, 12, -42, 0, 1, 90, 68, 6, -9 }; 
SelectionSort.Sort(integerValues, false); 
Console.WriteLine(string.Join(" | ", integerValues)); 