using System;
using System.Threading;

namespace DistributedComputing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************************** 分布式计算 1+2+3+...+n **************************");

            // {
            //     // 直接计算 1+2+3+....+100=?
            //
            //     // 如果我们分开计算 1+2+3+....+100=?，比如分为 4 个区段进行计算
            //     // 100/4 = 25  1-25,26-50,51-75,76-100
            //     var summation = new Summation();
            //
            //     // Console.Write($"结果：{summation.Sum()}");
            //     Console.WriteLine($"线程编号：{Thread.CurrentThread.ManagedThreadId}，总和：{summation.Sum()}");
            // }

            {
                var summation1 = new Summation(9);
                Console.WriteLine($"线程编号：{Thread.CurrentThread.ManagedThreadId}，总和：{summation1.Sum(89)}");
            }

            Console.ReadKey();
        }
    }
}
