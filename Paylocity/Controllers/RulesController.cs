using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Paylocity.BusinessRules;
using Paylocity.DAL;
using Paylocity.Models;
using System.Collections.Generic;

namespace Paylocity.Controllers
{

    /// <summary>
    /// Controller exposing restful calls for crud functionality
    /// </summary>
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class RulesController : Controller
    {
        // GET api/Rules/id
        [HttpGet("{Id}")]
        public Cost Get(int id)
        {
            Employee employee = EmployeeDAL.Get(id);
            RuleEngine ruleEngine = new RuleEngine(employee);


            return ruleEngine.GetCost();
        }
    }
}
