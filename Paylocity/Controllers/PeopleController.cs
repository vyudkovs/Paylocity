using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Paylocity.DAL;
using Paylocity.Models;
using System;
using System.Collections.Generic;

namespace Paylocity.Controllers
{
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

        //GET api/people/5
        //[HttpGet("{Id}")]
        //public Employee Get(int id)
        //{
        //    return EmployeeDAL.Get(id);
        //}

        [Route("LastName")]
        [HttpGet("{lastName}")]
        public IEnumerable<Employee> Get(string lastName)
        {
            return EmployeeDAL.Get(lastName);
        }

        // POST api/person
        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            EmployeeDAL.Save(employee);
        }

        // PUT api/employee
        [HttpPut()]
        public void Put([FromBody]Employee employee)
        {
            if (employee.Id == null) throw new ArgumentException("No id passed");
            EmployeeDAL.Save((int)employee.Id, employee);
        }

        // DELETE api/people/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EmployeeDAL.Delete(id);
        }
    }
}
