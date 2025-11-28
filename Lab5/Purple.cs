using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0) answer[i]++;
                }
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int minim = int.MaxValue;
                int minind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minim)
                    { 
                        minim = matrix[i, j];
                        minind = j;
                    }

                }
                int[] tmp = new int[matrix.GetLength(1)];
                tmp[0] = minim;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (j <= minind) tmp[j] = matrix[i, j - 1];
                    else tmp[j] = matrix[i, j];
                    // System.Console.Write($"{tmp[j]}, ");
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = tmp[j];
                    // System.Console.Write($"{tmp[j]}, ");
                }
                // System.Console.WriteLine();

            }

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxim = int.MinValue;
                int maxind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxim)
                    { 
                        maxim = matrix[i, j];
                        maxind = j;
                    }
                }
                int[] tmp = new int[matrix.GetLength(1) + 1];
                tmp[maxind + 1] = maxim;
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (j <= maxind) tmp[j] = matrix[i, j];
                    else if (j == maxind) continue;
                    else tmp[j] = matrix[i, j - 1];
                    // System.Console.Write($"{tmp[j]}, ");
                }

                for (int j = 0; j < matrix.GetLength(1) + 1; j++)
                {
                    answer[i, j] = tmp[j];
                    // System.Console.Write($"{tmp[j]}, ");
                }
                // System.Console.WriteLine();
            }

            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxim = int.MinValue;
                int maxind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxim)
                    { 
                        maxim = matrix[i, j];
                        maxind = j;
                    }
                }
                int summ = 0;
                for (int j = maxind; j < matrix.GetLength(1); j++)
                {
                    if (j > maxind && matrix[i, j] > 0) summ += matrix[i, j];
                }
                if (summ != 0)
                {
                    int sr = summ / (matrix.GetLength(1) - maxind - 1);
                    for (int j = 0; j < maxind; j++)
                    {
                        if (matrix[i, j] < 0) matrix[i, j] = sr;

                    }
                }
                // for (int j = 0; j < matrix.GetLength(1); j++)
                // {
                //     System.Console.Write($"{matrix[i, j]}, ");
                // }
                // System.Console.WriteLine();
            }


            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int[] maxims = new int[matrix.GetLength(0)];
            if (k < matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int maxim = int.MinValue;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > maxim)
                        { 
                            maxim = matrix[i, j];
                        }
                    }
                    maxims[i] = maxim;
                }
                // for (int i = 0; i < maxims.GetLength(0); i ++)
                // {
                //     System.Console.Write($"{maxims[i]}, ");
                // }
                // System.Console.WriteLine();
                int tmp = matrix.GetLength(0) - 1;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, k] = maxims[matrix.GetLength(0) - i - 1];
                    tmp--;
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length != matrix.GetLength(1)) return;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int inmax=0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[inmax, j]<matrix[i,j])  inmax = i;
                }

                if (array[j] > matrix[inmax, j])
                {
                    matrix[inmax, j] = array[j];
                }
            }

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int[] min = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                min[i] = int.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min[i])
                        min[i] = matrix[i, j];
                }
            }
            for (int k = 0; k < matrix.GetLength(0) - 1; k++)
            {
                for (int i = 0; i < matrix.GetLength(0) - 1 - k; i++)
                {
                    if (min[i] < min[i + 1])
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            int tmp = matrix[i, j];
                            matrix[i, j] = matrix[i + 1, j];
                            matrix[i + 1, j] = tmp;
                        }
                        int t = min[i];
                        min[i] = min[i + 1];
                        min[i + 1] = t;
                    }
                }
            }

            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
            {
                return null;
            }
            answer = new int[2 * n - 1];
            for (int k = 0; k < answer.Length; k++)
            {
                int sum = 0;
                int startRow = k < n ? n - 1 - k : 0;
                int startCol = k < n ? 0 : k - n + 1;
                int i = startRow;
                int j = startCol;
                while (i < n && j < n)
                {
                    sum += matrix[i, j];
                    i++;
                    j++;
                }
        
        answer[k] = sum;
    }

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1)) return;
            if (k < 0 || k >= n) return;

            double maxAbs = 0;
            int maxRow = 0, maxCol = 0;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double absValue = Math.Abs(matrix[i, j]);
                    if (absValue > maxAbs || (i == 0 && j == 0))
                    {
                        maxAbs = absValue;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            if (maxRow == k && maxCol == k) return;

            if (maxRow != k)
            {
                int[] tempRow = new int[n];
                for (int j = 0; j < n; j++) tempRow[j] = matrix[maxRow, j];

                if (maxRow > k)
                {
                    for (int i = maxRow; i > k; i--)
                        for (int j = 0; j < n; j++)
                            matrix[i, j] = matrix[i - 1, j];
                }
                else
                {
                    for (int i = maxRow; i < k; i++)
                        for (int j = 0; j < n; j++)
                            matrix[i, j] = matrix[i + 1, j];
                }

                for (int j = 0; j < n; j++) matrix[k, j] = tempRow[j];
            }

            if (maxCol != k)
            {
                int[] tempCol = new int[n];
                for (int i = 0; i < n; i++) tempCol[i] = matrix[i, maxCol];

                if (maxCol > k)
                {
                    for (int j = maxCol; j > k; j--)
                        for (int i = 0; i < n; i++)
                            matrix[i, j] = matrix[i, j - 1];
                }
                else
                {
                    for (int j = maxCol; j < k; j++)
                        for (int i = 0; i < n; i++)
                            matrix[i, j] = matrix[i, j + 1];
                }

                for (int i = 0; i < n; i++) matrix[i, k] = tempCol[i];
            }
        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);
            
            if (colsA != rowsB) return null;
            
            int[,] answer = new int[rowsA, colsB];
            
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    answer[i, j] = sum;
                }
            }
            
            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int[][] answer = new int[rows][];
            
            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] > 0) count++;
                
                answer[i] = new int[count];
                
                int index = 0;
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] > 0)
                        answer[i][index++] = matrix[i, j];
            }
            
            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            if (array == null) return null;
            
            int totalElements = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                    totalElements += array[i].Length;
            }
            
            int n = (int)Math.Ceiling(Math.Sqrt(totalElements));
            int[,] answer = new int[n, n];
            
            int currentRow = 0;
            int currentCol = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        answer[currentRow, currentCol] = array[i][j];
                        currentCol++;
                        if (currentCol == n)
                        {
                            currentCol = 0;
                            currentRow++;
                        }
                    }
                }
            }
            
            return answer;
        }
    }
}