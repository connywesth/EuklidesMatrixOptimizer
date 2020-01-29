using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EuklidesMatrixOptimizer_ClassLibraryNETStandard
{
    public class EuklidesOptimizer
    {
        public EuklidesSquareBox euklidesSquareBox = new EuklidesSquareBox();
        public BoxPathsRankingList totalRankingList = new BoxPathsRankingList();

        public Box BoxBegin;
        public Box BoxEnd;

        public static CallCounter RecursiveSolveCallCounter = new CallCounter();

        public EuklidesOptimizer()
        {
        }

        public void Solve()
        {
            RecursiveSolveCallCounter.Reset();
            BoxBegin = euklidesSquareBox.matrix[0, 0];
            BoxEnd = euklidesSquareBox.matrix[4, 4];
            Solve(new BoxPath(), BoxBegin, BoxEnd);
        }

        public void Solve(BoxPath boxPath, Box begin, Box end)
        {
            RecursiveSolveCallCounter.IncreaseOne();
            BoxPath newBoxPath;
            if (begin == null)
            {
            }
            else if (begin.Row == end.Row && begin.Column == end.Column)
            {
                newBoxPath = boxPath.Clone();
                newBoxPath.Add(begin);
                if (newBoxPath.Sum() <= this.totalRankingList.LowestSum)
                {
                    this.totalRankingList.Add(newBoxPath);
                    //Console.WriteLine($"Count:{this.totalRankingList.Count}, Low:{this.totalRankingList.LowestSum}, BoxPath:{newBoxPath}, Begin:{begin}, End:{end}");
                }
            }
            else if (!boxPath.IsFoundBox(begin))
            {
                newBoxPath = boxPath.Clone();
                newBoxPath.Add(begin);
                if (newBoxPath.Sum() <= this.totalRankingList.LowestSum)
                {
                    Solve(newBoxPath, euklidesSquareBox.Up(begin), end);
                    Solve(newBoxPath, euklidesSquareBox.Down(begin), end);
                    Solve(newBoxPath, euklidesSquareBox.Left(begin), end);
                    Solve(newBoxPath, euklidesSquareBox.Right(begin), end);
                }
            }

        }


        public void Solve2(BoxPath boxPath, Box begin, Box end)
        {
            BoxPath newBoxPath;
            if (begin == null)
            {
            }
            else
            {
                newBoxPath = boxPath.Clone();
                newBoxPath.Add(begin);
                if (newBoxPath.Sum() <= this.totalRankingList.LowestSum)
                {
                    SolveAddToRankingList(newBoxPath, begin,end);
                    SolveRecursive(newBoxPath, begin, end);
                }
            }
        }

        public void SolveAddToRankingList(BoxPath boxPath, Box begin, Box end)
        {
            if (begin.Row == end.Row && begin.Column == end.Column)
            {
                this.totalRankingList.Add(boxPath);
                Console.WriteLine($"Count:{this.totalRankingList.Count}, Low:{this.totalRankingList.LowestSum}, BoxPath:{boxPath}, Begin:{begin}, End:{end}");
            }
        }

        public void SolveRecursive(BoxPath boxPath, Box begin, Box end)
        {
            if (!boxPath.IsFoundBox(begin))
            {
                Solve(boxPath, euklidesSquareBox.Up(begin), end);
                Solve(boxPath, euklidesSquareBox.Down(begin), end);
                Solve(boxPath, euklidesSquareBox.Left(begin), end);
                Solve(boxPath, euklidesSquareBox.Right(begin), end);
            }
        }

    }
}
