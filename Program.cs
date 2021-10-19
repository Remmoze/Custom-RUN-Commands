﻿using System;
using System.Linq;
using System.IO;

namespace Alias_for_executables
{
    class Program
    {
        static public void Main(string[] args)
        {
            var storage = new Storage();
            var CMDParser = new CommandParser(storage);

#if DEBUG
            while (true) {
                Console.Write($"Gimme the args: \n{Globals.ProgramPrefix} ");
                args = Console.ReadLine().Split(" ");

                CMDParser.ParseCommand(args);

                Console.ReadKey(true);
                Console.Clear();
            }
#endif

            CMDParser.ParseCommand(args);
        }
    }
}
