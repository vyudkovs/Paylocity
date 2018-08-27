using Paylocity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paylocity.DAL
{
    public static class EmployeeDAL
    {
        public static List<Employee> Employees { get; private set; }

        //there is a race condition here: normally would be wrapped in a db transaction or else made thread safe
        private static Employee SetEmployeeDependentIdsIfNeeded(int? id, Employee employee)
        {
            var maxId = GetMaxId();
            employee.Id = id ?? ++maxId;
            employee.Dependents.Select(dependent =>
            {
                if (dependent.Id == null) dependent.Id = ++maxId;
                return dependent;
            });
            return employee;
        }

        private static int GetMaxId()
        {
            var people = Employees.SelectMany(e => e.Dependents).Concat(Employees);
            return people.Max(p => p.Id ?? 0);
        }

        static EmployeeDAL()
        {
            EmployeeDAL.Employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Dependents = new List<Person>
                        {
                            new Person() { Id = 4, FirstName = "Lisa", LastName = "Smith"},
                            new Person() { Id = 5, FirstName = "Larry", LastName = "Smith"},
                            new Person() { Id = 6, FirstName = "Lana", LastName = "Smith"}
                        }
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Shrek",
                    LastName = "Ogre",
                    Dependents = new List<Person>
                        {
                            new Person() { Id = 7, FirstName = "Fiona", LastName = "Ogre"}
                        }
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Han",
                    LastName = "Solo",
                },
                new Employee
                {
                    Id = 8,
                    FirstName = "Ironman",
                    LastName = "Avenger",
                },
            };
        }

        public static Employee Get(int id)
        {
            return Employees.FirstOrDefault(e => e.Id == id);
        }

        public static IEnumerable<Employee> Get(string lastName)
        {
            return Employees.Where(person => person.LastName.StartsWith(lastName, StringComparison.OrdinalIgnoreCase));
        }

        public static void Save(Employee employee)
        {
            Employees.Add(SetEmployeeDependentIdsIfNeeded(null, employee));
        }

        public static void Save(int id, Employee employee)
        {
            var employeeExisting = Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (employeeExisting == null) throw new ArgumentException("invalid emplpoyee"); //we would have normally logged here
            employee = SetEmployeeDependentIdsIfNeeded(id, employee);
            Employees[Employees.IndexOf(employeeExisting)] = employee;
        }

        public static void Delete(int id)
        {
            var employeeExisting = Employees.FirstOrDefault(e => e.Id == id);
            if (employeeExisting == null) throw new ArgumentException("invalid emplpoyee"); //we would have normally logged here
            Employees.Remove(employeeExisting);
        }
    }
}
