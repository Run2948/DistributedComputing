using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DistributedComputing
{
    public class Summation
    {
        private readonly int _threadCount;

        public Summation()
        {
        }

        public Summation(int threadCount)
        {
            this._threadCount = threadCount;
        }

        /// <summary>
        /// 计算 1+2+3+....+100=?
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            var sum = 0;

            {
                // for (var i = 1; i <= 100; i++)
                // {
                //     sum += i;
                // }
            }

            {
                // sum = Sum1() + Sum2() + Sum3() + Sum4();
            }

            {
                // sum = TaskSum1() + TaskSum2() + TaskSum3() + TaskSum4();
            }

            {
                // sum = TaskSum1Async().Result + TaskSum2Async().Result + TaskSum3Async().Result + TaskSum4Async().Result;
            }

            {
                for (var i = 0; i < 4; i++)
                {
                    // 1.计算开始与结束
                    var start = 25 * i + 1;
                    var end = 25 * (i + 1);
                    var threadSum = new ThreadSum(start, end);
                    sum += threadSum.SumAsync().Result;
                }
            }

            return sum;
        }

        /// <summary>
        /// 计算 1+2+3+....+n=?
        /// </summary>
        /// <returns></returns>
        public int Sum(int n)
        {
            var sum = 0;
            // var progress = new List<string>();
            var threadUnit = n % _threadCount == 0 ? n / _threadCount : n / (_threadCount - 1);

            for (var i = 0; i < _threadCount; i++)
            {
                // 1.计算开始与结束
                var start = threadUnit * i + 1;
                var end = threadUnit * (i + 1) > n ? n : threadUnit * (i + 1);
                var threadSum = new ThreadSum(start, end);
                // progress.Add($"{start}+...+{end}");
                sum += threadSum.SumAsync().Result;
            }

            // Console.WriteLine($"{string.Join(" + ", progress)} = {sum}");
            return sum;
        }

        #region Four Steps

        /// <summary>
        /// 1-25
        /// </summary>
        /// <returns></returns>
        public int Sum1()
        {
            var sum = 0;
            for (var i = 1; i <= 25; i++)
            {
                sum += i;
            }

            return sum;
        }

        /// <summary>
        /// 26-50
        /// </summary>
        /// <returns></returns>
        public int Sum2()
        {
            var sum = 0;
            for (var i = 26; i <= 50; i++)
            {
                sum += i;
            }

            return sum;
        }

        /// <summary>
        /// 51-75
        /// </summary>
        /// <returns></returns>
        public int Sum3()
        {
            var sum = 0;
            for (var i = 51; i <= 75; i++)
            {
                sum += i;
            }

            return sum;
        }

        /// <summary>
        /// 76-100
        /// </summary>
        /// <returns></returns>
        public int Sum4()
        {
            var sum = 0;
            for (var i = 76; i <= 100; i++)
            {
                sum += i;
            }

            return sum;
        }

        #endregion

        #region Four Task Steps

        /// <summary>
        /// 1-25
        /// </summary>
        /// <returns></returns>
        public int TaskSum1()
        {
            var task = Task.Run(() =>
            {
                var sum = 0;
                for (var i = 1; i <= 25; i++)
                {
                    sum += i;
                }

                Console.WriteLine($"线程编号：{Thread.CurrentThread.ManagedThreadId}，计算结果：{sum}");
                return sum;
            });

            // 获取 Task 线程计算的结果
            return task.Result;
        }

        /// <summary>
        /// 26-50
        /// </summary>
        /// <returns></returns>
        public int TaskSum2()
        {
            var task = Task.Run(() =>
            {
                var sum = 0;
                for (var i = 26; i <= 50; i++)
                {
                    sum += i;
                }

                Console.WriteLine($"线程编号：{Thread.CurrentThread.ManagedThreadId}，计算结果：{sum}");
                return sum;
            });

            // 获取 Task 线程计算的结果
            return task.Result;
        }

        /// <summary>
        /// 51-75
        /// </summary>
        /// <returns></returns>
        public int TaskSum3()
        {
            var task = Task.Run(() =>
            {
                var sum = 0;
                for (var i = 51; i <= 75; i++)
                {
                    sum += i;
                }

                Console.WriteLine($"线程编号：{Thread.CurrentThread.ManagedThreadId}，计算结果：{sum}");
                return sum;
            });

            // 获取 Task 线程计算的结果
            return task.Result;
        }

        /// <summary>
        /// 76-100
        /// </summary>
        /// <returns></returns>
        public int TaskSum4()
        {
            var task = Task.Run(() =>
            {
                var sum = 0;
                for (var i = 76; i <= 100; i++)
                {
                    sum += i;
                }

                Console.WriteLine($"线程编号：{Thread.CurrentThread.ManagedThreadId}，计算结果：{sum}");
                return sum;
            });

            // 获取 Task 线程计算的结果
            return task.Result;
        }

        #endregion

        #region Four Async Task Steps

        /// <summary>
        /// 1-25
        /// </summary>
        /// <returns></returns>
        public async Task<int> TaskSum1Async()
        {
            return await Task.Run(() =>
            {
                var sum = 0;
                for (var i = 1; i <= 25; i++)
                {
                    sum += i;
                }

                Console.WriteLine($"线程编号：{Thread.CurrentThread.ManagedThreadId}，计算结果：{sum}");
                return sum;
            });
        }

        /// <summary>
        /// 26-50
        /// </summary>
        /// <returns></returns>
        public async Task<int> TaskSum2Async()
        {
            return await Task.Run(() =>
            {
                var sum = 0;
                for (var i = 26; i <= 50; i++)
                {
                    sum += i;
                }

                Console.WriteLine($"线程编号：{Thread.CurrentThread.ManagedThreadId}，计算结果：{sum}");
                return sum;
            });
        }

        /// <summary>
        /// 51-75
        /// </summary>
        /// <returns></returns>
        public async Task<int> TaskSum3Async()
        {
            return await Task.Run(() =>
            {
                var sum = 0;
                for (var i = 51; i <= 75; i++)
                {
                    sum += i;
                }

                Console.WriteLine($"线程编号：{Thread.CurrentThread.ManagedThreadId}，计算结果：{sum}");
                return sum;
            });
        }

        /// <summary>
        /// 76-100
        /// </summary>
        /// <returns></returns>
        public async Task<int> TaskSum4Async()
        {
            return await Task.Run(() =>
            {
                var sum = 0;
                for (var i = 76; i <= 100; i++)
                {
                    sum += i;
                }

                Console.WriteLine($"线程编号：{Thread.CurrentThread.ManagedThreadId}，计算结果：{sum}");
                return sum;
            });
        }

        #endregion
    }
}