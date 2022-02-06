using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;


namespace Concurency.Test {
    [TestClass]
    public class UnitTestThreading {
        [TestMethod]
        public void TestMethod1() {
            string s = "Создание нового потока из тела подпрограммы WriteY";
            Thread t = new Thread(() => Log(s));
            // Запуск потока:
            t.Start();
            // Вместе с работающим потоком внутри WriteY() также будем
            // выполнять что-нибудь в главном потоке приложения:
            for (int i = 0; i < 1000; i++)
                Console.Write("x");
        }
        public static void Log(string s) {
            Console.WriteLine(s);
        }
        [TestMethod]
        public void TestMethod2() {
            new Thread(Go).Start();   // Вызов Go() в новом потоке.
            Go();                      // Вызов Go() в основном потоке приложения.
        }
        static void Go() {
            // Декларирование и использование локальной переменной cycles:
            for (int cycles = 0; cycles < 1000; cycles++)
                Console.Write($"|{cycles}|");
        }
        [TestMethod]
        public void TestMethod3() {
               // Создание общего экземпляра
            for (int i = 0; i < 5; i++) {
                ThreadTest tt = new();
                new Thread(tt.Go).Start(); 
            }
            //tt.Go();
        }

    }
    public class ThreadTest {
        static bool done;
        // Обратите внимание, что Go теперь метод экземпляра:
        internal void Go() {
            if (!done) {
               Console.WriteLine("Done");
                 done = true;
            }
        }

    }
}