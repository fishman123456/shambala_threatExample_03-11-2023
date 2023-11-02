using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace threatExample.Models
{
    internal class Generator
    {
        private ThreadSafeNumberList numbersList;
        private int listLimit;
        private Random random;
        private int minValue;
        private int maxValue;
        private int interval;
        //конструктор с сылкой на лист и с указанием размера
        public Generator(ThreadSafeNumberList numbersList, int listLimit, Random random, int minValue, int maxValue, int interval)
        {
            this.numbersList = numbersList;
            this.listLimit = listLimit;
            this.random = random;
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.interval = interval;
        }
              
        public void Run()
        {
            while (true)
            {
                int NumberCount = numbersList.NumberCount;
                if (NumberCount < listLimit)
                {
                    List<int> numbers = new List<int>();
                    for (int i = 0; i < listLimit - NumberCount; i++)
                    {
                        numbers.Add(random.Next(minValue, maxValue));
                    }
                    numbersList.AddNumbers(numbers);
                }

                Thread.Sleep(interval);
            }
        }
    }
}
