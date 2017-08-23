using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Quiz
{
    class Masking
    {
       // string name = "김경남";
       // string RRN = "730301-1953927";
      //  string card = "4543-3333-2222-2222";
        public string MaskName(string name)
        {
            if (!IsValidName(name))
            {
                throw new Exception("Not a valid name");
            }
            //return name.Substring(0, 1).PadRight(name.Length, '*');
            return masking(name, 1, ' ');
        }

        public string MaskRrn(string rrn)
        {
            string[] arr = rrn.Split('-');
            if (IsNumber(arr[0]) && IsNumber(arr[1]))
            {
                int pos = rrn.IndexOf('-');
                // return rrn.Substring(0, pos+2).PadRight(rrn.Length, '*');
                return masking(rrn, pos + 2, '-');
            }
            else
            {
                throw new Exception("Not a valid rrn");
            }
        }

        public string MaskCard(string cardNum)
        {
            string[] arr = cardNum.Split('-');
            bool result = true;
            foreach (string v in arr)
            {
                result = result & IsNumber(v);
            }
            if (!result)
            {
                throw new Exception("not a valid card number");
            }
            return masking(cardNum, 2, '-');
        }

        private bool IsNumber(string value)
        {
            return Regex.IsMatch(value, @"^\d+$");
        }

        private bool IsValidName(string name)
        {
            if (Regex.IsMatch(name, @"^[가-힣]*$"))
            {
                return true;
            }
            return false;
        }

        private string masking(string origin, int from, char escape)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < origin.Length; i++)
            {
                if (i < from)
                {
                    sb.Append(origin.ElementAt(i));
                }
                else
                {
                    if (origin.ElementAt(i) == escape)
                    {
                        sb.Append(origin.ElementAt(i));
                    }
                    else
                    {
                        sb.Append('*');
                    }
                }
            }
            return sb.ToString();
        }
    }
}
