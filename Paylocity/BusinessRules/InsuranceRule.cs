using Paylocity.Models;
using System;

namespace Paylocity.BusinessRules
{
    public class InsuranceRule : IRule
    {
        //normally these would come from db or config
        const decimal yearCost = -1000m; 
        const decimal payPeriods = 26m;

        private Employee _employee;
        public InsuranceRule(Employee employee)
        {
            _employee = employee;
        }
        public string GetName()
        {
            return "Employee insurence";
        }
        public bool IsApplicable()
        {
            return _employee!=null; //here's where we could check if employee opted out.  as is everyone gets one
        }
        public decimal UseRule()
        {
            return Decimal.Divide(yearCost, payPeriods);
        }
    }
}
