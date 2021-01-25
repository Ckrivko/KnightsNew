using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];


            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int numRemovKnights = 0;

            while (true)
            {
                int maxNumberAttackKnights = int.MinValue;
                int rowMax = int.MinValue;
                int colMax = int.MinValue;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        int numAtackKnights = 0;

                        if (matrix[row, col] == 'K')
                        {
                            numAtackKnights = GetPattern(row, col, matrix, numAtackKnights, n);

                        }

                        if (numAtackKnights > maxNumberAttackKnights)
                        {
                            maxNumberAttackKnights = numAtackKnights;
                            rowMax = row;
                            colMax = col;
                        }

                    }
                }

                if (maxNumberAttackKnights > 0)
                {
                    matrix[rowMax, colMax] = '0';
                    numRemovKnights++;
                }
                else
                {

                    break;
                }

            }
            Console.WriteLine(numRemovKnights);

        }

        public static int GetPattern(int row, int col, char[,] matrix, int atackKnights, int n)
        {
            if (row - 2 >= 0 && col - 1 >= 0)    // we  up-up/left  1                    
            {
                if (matrix[row - 2, col - 1] == 'K')
                {

                    atackKnights++;
                }
            }

            if (row - 2 >= 0 && col + 1 < n)    //up-up/ right       2                          
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    atackKnights++;
                }
            }

            if (row - 1 >= 0 && col - 2 >= 0)       // up/left-left   3                        
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    atackKnights++;
                }
            }

            if (row - 1 >= 0 && col + 2 < n)                //up/right-right   4                
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    atackKnights++;
                }

            }

            if (row + 1 < n && col + 2 < n)             //down/right-right     5              
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    atackKnights++;
                }
            }

            if (row + 1 < n && col - 2 >= 0)           //down/left-left       6               
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    atackKnights++;
                }
            }

            if (row + 2 < n && col + 1 < n)                //   down-down/ right    7            
            {
                if (matrix[row +2, col + 1] == 'K')
                {
                    atackKnights++;
                }
            }

            if (row + 2 < n && col - 1 >= 0)              //down-down/left         8
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    atackKnights++;
                }
            }

            return atackKnights;
        }

    }
}
