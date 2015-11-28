namespace WordGame
{
    using System;
  
    class Program
    { 
        //method print the Matrix
        public static void PrintMatrix(char[,] matrix, char[] randCharArr)
        {
            int count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = randCharArr[count];
                    count++;
                    Console.Write("{0} ", matrix[row, column]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //method search word horizontally,vertically,diagonally
        public static void SearchingName(char[,] matrix, string searchingName)
        {
            //Horizontal Searching Left to Right
            byte nameFoundHoriz = 0;
            string foundChar = string.Empty;
            int columnLenght = matrix.GetLength(0);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    foundChar += matrix[row, column];
                }

                if (foundChar == searchingName)
                {
                    nameFoundHoriz++;
                    foundChar = string.Empty;
                    break;
                }
                else
                {
                    foundChar = string.Empty;
                }
            }

            ////horizontally Right to Left
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = matrix.GetLength(1); column > 0; column--)
                {
                    foundChar += matrix[row, column - 1];
                }

                if (foundChar == searchingName)
                {
                    nameFoundHoriz++;
                    foundChar = string.Empty;
                    break;
                }
                else
                {
                    foundChar = string.Empty;
                }
            }
            Console.WriteLine("Found words horizontally: {0}", nameFoundHoriz);


            //Vertically top to bottom
            byte nameFoundVertical = 0;
            int charNameleng = searchingName.Length;
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                for (int row = 0; row <= columnLenght - charNameleng; row++)
                {
                    for (int checkAllRow = 0 + row; checkAllRow < searchingName.Length + row; checkAllRow++)
                    {
                        foundChar += matrix[checkAllRow, column];
                        if (foundChar == searchingName)
                        {
                            nameFoundVertical++;
                        }
                    }
                    foundChar = string.Empty;
                }
            }

            //Vertically bottom to top
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                for (int row = columnLenght - charNameleng; row >= 0; row--)
                {
                    for (int checkAllRow = searchingName.Length + row - 1; checkAllRow >= 0 + row; checkAllRow--)
                    {
                        foundChar += matrix[checkAllRow, column];
                        if (foundChar == searchingName)
                        {
                            nameFoundVertical++;
                        }
                    }
                    foundChar = string.Empty;
                }
            }
            Console.WriteLine("Found words vertically: {0}", nameFoundVertical);


            //Digonal left to right
            byte diagonalNameFound = 0;
            int currentCount = matrix.GetLength(1);
            for (int i = currentCount; i > 0; i--)
            {
                for (int col = currentCount; col < matrix.GetLength(0); col++)
                {
                    foundChar += matrix[col, col - i];
                    if (foundChar == searchingName)
                    {
                        diagonalNameFound++;
                    }
                }
                foundChar = string.Empty;
                currentCount--;
            }
            currentCount = 0;

            for (int i = currentCount; i < matrix.GetLength(1); i++)
            {
                for (int col = currentCount; col < matrix.GetLength(1); col++)
                {
                    foundChar += matrix[col - i, col];
                    if (foundChar == searchingName)
                    {
                        diagonalNameFound++;
                    }
                }
                currentCount++;
                foundChar = string.Empty;
            }

            //Digonal right to left
            currentCount = matrix.GetLength(1);
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = currentCount; j >= i; j--)
                {
                    foundChar += matrix[j, j - i];
                    if (foundChar == searchingName)
                    {
                        diagonalNameFound++;
                    }
                }
                foundChar = string.Empty;
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = currentCount - 1; j >= i; j--)
                {
                    foundChar += matrix[j - i, j];
                    if (foundChar == searchingName)
                    {
                        diagonalNameFound++;
                    }
                }
                foundChar = string.Empty;
            }
            Console.WriteLine("Found words diagonally: {0}", diagonalNameFound);
            Console.WriteLine();
            Console.WriteLine("Total found words are : {0}", nameFoundHoriz + nameFoundVertical + diagonalNameFound);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string searchingName = "ivan";// Console.ReadLine();
            char[] nameCharArr = searchingName.ToLower().ToCharArray();

            string randChar = "ivanevnhinavmvvnqrit";//Console.ReadLine();
            char[] randCharArr = randChar.ToLower().ToCharArray();
            char[,] matrix = new char[randCharArr.Length/nameCharArr.Length, nameCharArr.Length];
           
            PrintMatrix(matrix, randCharArr);

            SearchingName(matrix, searchingName);
        }
    }//end class
}//end namespace


