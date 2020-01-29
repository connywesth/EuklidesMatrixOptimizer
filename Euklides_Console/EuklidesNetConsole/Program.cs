
using EuklidesMatrixOptimizer_ClassLibraryNETStandard;
using System;

namespace Euklides_ClassLibraryNETStandard_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string programName = "Euklides Optimizer by Conny Westh 2020-01-20";
            int lowestSum = int.MaxValue;
            while(true)
            {
                ReSetBoxColor();
                Console.Title = programName;
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(programName);
                EuklidesOptimizer euklidesOptimizer = new EuklidesOptimizer();
                euklidesOptimizer.Solve();
                ShowResult(euklidesOptimizer);
                //if (euklidesOptimizer.totalRankingList.LowestSum < lowestSum)
                //{
                    lowestSum = euklidesOptimizer.totalRankingList.LowestSum;
                    Console.Write($"Press [ESC] to exit, or another key to run again...");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                //}
            } 
        }

        static void ShowResult(EuklidesOptimizer eo)
        {
            ShowMatrix(eo.euklidesSquareBox);
            Console.WriteLine($"Recursive Solve Calls: {EuklidesOptimizer.RecursiveSolveCallCounter}");
            ShowRankingList(eo);
        }

        static void ShowMatrix(EuklidesSquareBox squareBox, BoxPath boxPath=null)
        {
            string line = "---------------------";
            Console.WriteLine("");
            Console.WriteLine(line);
            Box currentBox;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    currentBox = squareBox.matrix[row, col];
                    Console.Write($"|");
                    SetBoxColor(boxPath, currentBox);
                    Console.Write($" {currentBox.Value} ");
                    ReSetBoxColor();
                }
                Console.WriteLine($"|");
                Console.WriteLine(line);
            }
            Console.WriteLine("");
        }

        static void SetBoxColor(BoxPath boxPath, Box boxToColor)
        {
                if (boxToColor.Row == 0 && boxToColor.Column == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else if (boxToColor.Row == 4 && boxToColor.Column == 4)
                {
                    Console.BackgroundColor = ConsoleColor.Red;

                }
                else if ((boxPath != null) && (boxPath.IsFoundBox(boxToColor)))
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
        }

        static void ReSetBoxColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
        }

        static void ShowRankingList(EuklidesOptimizer eo)
        {
            Console.WriteLine("");
            if (eo.totalRankingList.Count<2)
            {
                Console.WriteLine($"Matrisen har {eo.totalRankingList.Count} lösning med summan {eo.totalRankingList.LowestSum}:");
            }
            else
            {
                Console.WriteLine($"Matrisen har {eo.totalRankingList.Count} lösningar med summan {eo.totalRankingList.LowestSum}:");
            }
            foreach (BoxPath boxPath in eo.totalRankingList.GetAllBoxPathes_OrderByLowestSum())
            {
                //Console.WriteLine($"{boxPath}");
                ShowMatrix(eo.euklidesSquareBox, boxPath);
            }
        }

    }
}