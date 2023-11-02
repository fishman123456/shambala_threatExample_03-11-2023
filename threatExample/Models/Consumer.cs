using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace threatExample.Models
{
    internal class Consumer
    {       // 2) потребители - потоки, которые обращаются к списку случайных чисел и извлекают из него
            // случайные числа в заданном количестве с конца (если чисел меньше, то извлекаем сколько есть)
            // при извлечение чисел они удаляются из списка

        private ThreadSafeNumberList numberList;
        private Random random;
        private int maxInterval;
        private int minInterval;
        private int maxCount;
        public Consumer(ThreadSafeNumberList numberList, Random random, int minInterval, int maxInterval, int maxCount)
        {
            this.numberList = numberList;
            this.random = random;
            this.maxInterval = maxInterval;
            this.minInterval = minInterval;
            this.maxCount = maxCount;
        }
        public void Run()
        {
            while (true)
            {
                int countNumbers = random.Next(1,maxCount+1);
                numberList.GetNumbers(countNumbers);
                int interval = random.Next(minInterval, maxInterval);
                Thread.Sleep(interval);
            }
        }
    }
}
