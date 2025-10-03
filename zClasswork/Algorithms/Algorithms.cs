namespace CompSci221 {
	public static class Algorithms {
		// There are many common operations we perform on arrays
		// Typically, these can be reduced to simple, reusable functions
		// These are some simple algorithms which can be useful in an program:

		// Let's say we want to know where in the array a given value is
		// In an array, an element exists at a given index (position)
		// Indices are always integers (int)
		// Here we ask for an array of doubles 'arr' and a double 'value' that we want to search for.
		private static int IndexOf(double[] arr, double value) {
			// In worse-case scenario, we will have to iterate over all elements in the array
			// We call this an 'exhaustive search'
			// To compare this algorithm to others, we'll use 'Big O' notation
			// We can't compare algorithm runtime in terms of seconds...
			// ...This would cause discrepancies between different machines!
			// Instead, we measure 'time' in terms of the length of data
			// We use the symbol 'N' to represent the length of a theoretical dataset
			// In Big-O terms, we say the 'worst-case' runtime complexity as a function of N
			// This algorithm- an exhaustive search- is O(N), also called 'linear' complexity
			// As the length of the array (N) grows, so does the amount of runtime

			// Iterate over every possible index in the array...
			for (int i = 0; i < arr.Length; i++) {
				// If the element at the i-th index is equal to the value we are looking for...
				if (arr[i] == value) {
					// ...Then return the index.
					return i;
				}

				// Should we return -1 here?
				// No- just because the value was not found at the i-th index, doesn't mean it won't be found at the (i+1)-th index.
				// We have to continue searching the array.
			}

			// If we reach this point, the value was not found in the array.
			// The method MUST return something, so we return -1.
			// This is a good value to return, because it is not a valid index.
			return -1;
		}

		// Another useful function is 'Contains'
		// It returns 'true' if the given array contains the given value, false otherwise
		private static bool Contains(double[] arr, double value) {
			// Both 'IndexOf' and 'Contains' are functionally identical
			// Since 'IndexOf' returns more useful information, we can consolidate 'Contains'
			// If 'IndexOf' returns -1, then this tells us that the element was not found
			if (IndexOf(arr, value) == -1) {
				// Return false, the exhaustive search did not yield an index
				return false;
			}

			// The exhaustive search did yield a valid index- return true
			return true;

			// Alternatively, we could write the following one-line solution:
			// return IndexOf(arr, value) != -1;
			// Since 'IndexOf' returns -1 if the element is not found, we can simply check if it's not -1
			// This function returns a bool, and the expression 'IndexOf(arr, value) != -1' is a boolean expression.
		}

		// Finding the minimum value in an array is very handy
		// However, it's *more* useful to know the index of the minimum value
		// We can easily get a value from an index (arr[index])...
		// ...But getting an index from a value requires an exhaustive search (O(N))
		// Therefore, it's better to get the index of the minimum value
		private static int MinIndex(double[] arr) {
			if (arr.Length == 0) {
				return -1;
			}

			// Start by guessing that the 0th element is the smallest one
			int minIndex = 0;

			// We start our for loop at 1 here. Why?
			// Answer: If we start i=0 and minIndex=0, then we'll end up checking if(arr[0]<arr[0])
			// This is the same as saying if(x<x) which is mathematically impossible
			// So, we start i=1 to avoid this redundancy
			// But wait! What if the array is only length 1, there is no 1-th element!
			// No problem- the conditional of a for loop is evaluated *before* execution
			// So, if i=1 and length=1, i<length will be false and the loop will never execute
			for (int i = 1; i < arr.Length; i++) {
				// If the i-th element is smaller than the minIndex-th element...
				// ...Then our new minIndex should be 'i' instead
				if (arr[i] < arr[minIndex]) {
					minIndex = i;
				}
			}

			return minIndex;
		}

		// Getting the index of the maximum index is almost identical to getting the min index.
		// The only difference is the comparison sign on line 106 (compared to line 88)
		private static int MaxIndex(double[] arr) {
			if (arr.Length == 0) {
				return -1;
			}

			int maxIndex = 0;

			for (int i = 1; i < arr.Length; i++) {
				if (arr[i] > arr[maxIndex]) {
					maxIndex = i;
				}
			}

			return maxIndex;
		}

		// Sorting an array is a very common operation
		// There are many different sorting algorithms, each with their own pros and cons
		// We'll implement a simple one here: Selection Sort
		// Selection Sort is an O(N^2) algorithm, which is not very efficient
		// This means that for every element in the array, we have to iterate over the entire array
		// In other words, for an array of length N, we have to iterate N times, N times (N^2)
		// The most optimal sorting algorithms are O(N log N), which is much faster
		// They're also much more complicated, so we'll stick with Selection Sort for now
		//
		// Note that this method is void
		// It's a common mistake to think that you have to return the array after sorting it
		// Remember, arrays are references, so any changes we make to the array will be reflected in the original
		// Therefore, it's redundant to return the array- the caller already has a reference to it!
		private static void SelectionSort(double[] arr) {
			// Iterate over every element in the array...
			// The 'i' index represents the index of the element we're currently looking at
			// You can think of it like our 'cursor' as we iterate over the array
			// Everything to the left of the cursor is sorted, everything to the right is unsorted
			for (int i = 0; i < arr.Length - 1; i++) {
				// We start by assuming that the i-th element is the smallest one
				// This is the same logic we used in 'MinIndex'
				// Even if it's not the smallest one, we'll find out soon enough and correct it
				int minIndex = i;

				// Iterate over every element to the right of the cursor...
				// This will look at every element to the right of 'i' to find the smallest one
				// Doing so will require a loop within a loop, which is why this algorithm is O(N^2)
				// We'll use the variable 'j' since 'i' is already taken
				// This can be confusing, but it's a common convention
				//
				// We start 'j' at 'i+1' because we don't want to compare the i-th element to itself
				// We wouldn't start it at 0 because we know that everything to the left of the cursor 'i' is sorted
				for (int j = i + 1; j < arr.Length; j++) {
					// If the j-th element is smaller than the minIndex-th element...
					if (arr[j] < arr[minIndex]) {
						// ...Then our new minIndex should be 'j' instead
						minIndex = j;
					}
				}

				// Once we 've found the smallest element to the right of the cursor...
				// ...We swap it with the element at the cursor
				// In other languages or earlier versions of C#, we'd swap two values like so:
				/*
				if (minIndex != i) {
					double temp = arr[i];
					arr[i] = arr[minIndex];
					arr[minIndex] = temp;
				}
				*/

				// C# 7.0 introduced a new syntax for swapping two values
				// It's called a 'tuple' swap, and it looks like this:
				// (a, b) = (b, a);
				// This is a very convenient syntax, and it's also very efficient
				if (minIndex != i) {
					(arr[minIndex], arr[i]) = (arr[i], arr[minIndex]);
				}
			}
		}

		// Insertion sort is another simple O(N^2) sorting algorithm
		// It's conceptually similar to selection sort, but works a bit differently
		// Instead of finding the smallest element and swapping it with the cursor...
		// ...We take the element at the cursor and insert it into its correct position in the sorted portion of the array
		private static void InsertionSort(double[] arr) {
			for (int i = 1; i < arr.Length; i++) {
				int j = i;
				double temp = arr[i];

				while (j > 0 && temp < arr[j - 1]) {
					arr[j] = arr[j - 1];
					j--;
				}

				arr[j] = temp;
			}
		}


		private static void Main() {
			// Remember- the algorithms in this demo work for other types, too!
			// You'll have to change their signatures to support the type- but they're logically identical.
			// In this demo we're using an array of doubles, but you could easily use arrays of ints, floats, etc.
			double[] nums = { 7.6, 9.5, 6.2, 3.6, 2.8, 5.4, 1.2, 8.9, 8.3, 5.6 };

			Console.WriteLine("Array:");
			Console.WriteLine($"[{string.Join(", ", nums)}]");
			Console.WriteLine();

			Console.WriteLine($"Index of 6.2:\t{IndexOf(nums, 6.2)}");
			Console.WriteLine($"Index of 4.4:\t{IndexOf(nums, 4.4)}");
			Console.WriteLine($"Contains 2.8:\t{Contains(nums, 2.8)}");
			Console.WriteLine($"Contains 8.2:\t{Contains(nums, 8.2)}");
			Console.WriteLine($"Min Index:\t{MinIndex(nums)}");
			Console.WriteLine($"Max Index:\t{MaxIndex(nums)}");
			Console.WriteLine($"Min Value:\t{nums[MinIndex(nums)]}");
			Console.WriteLine($"Max Value:\t{nums[MaxIndex(nums)]}");
			Console.WriteLine();

			Console.WriteLine("Unsorted Array:");
			Console.WriteLine($"[{string.Join(", ", nums)}]");
			SelectionSort(nums);
			Console.WriteLine("Sorted Array:");
			Console.WriteLine($"[{string.Join(", ", nums)}]");
		}
	}
}
// I had to download this file due to me missing my class on 9/30/2025 due to a hospital visit