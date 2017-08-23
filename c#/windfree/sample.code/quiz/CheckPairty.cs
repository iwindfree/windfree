using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * Parity Check(패리티 체크) (20분)
 *
 * 1 또는 0 만 들어있는 4x4 int 2차 배열에서
 * 각 행과 열에 1의 개수가 0이거나 짝수이면 패리티체크를 통과했다고 합니다.
 *
 * 2차배열을 파라미터로 받아서 패리티 체크를 한뒤 패리티체크를 통과할 수 있는지
 * 하나만 수정해서 패리티체크를 통과할 수 있다면 어떤 행과 어떤 열을 수정해야하는지
 * 하나만 수정해서는 통과할 수 없는지를 판별하는 함수를 구현.
 *
 * 패리티체크 성공/실패 판별(기본점수)
 * 한개만 수정해서 체크성공할때 해당 위치 판멸(추가점수)
 *
 * 예)
 * 1 0 1 0
 * 0 1 1 0
 * 1 0 1 0
 * 0 1 1 0
 * OK!
 *
 * 1 0 1 0
 * 0 1 1 0
 * 1 1 1 0
 * 0 1 1 0
 * change(3,2)
 *
 * 1 0 1 0
 * 0 1 1 0
 * 1 1 1 1
 * 0 1 1 0
 * NO!
 *
 * -----------
 * Pseudocode
 * -----------
 * TODO
 *
 */
namespace Quiz
{
    class CheckParity
    {
        int[,] array = new int[,]{
            {1, 0, 1, 0},
            {0, 1, 1, 0},
            {1, 1, 1, 0},
            {0, 1, 1 ,0}
        };
        public void Solve()
        {
            int rowCount = array.GetLength(0);
            int colCount = array.GetLength(1);

            Console.WriteLine(check(rowCount, colCount));

        }

        private string check(int num1, int num2)
        {
            int count1 = 0;
            int count2 = 0;
            bool result = true;
            int fixRow = -1;
            int fixCol = -1;
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                    if (array[i, j] == 1)
                    {
                        count1++;
                    }
                    else
                    {
                        count2++;
                    }
                }
                if (count1 % 2 == 0 && count2 % 2 == 0)
                {
                    result = result & true;
                }
                else
                {
                    result = result & false;
                    if (fixRow != -1)
                    {
                        return "NO";
                    }
                    else
                    {
                        fixRow = i;
                    }
                }
                count1 = count2 = 0;
            }

            result = true;
            count1 = count2 = 0;
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                    if (array[j, i] == 1)
                    {
                        count1++;
                    }
                    else
                    {
                        count2++;
                    }
                }
                if (count1 % 2 == 0 && count2 % 2 == 0)
                {
                    result = result & true;
                }
                else
                {
                    result = result & false;
                    if (fixCol != -1)
                    {
                        return "NO";
                    }
                    else
                    {
                        fixCol = i;
                    }
                }
                count1 = count2 = 0;
            }



            if (result)
            {
                return "OK";
            }
            else
            {

                return "change (" + (fixRow + 1) + "," + (fixCol + 1) + ")";
            }
            return null;

        }
    }
}
