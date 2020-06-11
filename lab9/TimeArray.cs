using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class TimeArray
    {
        Time[] array;
        int size = 64;

        public TimeArray()
        {
            array = new Time[size];
        }

        public TimeArray(bool IsRandom)
        {
            array = new Time[size];
            if (IsRandom)
            {
                Random rand = new Random();
                for (int i = 0; i < size; i++)
                    array[i] = new Time(rand.Next(0, 24), rand.Next(0, 60), rand.Next(0, 60));
            }
        }

        public TimeArray(params Time[] timeArray)
        {
            size = timeArray.Length;
            array = new Time[size];
            for (int i = 0; i < size; i++)
                array[i] = timeArray[i];
        }

        public Time this[int index]
        {
            get
            {
                if (index < 0 || index >= size) throw new IndexOutOfRangeException();
                else return array[index];
            }
            set
            {
                if (index < 0 || index >= size) throw new IndexOutOfRangeException();
                else array[index] = value;
            }
        }

        public void ShowAll()
        {
            foreach (var c in array)
                c.Show();
        }

        public Time FindAverage()
        {
            double hoursTotal = 0;
            double minutesTotal = 0;
            foreach (var c in array)
            {
                hoursTotal += c.Hours;
                minutesTotal += c.Minutes;
            }
            hoursTotal /= size;
            minutesTotal /= size;
            int hoursTotalInt = (int)Math.Floor(hoursTotal);
            int minutesTotalInt = (int)Math.Floor(minutesTotal + (hoursTotal - hoursTotalInt) * 60);
            return new Time(hoursTotalInt, minutesTotalInt);
        }
    }
}
