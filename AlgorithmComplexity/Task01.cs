// What is the expected running time of the following C# code? Explain why. Assume the array's size is n.

long Compute(int[] arr)
{
	long count = 0;
	for (int i = 0; i < arr.Length; i++)
	{
		int start = 0;
		int end = arr.Length - 1;
		while (start < end)
		{
			if (arr[start] < arr[end])
			{
				start++;
				count++;
			}
			else
			{
				end--;
			}
		}
	}

	return count;
}

// Explanation
// The "for" loop will run n-times if, n is considered as arr.length. Otherwise, the "while" loop will be executed also
// n-times in worst case. Consider a sorted array [1,2,3,4,5,6,7,8,9,10]. Outside loop is executed exactly arr.length times
// but in this case the inner loop will be executed also exactly n-times. So in this manner the complexity is: O(n*n).

// Complexity: O(n * n)