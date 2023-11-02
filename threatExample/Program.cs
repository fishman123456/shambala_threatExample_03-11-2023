using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using threatExample.Models;

namespace threatExample
{
    internal class Program
    {
        public static void RunMonitor()
        {
            //1.создание объектов
            ThreadSafeNumberList numberList = new ThreadSafeNumberList();
            Monitor monitor = new Monitor(numberList, 1000);
            //подключение потока для монитора
            System.Threading.Thread monitorThread = new System.Threading.Thread(monitor.Run);
            //2. запуск монитора
            monitorThread.Start();
        }
        public static void RunGeneratorMonitor()
        {
            // создаем объекты
            ThreadSafeNumberList numberList = new ThreadSafeNumberList();
            Monitor monitor = new Monitor(numberList, 1000);
            Random random = new Random();
            Generator generator = new Generator(numberList, 10, random, 0, 10, 3000);
            //запускае потоки
            System.Threading.Thread monitorThread = new System.Threading.Thread(monitor.Run);
            System.Threading.Thread generatorThread = new System.Threading.Thread(generator.Run);
            monitorThread.Start();
            generatorThread.Start();

        }
        public static void RunCunsumer()
        {
            //создаем объекты
            ThreadSafeNumberList numberList = new ThreadSafeNumberList();
            Monitor monitor = new Monitor(numberList, 10);
            Random random = new Random();
            Generator generator = new Generator(numberList, 10, random, 0, 10, 30);
            Consumer consumer = new Consumer(numberList, random, 5, 15,10);
            //запуск потоков
            System.Threading.Thread monitorThread = new System.Threading.Thread(monitor.Run);
            System.Threading.Thread generatorThread = new System.Threading.Thread (generator.Run);
            System.Threading.Thread consumerThread = new System.Threading.Thread(consumer.Run);
            monitorThread.Start();
            generatorThread.Start();
            consumerThread.Start();
        }
        static void Main(string[] args)
        {
            // ЗАДАЧА: написать программу наполнения списка случайных чисел

            // существует 2 типа потоков:
            // 1) генератор - поток обеспечивает существование списка случайных чисел заданной длины
            // если длина списка становится меньше чем заданная длина, то генератор дописывает случайные числа в список

            // 2) потребители - потоки, которые обращаются к списку случайных чисел и извлекают из него
            // случайные числа в заданном количестве с конца (если чисел меньше, то извлекаем сколько есть)
            // при извлечение чисел они удаляются из списка

            //  3) монитор - поток, который переодически выводит на экран содержимое списка +
            //RunMonitor();
            //RunGeneratorMonitor();
            RunCunsumer();
        }
    }
}
