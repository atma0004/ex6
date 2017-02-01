using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ex05_Tuesday_5
    {
    class Program
        {
        static object _lock = new object();
        static void Main(string[] args)
            {
            Thread myThread1 = new Thread(new ThreadStart(counter1));
            Thread myThread2 = new Thread(new ThreadStart(counter2));
            myThread1.Start();

            myThread2.Start();

            myThread1.Join();
            myThread2.Join();
            
            }

        public static void counter1()
            {

            int i;
            for (i=60; i<=900; i=i+60+60)
                {
                Monitor.Enter(_lock);
                try {
                    Console.WriteLine("#######################################################################"+i);
                    Thread.Sleep(1000);
                    }
                finally
                    {
                    Monitor.Exit(_lock);
                    }
                }
            }
        public static void counter2()
            {

            int i;
           
                
                for (i=120; i<1080; i=i+60+60)
                {
                Monitor.Enter(_lock);
                try
                    {
                    Console.WriteLine("***********************************************************************"+i);
                    Thread.Sleep(500);

                    }
                finally
                    {
                    Monitor.Exit(_lock);
                    }
                }              
            }
        }
    }