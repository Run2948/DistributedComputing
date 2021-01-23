using System;
using System.Threading;
using System.Threading.Tasks;

namespace DistributedComputing
{
    /// <summary>
    /// 线程求和类
    /// </summary>
    public class ThreadSum
    {
        /// <summary>
        /// 开始计算
        /// </summary>
        private readonly int _start;

        /// <summary>
        /// 结束计算
        /// </summary>
        private readonly int _end;

        public ThreadSum(int start, int end)
        {
            this._start = start;
            this._end = end;
        }

        public async Task<int> SumAsync()
        {
            return await Task.Run(() =>
            {
                var sum = 0;
                for (var i = _start; i <= _end; i++)
                {
                    sum += i;
                }

                Console.WriteLine(
                    $"线程编号：{Thread.CurrentThread.ManagedThreadId}， {(_start < _end ? $"{_start} +...+ {_end}" : $"{_end}")} = {sum}");
                return sum;
            });
        }
    }
}