namespace Question_2
{
    class Source
    {
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
        public double Add(double a, double b, double c)
        {
            return a + b + c;
        }

    }
    public class Program
    {
        static void Main(String[] args)
        {
            Source s = new Source();
            Console.WriteLine(s.Add(10, 20, 30));
            Console.WriteLine(s.Add(1.2, 2.3, 4.4));


        }
    }
}
