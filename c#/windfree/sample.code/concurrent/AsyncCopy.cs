using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sample.code.concurrent
{
    class AsyncCopy
    {
        static void Main(string[] args)
        {
            string src = args[0];
            Action<object> FileCopyAction = (object state) =>
            {
                string[] paths = (string[])state;
                File.Copy(paths[0], paths[1]);
            };

            Task t1 = new Task(FileCopyAction, new string[] { src, src + ".copy" });
            t1.Start();

            Task t2 = Task.Run(() =>
            {
                FileCopyAction(new string[] { src, src + ".copy2" });

            });
           

            t1.Wait();
            t2.Wait();

           
        }
    }
}
