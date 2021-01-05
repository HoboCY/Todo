using System.Collections.Generic;
using System;
using System.Linq;

namespace TodoSample
{
    public class TodoModel
    {
        public TodoModel()
        {
            TodoItems = new List<string>();
        }

        public List<string> TodoItems { get; set; }

        private void Add(string item)
        {
            TodoItems.Add(item);
            for (int i = 0; i < TodoItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {TodoItems[i]}");
            }
            Console.WriteLine($"Item {TodoItems.Count - 1} Added");
        }

        private void Done(int index)
        {
            if (index >= TodoItems.Count)
            {
                Console.WriteLine("索引超出范围");
                return;
            }

            TodoItems[index] = $"Done {TodoItems[index]}";
            Console.WriteLine($"Item {index} done.");
        }

        private void List(string parameter)
        {
            var items = parameter.Contains("--all") ? TodoItems : TodoItems.Where(i => !i.Contains("Done")).ToList();

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1} {items[i]}");
            }
        }

        public void ExecuteCommand(Command command)
        {
            switch (command.CommandParameters[1])
            {
                case "add":
                    Add(command.CommandParameters[2]);
                    break;
                case "done":
                    Done(int.Parse(command.CommandParameters[2]));
                    break;
                case "list":
                    List(command.CommandParameters.Count < 3 ? string.Empty : command.CommandParameters[2]);
                    break;
                default:
                    break;
            }
        }
    }
}
