using System;

namespace hascode
{
    class Program
    {
        static void Main(string[] args)
        {
			//Parse
			var p = InputInterpreter.Interpret("Inputs/a_example.txt");

			var result = Algorithm.run(p, new Greedy());
            //Evaluate
            Console.WriteLine(result.Score);
            //PrintOutput
            result.prnintOutputTo("Outputs/a_example_output.txt");
			Console.ReadLine();
        }
    }
}
