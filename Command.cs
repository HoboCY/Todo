using System;
using System.Collections.Generic;

namespace TodoSample
{
    public class Command
    {
        public List<string> CommandParameters { get; set; }

        public bool Valid()
        {
            if (CommandParameters.Count < 2 || CommandParameters[0] != "todo")
            {
                Console.WriteLine("Please enter the correct todo command");
                return false;
            }

            if (!CommandParameters.Contains("list"))
            {
                if ((CommandParameters[1] == "add" && CommandParameters.Count < 3) || string.IsNullOrEmpty(CommandParameters[2]))
                {
                    Console.WriteLine("add command needs a parameter");
                    return false;
                }

                if ((CommandParameters[1] == "done" && CommandParameters.Count < 3) || string.IsNullOrEmpty(CommandParameters[2]))
                {
                    Console.WriteLine("done command needs a parameter");
                    return false;
                }
                else if (!int.TryParse(CommandParameters[2], out int index))
                {
                    Console.WriteLine("done command needs a correct index parameter");
                    return false;
                }
                return true;
            }
            return true;
        }
    }
}
