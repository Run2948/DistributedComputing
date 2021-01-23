#  分布式计算

## 计算 1 + 2 + 3 + ... + n = ?

```csharp
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
```



```csharp
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
    }
```





```csharp
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************************** 分布式计算 1+2+3+...+n **************************");

                var summation1 = new Summation(9);
                Console.WriteLine($"线程编号：{Thread.CurrentThread.ManagedThreadId}，总和：{summation1.Sum(89)}");

            Console.ReadKey();
        }
    }
```



```bash
*************************** 分布式计算 1+2+3+...+n **************************
线程编号：4， 1 +...+ 11 = 66
线程编号：4， 12 +...+ 22 = 187
线程编号：4， 23 +...+ 33 = 308
线程编号：4， 34 +...+ 44 = 429
线程编号：4， 45 +...+ 55 = 550
线程编号：4， 56 +...+ 66 = 671
线程编号：4， 67 +...+ 77 = 792
线程编号：4， 78 +...+ 88 = 913
线程编号：4， 89 = 89
线程编号：1，总和：4005
```

