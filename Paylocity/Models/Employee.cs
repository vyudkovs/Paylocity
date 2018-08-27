using System.Collections.Generic;

namespace Paylocity.Models
{
    public class Employee: Person
    {
        public Employee()
        {
            Dependents = new List<Person>();
        }
        public List<Person> Dependents { get; set; }
    }
}
