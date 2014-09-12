namespace Sallaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class EntryPoint
    {
        private static readonly HashSet<int> visited = new HashSet<int>();

        private const char HasEmployees = 'Y';

        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

            for (int i = 0; i < n; i++)
            {
                if (!employees.ContainsKey(i))
                {
                    employees[i] = new Employee(i);
                }

                var employer = employees[i];

                string userInput = Console.ReadLine();

                for (int j = 0; j < userInput.Length; j++)
                {
                    if (userInput[j] == HasEmployees)
                    {
                        if (!employees.ContainsKey(j))
                        {
                            employees[j] = new Employee(j);
                        }

                        var worker = employees[j];
                        employer.Employees.Add(worker);
                    }
                }
            }

            long sum = 0;

            for (int i = 0; i < n; i++)
            {
                Solve(employees[i]);
            }

            foreach (var employee in employees)
            {
                sum += employee.Value.Sallary;
            }

            Console.WriteLine(sum);
        }

        private static void Solve(Employee employee)
        {
            if (visited.Contains(employee.Id))
            {
                return;
            }

            visited.Add(employee.Id);

            if (employee.Employees.Count == 0)
            {
                employee.Sallary = 1;
                return;
            }

            foreach (var empl in employee.Employees)
            {
                Solve(empl);
                employee.Sallary += empl.Sallary;
            }
        }
    }
}