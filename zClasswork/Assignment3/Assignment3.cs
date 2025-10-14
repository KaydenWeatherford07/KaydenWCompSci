public static class Assignment3 {
	private static int Range(int[] array) {
		int max = array[0];
		int min = array[0];

		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] > max)
				max = array[i];
			if (array[i] < min)
				min = array[i];
		}

		return max - min;
	}

	private static int Frequency(int[] array, int key) {
		int count = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == key)
				count++;
		}
		
		return count;
	}

	private static bool IsSorted(int[] array)
	{
		if (array.Length == 1) return true;
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i] < array[i - 1])
				return false;
		}
		return true;
	}

	private static void Reverse(int[] array)
	{
		int l = 0, r = array.Length - 1;
		while (l < r)
		{
			(array[l], array[r]) = (array[r], array[l]);
			l++;
			r--;
		}
	}

	private static void RotateRight(int[] array) {
		if (array.Length > 1)
		{
			int temp = array[array.Length - 1];
            		for (int i = array.Length - 1; i > 0; i--)
            		{
            			array[i] = array[i - 1];
            		}
            		array[0] = temp;
		}
	}

	private static void GnomeSort(int[] array) {
		int pos = 1;
		while (pos < array.Length)
		{
			if (pos == 0 || array[pos] >= array[pos - 1])
			{
				pos++;
			}
			else
			{
				(array[pos], array[pos-1]) = (array[pos-1], array[pos]);
				pos--;
			}
		}
	}

	private static int[] Merge(int[] a, int[] b) {
		if (a.Length == 0) return b;
		if (b.Length == 0) return a;
		
		int[] c = new int[a.Length + b.Length];
		
		// a [1, 3, 5], b [2, 4, 6]
		for (int i = 0; i < a.Length; i++)
		{
			c[i] = a[i];
		}

		for (int i = a.Length; i < a.Length + b.Length; i++)
		{
			c[i] = b[i - a.Length];
		}
		
		return c;
	}

	private static bool HasSubsequence(int[] array, int[] sequence) {
		if (sequence.Length == 0) return true;
		int n = array.Length;
		int m = sequence.Length;
		
		for (int i = 0; i < n - (m-1); i++)
		{
			bool found = true;
			for (int j = 0; j < m; j++)
			{
				if (array[i + j] != sequence[j])
				{
					found = false;
					break;
				}
			}
			if (found) return true;
		}
		return false;
	}

	#region DO NOT MODIFY
	private static void Main() {
		Console.WriteLine("Range Tests:");
		Console.WriteLine(Range([1, 2, 3, 4, 5]) == 4);
		Console.WriteLine(Range([1, 1, 1, 1, 1, 1, 1]) == 0);
		Console.WriteLine(Range([-10, 0, 10, 20, 30]) == 40);
		Console.WriteLine(Range([5]) == 0);
		Console.WriteLine(Range([8, 6, 4, 2, 0, 7, 3, 5, 1]) == 8);

		Console.WriteLine("\nFrequency Tests:");
		Console.WriteLine(Frequency([1, 2, 3], 2) == 1);
		Console.WriteLine(Frequency([1, 2, 2, 3, 3, 3], 2) == 2);
		Console.WriteLine(Frequency([4, 8, 12, 16], 5) == 0);
		Console.WriteLine(Frequency([4], -4) == 0);
		Console.WriteLine(Frequency([7, 7, 7, 7], 7) == 4);

		Console.WriteLine("\nIs Sorted Tests:");
		Console.WriteLine(IsSorted([1, 2, 3, 4, 5]) == true);
		Console.WriteLine(IsSorted([5, 4, 3, 2, 1]) == false);
		Console.WriteLine(IsSorted([1, 1, 1, 1]) == true);
		Console.WriteLine(IsSorted([8]) == true);
		Console.WriteLine(IsSorted([1, 3, 2, 4, 5]) == false);

		Console.WriteLine("\nReverse Tests:");
		int[] arr1 = [1, 2, 3, 4, 5];
		Reverse(arr1);
		Console.WriteLine(Enumerable.SequenceEqual(arr1, [5, 4, 3, 2, 1]));
		int[] arr2 = [1, 2, 3, 4];
		Reverse(arr2);
		Console.WriteLine(Enumerable.SequenceEqual(arr2, [4, 3, 2, 1]));
		int[] arr3 = [1];
		Reverse(arr3);
		Console.WriteLine(Enumerable.SequenceEqual(arr3, [1]));
		int[] arr4 = [];
		Reverse(arr4);
		Console.WriteLine(Enumerable.SequenceEqual(arr4, []));
		int[] arr5 = [1, 2];
		Reverse(arr5);
		Console.WriteLine(Enumerable.SequenceEqual(arr5, [2, 1]));

		Console.WriteLine("\nRotate Right Tests:");
		int[] arr6 = [1, 2, 3, 4, 5];
		RotateRight(arr6);
		Console.WriteLine(Enumerable.SequenceEqual(arr6, [5, 1, 2, 3, 4]));
		int[] arr7 = [1, 2, 3, 4];
		RotateRight(arr7);
		Console.WriteLine(Enumerable.SequenceEqual(arr7, [4, 1, 2, 3]));
		int[] arr8 = [1];
		RotateRight(arr8);
		Console.WriteLine(Enumerable.SequenceEqual(arr8, [1]));
		int[] arr9 = [1, 2, 2, 3, 3, 3];
		RotateRight(arr9);
		Console.WriteLine(Enumerable.SequenceEqual(arr9, [3, 1, 2, 2, 3, 3]));
		int[] arr10 = [];
		RotateRight(arr10);
		Console.WriteLine(Enumerable.SequenceEqual(arr10, []));

		Console.WriteLine("\nGnome Sort Tests:");
		int[] arr11 = [5, 3, 2, 4, 1];
		GnomeSort(arr11);
		Console.WriteLine(Enumerable.SequenceEqual(arr11, [1, 2, 3, 4, 5]));
		int[] arr12 = [1, 2, 3, 4, 5];
		GnomeSort(arr12);
		Console.WriteLine(Enumerable.SequenceEqual(arr12, [1, 2, 3, 4, 5]));
		int[] arr13 = [3, 3, 2, 1, 2];
		GnomeSort(arr13);
		Console.WriteLine(Enumerable.SequenceEqual(arr13, [1, 2, 2, 3, 3]));
		int[] arr14 = [1];
		GnomeSort(arr14);
		Console.WriteLine(Enumerable.SequenceEqual(arr14, [1]));
		int[] arr15 = [];
		GnomeSort(arr15);
		Console.WriteLine(Enumerable.SequenceEqual(arr15, []));

		Console.WriteLine("\nMerge Tests:");
		int[] merged1 = Merge([1, 3, 5], [2, 4, 6]);
		Console.WriteLine(Enumerable.SequenceEqual(merged1, [1, 3, 5, 2, 4, 6]));
		int[] merged2 = Merge([1, 2, 3], [4, 5, 6, 7, 8]);
		Console.WriteLine(Enumerable.SequenceEqual(merged2, [1, 2, 3, 4, 5, 6, 7, 8]));
		int[] merged3 = Merge([], [1, 2, 3]);
		Console.WriteLine(Enumerable.SequenceEqual(merged3, [1, 2, 3]));
		int[] merged4 = Merge([1, 2, 3], []);
		Console.WriteLine(Enumerable.SequenceEqual(merged4, [1, 2, 3]));
		int[] merged5 = Merge([], [1, 2, 3, 4, 5]);
		Console.WriteLine(Enumerable.SequenceEqual(merged5, [1, 2, 3, 4, 5]));

		Console.WriteLine("\nHas Subsequence Tests:");
		Console.WriteLine(HasSubsequence([1, 2, 3, 4, 5], [2, 3]) == true);
		Console.WriteLine(HasSubsequence([1, 2, 3, 4, 5], [3, 5]) == false);
		Console.WriteLine(HasSubsequence([1, 2, 3, 4, 5], [3]) == true);
		Console.WriteLine(HasSubsequence([1, 2, 3, 4, 5], [6]) == false);
		Console.WriteLine(HasSubsequence([1, 2, 3, 4, 5], [1, 2, 3, 4, 5]) == true);
	}
	#endregion
}