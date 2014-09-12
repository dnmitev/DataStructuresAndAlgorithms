namespace Sallaries
{
    using System.Collections.Generic;

    internal class Employee
    {
        public int Id { get; set; }

        public long Sallary { get; set; }

        public List<Employee> Employees { get; set; }

        public Employee(int id)
        {
            this.Id = id;
            this.Employees = new List<Employee>();
        }
    }
}