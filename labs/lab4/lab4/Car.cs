namespace lab4
{
    public abstract class Car
    {

        public static int Discount;
        public int Weight { get; set; }
        public string Tittle { get; set; }

        public abstract void Display();
    }
}