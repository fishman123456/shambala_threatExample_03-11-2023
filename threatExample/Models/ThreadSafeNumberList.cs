using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threatExample
{
    internal class ThreadSafeNumberList
    {
        private List<int> numbers;
        public ThreadSafeNumberList()
        {
            numbers = new List<int>();
        }
        // колличество значений в листе
        public int NumberCount
        {
            get
            {
                return numbers.Count;
            }
        }
        //добавить новые значения в лист 
        public void AddNumbers(List<int> newNumbers)
        {
            numbers.AddRange(newNumbers);
        }
        // получить и стереть ряд чисел 
        public List<int> GetNumbers(int countNumbers)
        {
            int count = Math.Min(countNumbers, numbers.Count);
            int start = Math.Max(0, NumberCount - countNumbers);
            
            var getNum = numbers.GetRange(start, count);
            numbers.RemoveRange(start, count);
            return getNum;
        }

        //вывести значение листа
        public override string ToString() 
        {
            StringBuilder sb = new StringBuilder();
            foreach (var number in numbers)
            {
                sb.Append(number).Append(" ");
            }
            return $"size: {numbers.Count}; numbers: {sb}";        
        }
    }
}
