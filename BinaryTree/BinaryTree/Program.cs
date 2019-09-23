using BinaryTree.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrOfRows = Helper.MakeArrayOfRows(Constants.SampleImput);
            int[,] table = Helper.MakeTableFromRows(arrOfRows);
            List<int> maxSumPath = Helper.FindMaximumPath(table);

            PrintResult(maxSumPath);
            Console.ReadLine();
        }

        private static void PrintResult(List<int> maxSumPath)
        {
            if (maxSumPath.Count != 0)
            {
                Console.WriteLine($"Maximum sum: {maxSumPath.Sum()}");
                Console.WriteLine($"Path is: {GetPath(maxSumPath)}");
            }
            else
            {
                Console.WriteLine("There is no valid path from top to bottom of pyramid!");
            }
            
        }

        private static string GetPath(List<int> maxSumPath)
        {
            string path = string.Empty;
            foreach (var spot in maxSumPath)
            {
                path = string.Format($"{path}{spot}, ");
            }
            return path.Remove(path.Trim().Length - 1);
        }
    }
}
