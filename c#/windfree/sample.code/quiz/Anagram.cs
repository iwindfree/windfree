using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample.Quiz
{
    /*
     * Anagram : 어떤 단어의 문자를 재배열하여 다른 단어를 만드는 것. 
     * 단어 두개가 주어졌을 때 anagram 여부를 리턴하는 함수를 작성하시오.
     * 예) "dirty room", "domitory" => true
     */
    class Anagram
    {
        public void Solve()
        {
            string value1 = "dirty room";
            string value2 = "dormitory";

            bool result = IsAnagram(value1, value2);
            Console.WriteLine(result);
        }

        private bool IsAnagram(string value1, string value2)
        {
            bool result = true;
            Dictionary<char, int> dicValue1 = GetWordList(value1);
            Dictionary<char, int> dicValue2 = GetWordList(value2);

            if(dicValue1.Count == dicValue2.Count)
            {
                foreach(KeyValuePair<char,int> pair in dicValue1)
                {
                    if(dicValue2.ContainsKey(pair.Key) && dicValue2[pair.Key] == pair.Value )
                    {
                        result = (result && true);
                    } else
                    {
                        return false;
                    }
                } 
            } else
            {
                return false;
            }
            return true;

        }

        private Dictionary<char,int> GetWordList(string str)
        {
            Dictionary<char, int> dicWords = new Dictionary<char, int>();
           
            char[] arr = str.ToCharArray();
         

            foreach (char c in arr)
            {
                if (c != ' ')
                {
                    if (!dicWords.ContainsKey(c))
                    {
                        dicWords.Add(c, 1);
                    }
                    else
                    {
                        dicWords[c]++;
                    }
                }
            }
            return dicWords;
        }
    }
}
