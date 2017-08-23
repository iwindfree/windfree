using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sample.Quiz
{
    /*
     *  계산기를 만드는 것의 핵심은 주어진 식을 후행식으로 표현하고 
     *  후행식 을 계산하는 법을 구현하면 된다. 
     * 
     * 후행식 : 2 + 3 * 7 : 237*+ 
     *         (1 + 2 * 3 ) / 7 = 12*3*7/
     * 피연산자와 연산자는 공백으로 구분되어있다고 생각.
     */ 
    class Calculator
    {
        Stack<string> operStack = new Stack<string>();
        Stack<string> numberStack = new Stack<string>();
        List<string> postfixNotation = new List<string>();
        public void Solve()
        {
            string exp = "1 * ( 2 + 3 ) * 4";
            Execute(exp);
        }


        private void Execute(string exp)
        {

            MakePostfixNotation(exp);
            Console.Out.WriteLine(Calc());
        }

        private void MakePostfixNotation(string exp)
        {
            string[] arr = exp.Split(' ');

            foreach (string s in arr)
            {
                if (IsNumber(s))
                {
                    postfixNotation.Add(s);
                }
                else
                {
                    switch (s)
                    {
                        case "(":
                            {
                                operStack.Push(s);
                                break;
                            }
                        case ")":
                            {
                                while (!(operStack.Count == 0))
                                {
                                    if (operStack.Peek() == "(")
                                    {
                                        operStack.Pop();
                                    }
                                    else
                                    {
                                        postfixNotation.Add(operStack.Pop());
                                    }
                                }
                                break;
                            }
                        case "+":
                        case "-":
                        case "*":
                        case "/":
                            {
                                while (!(operStack.Count == 0) && (GetRank(operStack.Peek()) >= GetRank(s)))
                                {
                                    postfixNotation.Add(operStack.Pop());
                                   
                                }
                                operStack.Push(s);
                                break;
                            }
                    }
                }
            }
            while(!(operStack.Count == 0))
            {
                postfixNotation.Add(operStack.Pop());
            }


        }

        private int Calc()
        {
          
            foreach(string s in postfixNotation)
            {
                if(IsNumber(s))
                {
                    numberStack.Push(s);
                } else
                {
                    int num1 = int.Parse(numberStack.Pop());
                    int num2 = int.Parse(numberStack.Pop());
                    int result = 0;
                    switch(s)
                    {
                        case "+":
                            result = num1 + num2;
                            break;
                        case "-":
                            result = num1 - num2;
                            break;
                        case "*":
                            result = num1 * num2;
                            break;
                        case "/":
                            result = num1 / num2;
                            break;
                    }
                    numberStack.Push(result.ToString());
                }
               
            }

            return int.Parse(numberStack.Pop());
           
        }

        private bool IsNumber(string s)
        {
            return Regex.IsMatch(s, @"[\d]");
            
        }

        private int GetRank(string s)
        {
            int result =-1;
            switch (s)
            {
                case  "+":
                case  "-":
                    result = 2;

                    break;
                case "*":
                case "/":
                    result = 3;
                    break;
                case "(":
                    result = 1;
                    break;
            }
            return result; 
        }


    
    }
}
