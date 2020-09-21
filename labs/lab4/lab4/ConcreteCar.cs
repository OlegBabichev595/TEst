using System;

namespace lab4
{
    public class ConcreteCar:Car
    {
        public override void Display()
        {
            Console.WriteLine($"{Tittle}");
        }
    }
}