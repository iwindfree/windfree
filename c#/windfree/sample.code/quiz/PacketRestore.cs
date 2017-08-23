using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 패킷이 ID:데이터 형식으로 전송됨. 전송 순서는 무작위
 * 패킷은 최대 9개까지 전송됨
 * string[] packets = {"1I_LOVE","3G_CNS","4CNS!!","2VE_L"};
 * 패킷은 앞에 전송된 데이터와 3개까지 중복될 수 있음
 * 중복을 고려하여 복원된 데이터를 출력하라.
 * 단, 패킷이 유실될 수 있으며 유실될 경우 그 다음에 도착하는 패킷은 중복된 데이터가 없다고 가정
 * 유실될 경우도 유실된 것을 제외하고 merge 하여 출력
 * 패킷이 형식에 안맞을 경우 IlegalArgumentException 전송
 * 동일한 아이디로 반복해서 들어왔을 경우 처음 데이터만 인정하고 나머지는 버림.
 * 1:I_LOVE
 * 2:    VE_L
 * 3:        G_CNS
 * 4:          CNS!!
 * ->I_LOVE_LG_CNS!!
 */
namespace sample.Quiz
{
    class PacketRestore
    {
        public void Solve()
        {
            try
            {
                string[] packets = { "1I_LOVE", "3G_CNS", "4CNS!!", "2VE_L" ,"6hahaha" };
                Dictionary<int, string> dicPackes = new Dictionary<int, string>();

                foreach (string v in packets)
                {
                    string tempKey = v.Substring(0, 1);
                    int key = int.Parse(tempKey);
                    string value = v.Substring(1, v.Length - 1);
                    dicPackes.Add(key, value);
                }

                var sortDic = from value in dicPackes
                              orderby value.Key
                              select value;

                List<char> charList = new List<char>();
                for(int i = 0; i < sortDic.Count();i++)
                {
                    if(i == 0)
                    {
                        charList.AddRange(sortDic.ElementAt(0).Value.ToCharArray());
                    } else
                    {
                        if(sortDic.ElementAt(i-1).Key +1 != sortDic.ElementAt(i ).Key)
                        {
                            charList.AddRange(sortDic.ElementAt(i).Value.ToCharArray());
                            continue;
                        } else if(sortDic.ElementAt(i - 1).Key + 1 != sortDic.ElementAt(i).Key)
                        {
                            continue;
                        }
                        char[] beforeArr = sortDic.ElementAt(i - 1).Value.ToCharArray();
                        char[] currrentArr = sortDic.ElementAt(i ).Value.ToCharArray();
                        if (currrentArr[0] == beforeArr[beforeArr.Length - 1 - 2])
                        {
                            if (currrentArr[1] == beforeArr[beforeArr.Length - 1 - 1])
                            {
                                if (currrentArr[2] == beforeArr[beforeArr.Length - 1] )
                                {
                                    for(int j = 3; j < currrentArr.Length;j++)
                                    {
                                        charList.Add(currrentArr[j]);
                                    }
                                }
                            }
                        }else if (currrentArr[0] == beforeArr[beforeArr.Length - 1 - 1])
                        {
                            if (currrentArr[1] == beforeArr[beforeArr.Length - 1])
                            {
                                for (int j = 2; j < currrentArr.Length; j++)
                                {
                                    charList.Add(currrentArr[j]);
                                }
                            }
                        }else if (currrentArr[0] == beforeArr[beforeArr.Length - 1])
                        {
                            for (int j = 1; j < currrentArr.Length; j++)
                            {
                                charList.Add(currrentArr[j]);
                            }
                        } else
                        {
                            charList.AddRange(currrentArr);
                            continue;
                        }

                    }
                  
                }

                string result = new string(charList.ToArray());
                Console.Out.WriteLine(result);
            }catch (Exception)
            {

                throw;
            }
           
             

             
                    


        }
    }
}
