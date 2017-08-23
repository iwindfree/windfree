using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sample.code.concurrent
{
    class ThreadPool2
    {
        public void Do()
        {
            const int FibonacciCalculations = 10;

            // One event is used for each Fibonacci object.  
            
            CountdownEvent countdownEvent = new CountdownEvent(1);
            Fibonacci2[] fibArray = new Fibonacci2[FibonacciCalculations];
            Random r = new Random();

            // Configure and start threads using ThreadPool.  
            Console.WriteLine("launching {0} tasks...", FibonacciCalculations);
            for (int i = 0; i < FibonacciCalculations; i++)
            {
                countdownEvent.AddCount();
                Fibonacci2 f = new Fibonacci2(r.Next(20, 40), countdownEvent);
                fibArray[i] = f;
                ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
            }

            // Wait for all threads in pool to calculate.  
            countdownEvent.Signal();
            countdownEvent.Wait();
            Console.WriteLine("All calculations are complete.");

            // Display the results.  
            for (int i = 0; i < FibonacciCalculations; i++)
            {
                Fibonacci2 f = fibArray[i];
                Console.WriteLine("Fibonacci({0}) = {1}", f.N, f.FibOfN);
            }
        }
    }

    public class Fibonacci2
    {
        private int _n;
        private int _fibOfN;
        CountdownEvent countdownEvent;

        public int N { get { return _n; } }
        public int FibOfN { get { return _fibOfN; } }

        // Constructor.  
        public Fibonacci2(int n, CountdownEvent countdownEvent)
        {
            _n = n;
            this.countdownEvent = countdownEvent;
        }

        // Wrapper method for use with thread pool.  
        public void ThreadPoolCallback(Object threadContext)
        {
            
            int threadIndex = (int)threadContext;
            Console.WriteLine("thread {0} started...", threadIndex);
            _fibOfN = Calculate(_n);
            Console.WriteLine("thread {0} result calculated...", threadIndex);
            countdownEvent.Signal();
        }

        // Recursive method that calculates the Nth Fibonacci number.  
        public int Calculate(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return Calculate(n - 1) + Calculate(n - 2);
        }
    }
}
