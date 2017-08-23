using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    /*
     * 재귀를 이용해서 풀면.
     *                            abcd
     *               abcd     bacd     cbad    dbca  (첫번째 문자를 두번째, 세번째, 네번째 문자들과 SWAP
     *                -
     *      ------------------                       (두번째 문자를 세번째, 네번째와 swap 
     *        abcd     acbd  adcb
     *         -        -      - 
     *   -----------  ------- -------                
     *   abcd,abdc   acdb,acdb  adcb, adbc           (세번째 문자를 네번째 문자와 swap) 
     *   
     *   해당 과정을 반복하는 경우이므로 재귀를 이용하여 풀이
     *  
     * 
     * 
     * 
     * 
     * 
     */
    class Permutaion
    {
        public void Solve()
        {
            string s = "ABCD";
            char[] arr = s.ToArray();
            Permutate(arr, 0, arr.Length - 1);
        }

        private void Permutate(char[] arr, int start, int n)
        {
            if (start == n)
            {
                Console.Out.WriteLine(new string(arr));

            }
            for (int i = start; i <= n; i++)
            {
                swap(ref arr, start, i);
                Permutate(arr, start + 1, n);
                swap(ref arr, start, i);
            }

        }

        private void swap(ref char[] arr, int i, int j)
        {
            char temp;
            temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }
    }
}
