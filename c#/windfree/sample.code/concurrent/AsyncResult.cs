using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sample.code.concurrent
{
    class AsyncResult
    {
        static void Main(string[] args)
        {
            var myTask = Task<List<int>>.Run(() =>
            {
                Thread.Sleep(1000);
                List<int> list = new List<int>();
                list.Add(10);
                list.Add(20);
                list.Add(30);
                return list;
            });

            var myList = new List<int>();
            myList.Add(50);
            myList.Add(60);
            myTask.Wait();
            myList.AddRange(myTask.Result.ToArray());

            foreach (int n in myList)
            {
                Console.Out.WriteLine(n);
            }
            Console.ReadLine();
        }
    }
}
