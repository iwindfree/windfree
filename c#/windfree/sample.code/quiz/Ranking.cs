using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * Rank (10분)
 * 
 * ID, 수학, 영어 점수 2차원 배열이 주어졌을 때
 * 총점, 등수, 순번을 출력하는 문제입니다.
 * 단, 점수가 동일할 경우 같은 등수로 표시하고 다음 등수는 건너뜁니다.
 * 
 * 예) 실행결과
 * ID 총점 등수 순번
 * 56789 180 1 1
 * 45678 160 2 2
 * 34567 140 3 3
 * 12345 130 4 4
 * 67890 130 4 5
 * 23456 90 6 6
 * 
 * -----------
 * Pseudocode
 * -----------
 * TODO
 * 
 */
namespace sample.Quiz
{
    class Ranking
    {
        public void Solve()
        {
            int[,] scores = {
            //ID, 수학, 영어
            {12345, 60, 70},
            {23456, 50, 40},
            {34567, 40, 100},
            {45678, 80, 80},
            {56789, 80, 100},
            {67890, 80, 50}};

            int[][] scores_new = new int[6][]; 
            for(int i = 0; i < scores.GetLength(0); i++)
            {

                Console.WriteLine("id: {0}, total:{1}", scores[i, 0], scores[i, 1] + scores[i, 2]);
                scores_new[i] = new int[] { scores[i, 0], scores[i, 1] + scores[i, 2] };
                
            }

            Array.Sort(scores_new, new scoreComparer());
            Console.Out.WriteLine("ID     총점     순위     순번");
            Console.Out.WriteLine("-------------------------------");

            int rank = 0;
            int prevRank = 0; 
            for(int i = 0; i < scores_new.GetLength(0); i++)
            {
                if(i == 0)
                {
                    prevRank = rank = 1;

                } else
                {
                    if(scores_new[i][1] == scores_new[i-1][1])
                    {
                        rank = prevRank;
                    } else
                    {
                        prevRank = rank = i + 1;
                    }
                }
                Console.Out.WriteLine(" {0}   {1}   {2}    {3} ", scores_new[i][0], scores_new[i][1], rank, i + 1);
            }
           

        }
    }

    class scoreComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return  -1 * ((int[])x)[1].CompareTo(((int[])y)[1]);
        }
    }


}

