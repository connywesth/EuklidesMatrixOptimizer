using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EuklidesMatrixOptimizer_ClassLibraryNETStandard
{
    public class BoxPathsRankingList : List<BoxPath>
    {
        public int LowestSum = int.MaxValue;
        public BoxPathsRankingList()
        {
        }

        public new void Add(BoxPath boxPath)
        {
            if (boxPath.Sum() < LowestSum )
            {
                this.Clear();
                base.Add(boxPath);
                LowestSum = boxPath.Sum();
            }
            else if (boxPath.Sum() == LowestSum)
            {
                base.Add(boxPath);
                LowestSum = boxPath.Sum();
            }

        }

        public BoxPathsRankingList GetAllBoxPathes_OrderByLowestSum()
        {
            IOrderedEnumerable<BoxPath> rList = this.OrderByDescending(boxPath => boxPath.Sum());
            BoxPathsRankingList rankingList = new BoxPathsRankingList();
            foreach (BoxPath bp in rList)
            {
                rankingList.Add(bp);
            }

            return rankingList;
        }

        public int GetLowestSum()
        {
            int lowestSum = 0;
            int? sum = GetAllBoxPathes_OrderByLowestSum().FirstOrDefault().Sum();

            if (sum != null)
            {
                lowestSum = (int)sum;
            }

            foreach (BoxPath boxPath in GetAllBoxPathes_OrderByLowestSum())
            {
                if (lowestSum> boxPath.Sum())
                {
                    lowestSum = boxPath.Sum();
                }
            }
            return lowestSum;
        }

        public BoxPathsRankingList GetOnlyBoxPathes_WithLowestSum()
        {
            BoxPathsRankingList rankingList = new BoxPathsRankingList();
            int lowestSum = GetLowestSum();

            foreach (BoxPath boxPath in GetAllBoxPathes_OrderByLowestSum())
            {
                if (boxPath.Sum() == lowestSum)
                {
                    rankingList.Add(boxPath);
                }
                else
                {
                    break;
                }
            }
            return rankingList;
        }
    }
}
