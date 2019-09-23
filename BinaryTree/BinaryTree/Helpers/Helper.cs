using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree.Helpers
{
    public class Helper
    {
        internal static string[] MakeArrayOfRows(string input)
        {
            return input.Split(Environment.NewLine);
        }

        internal static int[,] MakeTableFromRows(string[] arrOfRows)
        {
            int[,] tableToReturn = new int[arrOfRows.Length, arrOfRows.Length + 1];

            //rows
            for (int i = 0; i < arrOfRows.Length; i++)
            {
                string[] rowChars = arrOfRows[i].Trim().Split(' ');

                //collumns
                for (int j = 0; j < rowChars.Length; j++)
                {
                    int number;
                    int.TryParse(rowChars[j], out number);
                    tableToReturn[i, j] = number;
                }
            }

            return tableToReturn;
        }

        internal static List<int> FindMaximumPath(int[,] table)
        {
            int tableLength = table.GetLength(0);
            int attempts = (int)Math.Pow(2, tableLength - 1);
            List<int> maxSumPath = new List<int> ();
            int index;

            for (int i = 0; i <= attempts; i++)
            {
                List<int> tempSumPath = new List<int> { table[0, 0] };
                index = 0;
                
                for (int j = 0; j < tableLength - 1; j++)
                {
                    index = index + (i >> j & 1);
                    int tableVal = table[j + 1, index];
                    if (CheckWithParentEvenOrOdd(tempSumPath[tempSumPath.Count - 1], tableVal))
                    {
                        tempSumPath.Add(tableVal);
                    }
                    else
                    {
                        break;
                    }
                }
                if (tempSumPath.Count == tableLength && tempSumPath.Sum() > maxSumPath.Sum())
                {
                    maxSumPath = tempSumPath;
                }
            }
            return maxSumPath;
        }

        private static bool CheckWithParentEvenOrOdd(int parent, int tableVal)
        {
            bool toReturn = false;
            if (parent%2 != tableVal%2)
            {
                toReturn = true;
            }
            return toReturn;
        }

      
    }
}
