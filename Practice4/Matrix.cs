using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    internal class Matrix
    {
        private int n;
        private int[,] matrix;

        public Matrix(int n)
        {
            this.n = SetSize(n);
            matrix = SetMatrix();
        }

        public Matrix(int n, int[,] matrix)
        {
            this.n = n;
            this.matrix = matrix;
        }

        ~Matrix()
        {
            Console.WriteLine("Матрица была удалена");
        }

        private int SetSize(int n)
        {
            if (n < 1)
            {
                Console.WriteLine("Неправильно введен размар. Введите размер матрицы");

                Boolean isCorrect = false;

                while (isCorrect == false)
                {
                    string temp = Console.ReadLine();
                    if (int.TryParse(temp, out int size))
                    {
                        if (size < 1)
                        {
                            Console.WriteLine("Неправильно введен размар. Введите размер матрицы");
                            isCorrect = false;
                        }
                        else
                        {
                            return size;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Something wrong");
                        isCorrect = false;
                    }
                }
            } else
            {
                return n;
            }
            return n;
        }

        private int[,] SetMatrix()
        {
            Console.WriteLine("New Matrix\n");
            int[,] matrix = new int[this.n, this.n];

            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    Console.WriteLine("Введите элемент матрицы");

                    Boolean isCorrect = false;

                    while (isCorrect == false)
                    {
                        string temp = Console.ReadLine();
                        if (int.TryParse(temp, out int number))
                        {
                            matrix[i, j] = number;
                            isCorrect = true;
                        }
                        else
                        {
                            Console.WriteLine("Something wrong");
                            isCorrect = false;
                        }
                    }
                }
            }

            return matrix;
        }

        public int GetElementOfMatrix(int i, int j)
        {
            return matrix[i, j];
        }

        public int[,] GetFullMatrix()
        {
            return matrix;
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            int[,] tempArray = new int[left.n, left.n];

            if (left.n != right.n) {
                tempArray = null;
            }
            else
            {
                for (int i = 0; i < left.n; i++)
                {
                    for (int j = 0; j < left.n; j++)
                    {
                        tempArray[i, j] = left.GetElementOfMatrix(i, j) + right.GetElementOfMatrix(i, j);
                    }
                }
            }


            Matrix newMatrix = new Matrix(left.n, tempArray);

            return newMatrix;
        }

        public static Matrix operator -(Matrix left, Matrix right)
        {
            int[,] tempArr = new int[right.GetFullMatrix().GetLength(0), right.GetFullMatrix().GetLength(1)];
            for (int i = 0; i < tempArr.GetLength(0); i++)
            {
                for (int j = 0; j < tempArr.GetLength(1); j++)
                {
                    tempArr[i, j] = -right.GetElementOfMatrix(i, j);
                }
            }
            Matrix tempMatrix = new Matrix(tempArr.GetLength(0), tempArr);
            return (tempMatrix + left);
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (left.GetFullMatrix() != null && right.GetFullMatrix() != null)
            {
                int[,] newArr = new int[left.GetFullMatrix().GetLength(1), right.GetFullMatrix().GetLength(0)];

                if (left.GetFullMatrix().GetLength(1) != right.GetFullMatrix().GetLength(0))
                {
                    newArr = null;
                    Matrix newMatrix = new Matrix(left.GetFullMatrix().GetLength(1), newArr);
                    return newMatrix;

                }
                else
                {
                    for (int i = 0; i < newArr.GetLength(0); i++)
                    {
                        for (int j = 0; j < newArr.GetLength(1); j++)
                        {
                            newArr[i, j] = 0;

                            for (int k = 0; k < newArr.GetLength(1); k++)
                            {
                                newArr[i, j] += left.GetElementOfMatrix(i, k) * right.GetElementOfMatrix(k, j);
                            }
                        }
                    }
                    Matrix newMatrix = new Matrix(newArr.GetLength(0), newArr);
                    return newMatrix;
                }
            }
            else
            {
                int[,] newArr = null;
                Matrix newMatrix = new Matrix(newArr.GetLength(0), newArr);
                return newMatrix;
            }
        }

        public static Matrix operator *(int a, Matrix right)
        {
            int[,] newArr = new int[right.GetFullMatrix().GetLength(0), right.GetFullMatrix().GetLength(1)];

            for (int i = 0; i < newArr.GetLength(0); i++)
            {
                for (int j = 0; j < newArr.GetLength(1); j++)
                {
                    newArr[i, j] = a * right.GetElementOfMatrix(i, j);
                }
            }

            Matrix newMatrix = new Matrix(newArr.GetLength(0), newArr);
            return newMatrix;
        }

        public string MatrixIsSymmetric()
        {
            int rows = this.matrix.GetLength(0);
            int cols = this.matrix.GetLength(1);

            if (rows != cols)
            {
                return "Матрица не является симметричной";
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (this.matrix[i,j] != this.matrix[j, i])
                    {
                        return "Матрица не является симметричной";
                    }
                }
            }

            return "Матрица является симметричной";
        }


        public override string ToString()
        {
            string result = "";
            
            if (this.matrix != null)
            {
                for (int i = 0; i < this.n; i++)
                {
                    for (int j = 0; j < this.n; j++)
                    {
                        result += matrix[i, j] + " ";
                    }
                    result += "\n";
                }
            }
            else
            {
                result += "Матрицы не существует";
            }

            return result;
        }

    }
}
