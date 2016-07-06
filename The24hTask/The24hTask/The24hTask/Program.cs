using System;

namespace The24hTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("input=");
            string inputPath = @Console.ReadLine();

            Console.Write("alpha=");
            string alphaOutputPath = Console.ReadLine();

            Console.Write("numer=");
            string numerOutputPath = Console.ReadLine();

            Settings.ExtractAndRewrite(inputPath, alphaOutputPath, numerOutputPath);
        }
    }


}
