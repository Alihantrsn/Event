using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    public delegate void speedDelegate(int speedValue);
    public class Car
    {
        public event Action<int> speedEvent ;
        private int _speed;
        public string model { get; set; }
        public int speed
        {
            get => _speed;

            set
            {
                if (value > 80 && speedEvent != null)
                {
                    speedEvent(value);//event starts
                }
                else
                {
                    _speed = value;
                }




            }

        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Car c= new Car();
                c.model = "ferrari";
                c.speedEvent += (speedValue) => { Console.WriteLine("Vehicle exceeded speed limit  " + speedValue); };
                for (int i = 50; i < 100; i+=5)
                {
                    System.Threading.Thread.Sleep(300);
                    c.speed = i;
                    Console.WriteLine("the vehicle accelerates. vehicle speed:" + i);
                }

            }

            //private static void C_speedEvent(int speedValue)
            //{
            //    Console.WriteLine("araba hızını aştı::::: anlık hız durumu: "+speedValue);
            //}
        }
    }
}
