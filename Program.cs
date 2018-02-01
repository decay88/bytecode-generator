using System;
using System.IO;
using System.Text;

namespace shellcode_gen
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] raw;
            string loc;
            if (args.Length < 1)
            {
                Console.Write("Enter the location of the file you want to grab bytecode from: ");
                loc = Console.ReadLine();
            } else
                loc = args[0];

            raw = File.ReadAllBytes(loc);
            
            // save bytecode into useable format
            string csParsed = "byte[] shellcode = { ";
            for (int i = 0; i < raw.Length; i++)
            {
                csParsed += "0x" + raw[i].ToString("X2") + ", ";
                float percentage = (float)(i*100) / (float)raw.Length;
                Console.WriteLine(percentage + "% done...");
            }
            csParsed += " }";

            Console.WriteLine("Saving formatted bytecode");
            File.WriteAllBytes("bytecode.cs", Encoding.ASCII.GetBytes(csParsed));
            Console.WriteLine("Done!");

            Console.ReadKey();
        }
    }
}
