using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using LeetCode.Concurrency;
using System.Text;
using System.Threading.Tasks;

namespace Concurency.Test {
    [TestClass]
    public class TestFoo {
        [TestMethod]
        public void PrintOrder() {
            var foo = new Foo1114();
            StringBuilder sb = new();
            var printFirst = () => { sb.Append("A"); };
            var printSecond = () => { sb.Append("B"); };
            var printThird = () => { sb.Append("C"); };
            string expected = "ABC";
            int errCount = 0;
            TimeSpan span = new(2_000_0);
            string log = String.Empty;
            
            for (int i = 0; i < 10; i++) {
                sb.Clear();
                var cts = new CancellationTokenSource(span);
                var cancel = cts.Token;
                long threadCount = 0;
                using (var ewh = new EventWaitHandle(false, EventResetMode.ManualReset)) {
                    Task job1 = Task.Factory.StartNew(() => {
                        Interlocked.Increment(ref threadCount);
                        ewh.WaitOne();
                        foo.First(printFirst);
                    }, cancel, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                    Task job2 = Task.Factory.StartNew(() => {
                        Interlocked.Increment(ref threadCount);
                        ewh.WaitOne();
                        foo.Second(printSecond);
                    }, cancel, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                    Task job3 = Task.Factory.StartNew(() => {
                        Interlocked.Increment(ref threadCount);
                        ewh.WaitOne();
                        foo.Third(printThird);
                    }, cancel, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                    while (Interlocked.Read(ref threadCount) < 3 && !cancel.IsCancellationRequested) {
                        Thread.Sleep(1);
                    }
                    if (cancel.IsCancellationRequested)
                        Console.WriteLine($"На цикле {i} операция отменена.");
                    ewh.Set();
                    var result = Task.WhenAll(job1, job2, job3);
                    try {
                        result.Wait();
                    }
                    catch (AggregateException ex) {
                        if (ex.InnerException is OperationCanceledException)
                            log = $"На цикле {i} время выполнения превысило {span.TotalMilliseconds} мс.";
                    }
                }
                string txt = sb.ToString();
                Console.WriteLine(txt);
                if (txt != expected)
                    errCount++;
            }
            if (log != String.Empty)
                Console.WriteLine(log);
            Assert.AreEqual(0, errCount);
        }

    }
}
