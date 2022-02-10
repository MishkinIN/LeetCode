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
            TimeSpan span = new(1_000_0);
            var cts = new CancellationTokenSource(span);
            var cancel = cts.Token;
            // ...
            using (var mutex = new Mutex(false)) {
                Task job1 = Task.Factory.StartNew(() => {
                    mutex.WaitOne();
                    foo.First(printFirst);
                }, cancel, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                Task job2 = Task.Factory.StartNew(() => {
                    mutex.WaitOne();
                    foo.Second(printSecond);
                }, cancel, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                Task job3 = Task.Factory.StartNew(() => {
                    mutex.WaitOne();
                    foo.Third(printThird);
                }, cancel, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                mutex.ReleaseMutex();
                var result = Task.WhenAll(job1, job2, job3);
                try {
                    result.Wait();
                }
                catch (AggregateException ex) {
                    if (ex.InnerException is OperationCanceledException)
                        Console.Write($"Время выполнения теста превысило {span.TotalMilliseconds} мс.");
                }
            }
            string txt = sb.ToString();
            Console.WriteLine(txt);
        }

    }
}
