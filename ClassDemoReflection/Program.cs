using System;

namespace ClassDemoReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflectionWorker worker = new ReflectionWorker();
            worker.Start();
            Console.ReadLine();
        }
    }
}
