using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        public int Hours
        {
            get { return hours; }
            set
            {
                if (value >= 0 && value < 24) hours = value;
                else if (value >= 0) hours = value % 24;
            }
        }
        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value >= 0 && value < 60) minutes = value;
                else if (value >= 0)
                {
                    minutes = value % 60;
                    hours += value / 60;
                }
            }
        }
        private int Seconds
        {
            get { return seconds; }
            set
            {
                if (value >= 0 && value < 60) seconds = value;
                else if (value >= 0)
                {
                    seconds = value % 60;
                    minutes += value / 60;
                }
            }
        }
        public static int Count { get; private set; } = 0;

        public Time()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
            Count++;
        }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
            seconds = 0;
            Count++;
        }

        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Count++;
        }

        public void Show()
        {
            Console.WriteLine(hours + ":" + minutes + ":" + seconds);
        }

        public Time AddSeconds(int seconds)
        {
            Seconds += seconds;
            return this;
        }

        public static Time AddSeconds(Time time, int seconds)
        {
            time.Seconds += seconds;
            return time;
        }

        #region Unary operators
        public static Time operator ++(Time time)
        {
            time.Minutes++;
            return time;
        }

        public static Time operator --(Time time)
        {
            if (time.Minutes > 0) time.Minutes--;
            else if (time.Hours > 0)
            {
                time.Hours--;
                time.Minutes = 59;
            }
            else
            {
                time.Hours = 23;
                time.Minutes = 59;
            }
            return time;
        }

        public static implicit operator int(Time time) => time.Minutes;
        public static explicit operator bool(Time time)
        {
            if (time.Minutes == 0 && time.Seconds == 0) return false;
            else return true;
        }
        #endregion
        #region Binary operators
        public static Time operator +(Time time, int minutes)
        {
            time.Minutes += minutes;
            return time;
        }

        public static Time operator +(int minutes, Time time)
        {
            time.Minutes += minutes;
            return time;
        }

        public static Time operator -(Time time, int minutes)
        {
            if (time.Minutes < minutes)
            {
                time.Minutes += 60 - minutes;
                if (time.Hours > 0) time.Hours--;
                else time.Hours = 23;
            }
            else time.Minutes -= minutes;
            return time;
        }

        public static Time operator -(int minutes, Time time)
        {
            if (time.Minutes < minutes)
            {
                time.Minutes += 60 - minutes;
                if (time.Hours > 0) time.Hours--;
                else time.Hours = 23;
            }
            else time.Minutes -= minutes;
            return time;
        }
        #endregion
    }
}
