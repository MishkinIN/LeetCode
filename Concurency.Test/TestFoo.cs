using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using LeetCode.Concurrency;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Concurency.Test {
    [TestClass]
    public class TestFoo {
        /// <summary>
        /// TaskStatus_Bit_Completed
        /// </summary>
        const int Tsbc = 0x4;
        [TestMethod]
        public void PrintOrder() {
            var foo = new Foo1114();
            StringBuilder sb = new();
            SpinLock sl = new();
            //var printFirst = () => { sb.Append("A"); };
            //var printSecond = () => { sb.Append("B"); };
            //var printThird = () => { sb.Append("C"); };
            var printFirst = () =>  Log(ref sl, sb,"A"); 
            var printSecond = () => Log(ref sl, sb, "B");
            var printThird = () => Log(ref sl, sb, "C");
            string expected = "ABC";
            int errCount = 0;
            TimeSpan span = new(100_000_0);
            string log = String.Empty;
            Stopwatch sw = new();
            sw.Start();
            Console.WriteLine($"StopWatch frequensy is {Stopwatch.Frequency}");


            for (int i = 0; i < 10000; i++) {
                sb.Clear();
                sw.Restart();
                var cts = new CancellationTokenSource(span);
                var cancel = cts.Token;
                Barrier _jobsBarrier = new Barrier(3);
                long threadCount = 0;
                long? job1Start = 0, job2Start = 0, job3Start = 0;
                using (var ewh = new EventWaitHandle(false, EventResetMode.ManualReset)) {
                    Task job1 = Task.Factory.StartNew(() => {
                        Interlocked.Increment(ref threadCount);
                        ewh.WaitOne();
                        //_jobsBarrier.SignalAndWait();
                        job1Start = sw.ElapsedTicks;
                        foo.First(printFirst);
                    }, cancel, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                    Task job2 = Task.Factory.StartNew(() => {
                        Interlocked.Increment(ref threadCount);
                        ewh.WaitOne();
                        //_jobsBarrier.SignalAndWait();
                        job2Start = sw.ElapsedTicks;
                        foo.Second(printSecond);
                    }, cancel, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                    Task job3 = Task.Factory.StartNew(() => {
                        Interlocked.Increment(ref threadCount);
                        ewh.WaitOne();
                        //_jobsBarrier.SignalAndWait();
                        job3Start = sw.ElapsedTicks;
                        foo.Third(printThird);
                    }, cancel, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                    while (Interlocked.Read(ref threadCount) < 3 && !cancel.IsCancellationRequested) {
                        Thread.Sleep(1);
                    }
                    ewh.Set();
                    var result = Task.WhenAll(job1, job2, job3);
                    try {
                        result.Wait();
                    }
                    catch (AggregateException ex) {
                        if (ex.InnerException is OperationCanceledException)
                            Console.WriteLine($"На цикле {i} время выполнения превысило {span.TotalMilliseconds} мс.");
                    }
                    Assert.AreEqual(Tsbc, (int)job1.Status & Tsbc);
                    Assert.AreEqual(Tsbc, (int)job2.Status & Tsbc);
                    Assert.AreEqual(Tsbc, (int)job3.Status & Tsbc);
                }

                string txt = sb.ToString();
       
                if (txt.Length < 3) {
                    Console.WriteLine($"step {i}, txt={txt}");
                    Console.WriteLine($"job1Start-job2Start={job1Start - job2Start}");
                    Console.WriteLine($"job1Start-job3Start={job1Start - job3Start}");
                }
                if (txt != expected)
                    errCount++;
            }
            if (log != String.Empty)
                Console.WriteLine(log);
            Assert.AreEqual(0, errCount);
        }
        private static void Log(ref SpinLock sl, StringBuilder sb, string s) {
            bool gotLock = false;
            try {
                sl.Enter(ref gotLock);
                sb.Append(s);
            }
            finally {
                // Only give up the lock if you actually acquired it
                if (gotLock)
                    sl.Exit();
            }
        }
    }
}
