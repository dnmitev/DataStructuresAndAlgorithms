// * What is the expected running time of the following C# code? Explain why.
// Assume the input matrix has size of n * m.

long CalcSum(int[, ] matrix, int row)
{
	long sum = 0;

	for (int col = 0; col < matrix.GetLength(0); col++)
	{
		sum += matrix[row, col];
	}

	if (row + 1 < matrix.GetLength(1))
	{
		sum += CalcSum(matrix, row + 1);
	}

	return sum;
}

Console.WriteLine(CalcSum(matrix, 0));

// Explanation
// The "for" loop will be executed exactly n-times. In the best scenario the recursive call of CalcSum() won't be called if in the fisrt call (row + 1) is not
// less than m-parameter. All things considered, it would probably be invoked and in this way the complexity can be considered as (n * (m - n)), where m >= n.
// So the complexity can be considered as quadratic.

// Complexity: O(n * m)