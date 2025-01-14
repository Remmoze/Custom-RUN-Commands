﻿using System;
using System.Collections.Generic;

namespace Alias_for_executables.Commands
{
    public class ListCommand : Command
    {
        public ListCommand(CommandParser parser) : base(parser, "list", new List<string> { "l", "get", "-l" })
        {
            Help = new HelpOutput() {
                Discription = "List all aliases",
                Arguments = "",
                Example = $"{Globals.ProgramPrefix} list",
            };
        }

        public override CommandResponse TryExecute(string[] arguments)
        {
            return OnExecute(arguments);
        }

        public override CommandResponse OnExecute(string[] arguments)
        {
            if (CMDParser.Storage.Aliases.Count == 0) {
                Console.WriteLine("No aliases were found.");
                return new CommandResponse(CommandOutput.Success);
            }

            Console.WriteLine("List of avaliable aliases:");
            CMDParser.Storage.Aliases.ForEach(cmd => {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"  {cmd.Name}");
                Console.ResetColor();
                Console.WriteLine($"  {cmd.Path}");
                if (cmd.CreationDate != null)
                    Console.WriteLine($"  {cmd.CreationDate:yyyy/MM/dd HH:mm:ss}");
            });
            return new CommandResponse(CommandOutput.Success);
        }
    }
}
