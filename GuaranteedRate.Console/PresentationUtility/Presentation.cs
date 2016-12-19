namespace GuaranteedRate.Console.PresentationUtility
{
    using System;
    using Console = System.Console;

    internal static class Presentation
    {
        public static void PrintHeaderText()
        {
            Console.WriteLine("Welcome The Guaranteed Rate Homework assignment.");
            Console.WriteLine("3 files must be specified to the console with the required order:");
            Console.WriteLine("Comma ',' Seperated .txt File");
            Console.WriteLine("Pipe '|' Seperated .txt File");
            Console.WriteLine("And finally a Space ' ' Seperated .txt File");
            Console.WriteLine("The persons collection will not build unless,");
            Console.WriteLine("everything is correct and a strategy is specified.\n");
        }
        public static void PrintClosingText()
        {

            Console.WriteLine();
            Console.WriteLine("All Done!");
            Console.ReadLine();
        }
       
    }
}
