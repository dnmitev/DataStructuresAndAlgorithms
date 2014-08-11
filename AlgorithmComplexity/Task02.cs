// What is the expected running time of the following C# code? Explain why.
// Assume the input matrix has size of n * m.

long CalcCount(int[, ] matrix)
{
	long count = 0;
	for (int row = 0; row < matrix.GetLength(0); row++)
	{
		if (matrix[row, 0] % 2 == 0)
		{
			for (int col = 0; col < matrix.GetLength(1); col++)
			{
				if (matrix[row, col] > 0)
				{
					count++;
				}
			}
		}
	}

	return count;
}

// Explanation
// The outside "for" loop is executed axactly n-timees /considering n stands for the row size of the array/. The inner "for" loop is executed
// just when the first column member of each row is even. So if a constant k, whick stands for the rows starting with an even member, the complexity
// should be something like (n - k + m * k). In worst case where every row starts with an even member the k is up to n and the complexity can be
// considered as (n - n + m * n);

// Complexity: O(m * n)