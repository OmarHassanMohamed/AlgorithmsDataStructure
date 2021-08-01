using SortingAlgorithms;
using SortingAlgorithms.Helpers;
using StringSearching.BoyerMoore;
using StringSearching.FindAndReplace;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataStructure
{
    class Program
    {
        private static Random _rng = new Random();

        static void Main(string[] args)
        {
            #region Find & Replace

            List<String> text = new List<string>();
            string find = null;
            string replace = string.Empty;

            foreach (string arg in args)
            {
                string[] command = arg.Trim().TrimStart('-').Split('=', 2);
                switch (command[0].ToLower())
                {
                    case "find":
                        find = command[1];
                        break;
                    case "replace":
                        replace = command[1];
                        break;
                    case "text":
                        text.Add(command[1]);
                        break;
                    default:
                        Console.Error.WriteLine($"Unknown command: {command[0]}");
                        return;
                }
            }

            foreach (string input in text)
            {
                string output = StringReplace.Replace(new BoyerMooreHorspool(), input, find, replace);
                Console.WriteLine(output);
            }

            #endregion

            #region Sorting 
            int iterations = 20000;
            int[] testdata = RandomArray(iterations);

            RunTests(iterations);
            #endregion

        }

        private static int[] RandomArray(int length)
        {
            int[] data = new int[length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = _rng.Next();
            }
            return data;
        }

        static void RunTests(int iterations)
        {
            Dictionary<string, SortingMetrics<int>> algorithms = new Dictionary<string, SortingMetrics<int>>
            {
                { "Bubble Sort", new BubbleSort<int>() },
                { "Insertion Sort", new InsertionSort<int>() },
                { "Merge Sort", new MergeSort<int>() },
                { "Quick Sort", new QuickSort<int>() }
            };

            int[] testdata = RandomArray(iterations);

            foreach (var kvp in algorithms)
            {
                Console.WriteLine("Executing: {0}", kvp.Key);

                Stopwatch timer = Stopwatch.StartNew();
                kvp.Value.Sort(CopyArray(testdata));
                timer.Stop();

                Console.WriteLine("       Length: {0}", testdata.Length);
                Console.WriteLine("  Comparisons: {0}", kvp.Value.Comparisons);
                Console.WriteLine("        Swaps: {0}", kvp.Value.Swaps);
                Console.WriteLine("      Seconds: {0}", timer.Elapsed.TotalSeconds);
                Console.WriteLine("------------------");
            }

        }

        private static int[] CopyArray(int[] origional)
        {
            int[] copy = new int[origional.Length];
            for (int i = 0; i < origional.Length; i++)
            {
                copy[i] = origional[i];
            }

            return copy;
        }
    }
}
