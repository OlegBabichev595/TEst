using System;

namespace lab4
{
    public class GraphicsCard
    {
        public GraphicsCard(string title)
        {
            Title = title;
        }

        public string Title { get; set; }

        public void PowerOn()
        {
            Console.WriteLine($"{Title} start working");
        }
    }
}