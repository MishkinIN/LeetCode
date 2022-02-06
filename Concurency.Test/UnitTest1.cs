using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;


namespace Concurency.Test {
    [TestClass]
    public class UnitTestThreading {
        [TestMethod]
        public void TestMethod1() {
            string s = "�������� ������ ������ �� ���� ������������ WriteY";
            Thread t = new Thread(() => Log(s));
            // ������ ������:
            t.Start();
            // ������ � ���������� ������� ������ WriteY() ����� �����
            // ��������� ���-������ � ������� ������ ����������:
            for (int i = 0; i < 1000; i++)
                Console.Write("x");
        }
        public static void Log(string s) {
            Console.WriteLine(s);
        }
        [TestMethod]
        public void TestMethod2() {
            new Thread(Go).Start();   // ����� Go() � ����� ������.
            Go();                      // ����� Go() � �������� ������ ����������.
        }
        static void Go() {
            // �������������� � ������������� ��������� ���������� cycles:
            for (int cycles = 0; cycles < 1000; cycles++)
                Console.Write($"|{cycles}|");
        }
        [TestMethod]
        public void TestMethod3() {
               // �������� ������ ����������
            for (int i = 0; i < 5; i++) {
                ThreadTest tt = new();
                new Thread(tt.Go).Start(); 
            }
            //tt.Go();
        }

    }
    public class ThreadTest {
        static bool done;
        // �������� ��������, ��� Go ������ ����� ����������:
        internal void Go() {
            if (!done) {
               Console.WriteLine("Done");
                 done = true;
            }
        }

    }
}