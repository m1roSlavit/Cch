using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileLink = "../file.txt";
            Stack<string> linesStack = new Stack<string>();

            StreamReader SR = new StreamReader(fileLink);

            while (!SR.EndOfStream)
            {
                string line = SR.ReadLine();
                if(line.Contains('A'))
                {
                    linesStack.Push(line);
                }
            }

            while (linesStack.Count != 0)
            {
                Console.WriteLine(linesStack.Pop());
            }

            SR.Close();
        }
    }
}
