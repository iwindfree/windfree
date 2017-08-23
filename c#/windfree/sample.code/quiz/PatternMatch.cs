using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 주어진 문자열 (LGOLOLOLGOLOL) 에서 겹쳐 정의된 (GOL, LOL) 문자열이 몇개 있는지 확인하는 것을 구현
 * 예) GOL - 2개, LOL - 3개   ==> 총 5개
 * 
 * 
 * 
 * 
 */
namespace sample.Quiz
{
    class PatternMatch
    {
        string value = "LGOLOLOLGOLOL";
        public void Solve()
        {
            int i = find("GOL");
            int j = find("LOL");
            Console.Out.WriteLine("GOL: {0}, LOL:{1}  ==> total: {2}", i, j, i+j);

        }

        private int find(string pattern)
        {
            int matachCount = 0;
            int from = -1; 
            while ((from =  value.IndexOf(pattern,from + 1)) != -1)
            {
                matachCount++;
            }
            return matachCount;
        }
    }
}
