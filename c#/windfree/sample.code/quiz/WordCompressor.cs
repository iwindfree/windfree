using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *  같은 문자들이 나올 때 그 횟수를 이용하여 문자열을 압축하는 메서드를 작성하시오. 
 *  예) ABC -> ABC
 *     AaaaBbbCcDDddAaa ->a4b3c2d4a3
 * 
 * 
 * 
 * 
 * 
 */
namespace sample.Quiz
{
    class WordCompressor
    {
        public void Solve()
        {
            Console.WriteLine(Compress("AaaaBbbCcDDddAaa"));
        }
       

       

        private string Compress(string s)
        {
            char[] arr = s.ToLower().ToArray();
            StringBuilder sb = new StringBuilder();
            int count = 1;
          
            for(int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                {
                    sb.Append(arr[i]);
                    continue;
                }
               
                if(arr[i] == arr[i-1])
                {
                    count++;
                  
                } else
                {
                    
                    sb.Append(count);
                    count = 1;
                    sb.Append(arr[i]);
                }

            }
            sb.Append(count);
            return sb.ToString();
        }
    }
}
