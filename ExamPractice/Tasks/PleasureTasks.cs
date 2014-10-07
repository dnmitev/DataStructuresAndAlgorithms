// http://bgcoder.com/Contests/Practice/Index/133#1
namespace Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;
    
    class PleasureTasks
    {
        private static int CompareTasks(Task firstTask, Task secondTask)
        {
            if (firstTask.Complexity.CompareTo(secondTask.Complexity) == 0)
            {
                return firstTask.Name.CompareTo(secondTask.Name);
            }

            return firstTask.Complexity.CompareTo(secondTask.Complexity);
        }

        static void Main()
        {
            var commandsCount = int.Parse(Console.ReadLine());
            var taskList = new OrderedBag<Task>(CompareTasks);
            var result = new StringBuilder();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] userLine = Console.ReadLine().Split(' ');

                string command = userLine[0];

                switch (command)
                {
                    case "New":
                        {
                            var newTask = new Task
                            {
                                Complexity = int.Parse(userLine[1]),
                                Name = userLine[2]
                            };

                            taskList.Add(newTask);
                            break;
                        }
                    case "Solve":
                        {
                            var solvedTask = taskList.FirstOrDefault();
                            taskList.Remove(solvedTask);
                            result.AppendLine(solvedTask == null ? "Rest" : solvedTask.Name);
                            break;
                        }
                    default:
                        throw new ArgumentException("Invalid command");
                }
            }

            Console.WriteLine(result.ToString());
        }

        class Task
        {
            public int Complexity { get; set; }

            public string Name { get; set; }
        }
    }
}