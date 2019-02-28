using System;

namespace hascode
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureStore p;
            if(args.Length != 0){
                p = InputInterpreter.Interpret($"Inputs/{args[0]}.txt");    
            } else {
			    p = InputInterpreter.Interpret("Inputs/a_example.txt");
            }

			var result = Algorithm.run(p, new Greedy());
            //Evaluate
            Console.WriteLine(result.Score);
            //PrintOutput
            result.prnintOutputTo($"Outputs/{args[0]}_output.txt");
			// Console.ReadLine();
        }
    }
}
