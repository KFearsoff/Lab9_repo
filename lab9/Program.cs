using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Задание: создать класс Time с публичными полями Hours и Minutes и приватным полем Seconds.
             * Проверять данные на адекватность и вести подсчет количества элементов типа Time. 
             * Реализовать обычный и статичный методы AddSeconds для добавления секунд. Перегрузить операторы ++, --,
             * + (с обоих сторон), - (с обоих сторон), неявное приведение к int, явное приведение к bool.
             * Реализовать метод, выводящий данные о классе Time на консоль. Создать класс TimeArray,
             * который хранит массив элементов типа Time, перегрузить в нем индексатор. Реализовать метод для поиска среднего
             * времени по массиву и метод для вывода всех элементов массива на экран.
             */
            Time time1 = new Time();
            Time time2 = new Time(12, 12);
            Time time3 = new Time(13, 13, 13);
            Time time4 = new Time(13, 13, 13);
            time1.Show();
            time2.Show();
            time3.Show();
            time3.AddSeconds(60);
            time3.Show();
            time4.Show();
            Time.AddSeconds(time4, 60);
            time4.Show();
            time4++;
            time4.Show();
            (time4 + 55).Show();
            (time4 - 55).Show();
            Console.WriteLine(Time.Count);

            TimeArray ta = new TimeArray(time2, time3, time4);
            Console.WriteLine();
            ta.ShowAll();
            ta.FindAverage().Show();
        }
    }
}
