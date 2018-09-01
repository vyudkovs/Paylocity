using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Paylocity.DAL;
using Paylocity.Models;
using System;
using System.Collections.Generic;

namespace Paylocity.Controllers
{
    /// <summary>
    /// Controller exposing restful calls for crud functionality
    /// </summary>
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        // GET api/people
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return EmployeeDAL.Employees;
        }

        [Route("LastName")]
        [HttpGet("{lastName}")]
        public IEnumerable<Employee> Get(string lastName)
        {
            return EmployeeDAL.Get(lastName);
        }

        // POST api/people/employee
        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            EmployeeDAL.Save(employee);
        }

        // PUT api/people/employee
        [HttpPut()]
        public void Put([FromBody]Employee employee)
        {
            if (employee.Id == null) throw new ArgumentException("No id passed");
            EmployeeDAL.Save((int)employee.Id, employee);
        }

        // DELETE api/people/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EmployeeDAL.Delete(id);
        }
    }
}
