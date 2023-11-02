using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace threatExample.Models
{
    internal class Monitor
    {
        private ThreadSafeNumberList numberList;
        private int interval;

        //конструктор монитора с присоединением ссылки на список и указание интервала отображения
        public Monitor(ThreadSafeNumberList numberList,int interval)
        {
            this.numberList = numberList;
            this.interval = interval;
        }
        //запуск просмотра списка 
        public void Run()
        {
            while (true)
            {
                Console.WriteLine(numberList.ToString());
                Thread.Sleep(interval);
            }
        }

    }
}
