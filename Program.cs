using System;
using System.Diagnostics;

namespace hascode
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureStore p;
            var sw = new Stopwatch();
            sw.Start();
            var filename = args.Length > 0 ? args[0] : "a_example.txt";

            p = InputInterpreter.Interpret($"Inputs/{filename}");
            var result = Algorithm.run(p, new Greedy());
            //Evaluate
            Console.WriteLine(result.Score);
            //PrintOutput
            result.prnintOutputTo($"Outputs/{filename.Replace(".txt", "_output.txt")}");
            sw.Stop();
            Console.WriteLine("Elapsed:" + sw.Elapsed);
        }
    }
}
