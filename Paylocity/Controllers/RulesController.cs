using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Paylocity.BusinessRules;
using Paylocity.DAL;
using Paylocity.Models;
using System.Collections.Generic;

namespace Paylocity.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class RulesController : Controller
    {
        // GET api/RulesController/5
        [HttpGet("{Id}")]
        public Cost Get(int id)
        {
            //get employee
            Employee employee = EmployeeDAL.Get(id);

            //start rule engine for that one employee
            RuleEngine ruleEngine = new RuleEngine(employee);


            return ruleEngine.GetCost();
        }
    }
}
