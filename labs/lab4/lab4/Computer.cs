using System;

namespace lab4
{
    public class Computer
    {
        public Computer(GraphicsCard graphicsCard, int power)
        {
            Power = power;
            GraphicsCard = graphicsCard;
        }

        public int Power { get; set; }
        public GraphicsCard GraphicsCard { get; set; }


        public void PowerOn()
        {
            Console.WriteLine($"Computer Start Work with fillow power - {Power}");
            GraphicsCard.PowerOn();
        }
    }
}