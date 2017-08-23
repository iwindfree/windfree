using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample.Quiz.compare
{
    class BoxCompare
    {
        static void Main(string[] args)
        {
            List<Box> boxList = new List<Box>();
            boxList.Add(new compare.Box(10, 11, 12));
            boxList.Add(new compare.Box(20, 15, 9));
            boxList.Add(new compare.Box(20, 14, 34));
            boxList.Add(new compare.Box(20, 12, 8));
            boxList.Add(new compare.Box(20, 14, 19));
            boxList.Add(new compare.Box(11, 19, 30));
            boxList.Add(new compare.Box(9, 30, 40));

            boxList.Sort();
            foreach(Box b in boxList)
            {
                Console.Out.WriteLine("Box L:{0}, W:{1}, H:{2}", b.Length,b.Width,b.Height);
            }

            Console.ReadLine();
        }
    }
}
