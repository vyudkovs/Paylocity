using System.Collections.Generic;

namespace Paylocity.Models
{
    /// <summary>
    /// Employee is a person with ddependents
    /// </summary>
    public class Employee: Person
    {
        public Employee()
        {
            Dependents = new List<Person>();
        }
        public List<Person> Dependents { get; set; }
    }
}
