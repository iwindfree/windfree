using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * Password(15분)
 *
 * password 문자열을 입력받아 아래의 조건을 검사하는 문제
 * 숫자/영문/특수로 구성 될 수 있음
 * 특수문자는 사용가능한 문자가 제한되어 제공
 * (제공된 특수문자는 정확하게 무엇이 있었는지 기억이 나지 않습니다...)
 * 
 * 숫자/영문/특수 조합이 2가지면 10자 이상
 * 숫자/영문/특수 조합이 3가지면 8자 이상
 * 영문은 대소문자를 구분 a != A
 * 같은글자 반복되면 안됨(추가점)
 * 
 * abcde1234 -> 2가지 조합에 9글자 이므로 false
 * abcde12345 -> 2가지 조합에 10글자 이므로 true
 * !abc1234 -> 3가지 조합에 8글자 이므로 true
 * aacde12345 -> a가 반복되므로 false
 * aAcde12345 -> true
 *
 * -----------
 * Pseudocode
 * -----------
 * TODO
 * 
 */
namespace Quiz
{
    class Password
    {
        private static char[] SPECIAL_CHARACTER = { '~', '!', '@', '#', '$', '%', '^', '&', '*', '-', '+', '(', ')' };
        private bool hasCharacter = false;
      //  private bool hasUpperCase = false;
        private bool hasNumber = false;
        private bool hasSpecial = false;
        private bool hasMulti = false;
        public void Solve()
        {
            Console.WriteLine("valid:{0}", isValid("abcde1234"));
            Console.WriteLine("valid:{0}", isValid("abcde12345"));
            Console.WriteLine("valid:{0}", isValid("!abc1234"));
            Console.WriteLine("valid:{0}", isValid("aacde12345"));
            Console.WriteLine("valid:{0}", isValid("aAcde12345"));

        }
        private bool isValid(string s)
        {
            bool result = false;
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(s);

            for (int i = 0; i < bytes.Length; i++)
            {
                if (i != 0)
                {
                    if (bytes[i] == bytes[i - 1])
                    {
                        hasMulti = true;

                        return false;
                    }
                }

                if ((bytes[i] >= (int)'a' && bytes[i] <= (int)'z') || (bytes[i] >= (int)'A' && bytes[i] <= (int)'Z'))
                {
                    hasCharacter = true;
                    continue;


                }

                if (bytes[i] >= (int)'0' && bytes[i] <= (int)'9')
                {
                    hasNumber = true;
                    continue;
                }

                for (int j = 0; j < SPECIAL_CHARACTER.Length; j++)
                {
                    if (bytes[i] == SPECIAL_CHARACTER[j])
                    {
                        hasSpecial = true;
                        continue;
                    }
                }



            }


            if (hasCharacter && hasNumber && hasSpecial)
            {
                if (s.Length >= 8)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            if ((hasCharacter && hasNumber && hasSpecial == false) || (hasCharacter && hasSpecial && hasNumber == false) || (hasSpecial && hasNumber && hasCharacter == false))
            {
                if (s.Length >= 10)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;



        }


    }
}
