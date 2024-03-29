﻿using System;
using System.Threading.Tasks;

namespace LeetCode.Concurrency {
    /*
     * 1114. Print in Order
     * Easy
     * Suppose we have a class:
     * The same instance of Foo will be passed to three different threads. 
     * Thread A will call first(), thread B will call second(), and thread C will call third(). 
     * Design a mechanism and modify the program to ensure that second() is executed after first(), and third() is executed after second().
     * Note:
     * We do not know how the threads will be scheduled in the operating system, 
     * even though the numbers in the input seem to imply the ordering. 
     * The input format you see is mainly to ensure our tests' comprehensiveness.
     * 
     */
    public class Foo1114 {
        private Task Job1;
        private Task Job2;
        private Task Job3;
        public Foo1114() {

        }

        public void First(Action printFirst) {

            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();
        }

        public void Second(Action printSecond) {

            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();
        }

        public void Third(Action printThird) {

            // printThird() outputs "third". Do not change or remove this line.
            printThird();
        }
    
    }
}
