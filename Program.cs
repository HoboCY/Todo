using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TodoSample
{
    class Program
    {
        static void Main(string[] args)
        {
            TodoModel todo = new TodoModel();
            CancellationTokenSource cts = new CancellationTokenSource();


            while (true)
            {
                var input = Console.ReadLine();
                if (input == "exit")
                {
                    cts.Cancel();
                    break;
                }

                var command = new Command()
                {
                    CommandParameters = input.Split(' ').ToList()
                };

                var isValid = command.Valid();
                if (isValid)
                {
                    todo.ExecuteCommand(command);
                }
            }
        }
    }
}
