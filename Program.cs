using System;

namespace hascode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(args[0]);
            PictureStore p;
            if(args.Length != 0){
                p = InputInterpreter.Interpret($"Inputs/{args[0]}");    
            } else {
			    p = InputInterpreter.Interpret("Inputs/a_example.txt");
            }

			var result = Algorithm.run(p, new Greedy());
            //Evaluate
            Console.WriteLine(result.Score);
            //PrintOutput
            result.prnintOutputTo("Outputs/a_example_output.txt");
			Console.ReadLine();
        }
    }
}
