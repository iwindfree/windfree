using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 괄호의 짝이 맞는지 확인하는 함수를 작성하시오. 
 * helllo({aa})[] => true
 * hello (((}}] ==> false 
 * 
 * 
 * 
 * 
 */
namespace sample.Quiz
{
    class CheckPair
    {
        public void Solve()
        {
            Console.WriteLine(Check("helllo({aa})[]"));
            Console.WriteLine(Check("helllo({aa})["));
        }

        private bool Check(string s)
        {

            Stack<char> charStack = new Stack<char>();
            char[] arr = s.ToArray();
            foreach (char c in arr)
            {
                switch (c)
                {
                    case '{':
                    case '(':
                    case '[':
                        charStack.Push(c);
                        break;
                    case ']':
                        if (charStack.Peek() == '[')
                        {
                            charStack.Pop();
                        }
                        break;
                    case '}':
                        if (charStack.Peek() == '{')
                        {
                            charStack.Pop();
                        }
                        break;
                    case ')':
                        if (charStack.Peek() == '(')
                        {
                            charStack.Pop();
                        }
                        break;
                }
            }
            if (charStack.Count == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
