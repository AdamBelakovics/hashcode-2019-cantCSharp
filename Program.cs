using System;

namespace hascode
{
    class Program
    {
        static void Main(string[] args)
        {
			//Parse
			var p = InputInterpreter.Interpret("a_example.txt");

			var result = Algorithm.run(/* input ,*/ new Greedy());
            //Evaluate
            //PrintOutput
			Console.ReadLine();
        }
    }
}
