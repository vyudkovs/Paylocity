using Paylocity.Models;
using System;
using System.Collections.Generic;

namespace Paylocity.BusinessRules
{
    public class DependentInsuranceRule : IRule
    {
        //normally these would come from db or config
        const decimal yearCost = -500m; 
        const decimal payPeriods = 26m;

        private Employee _employee;
        public DependentInsuranceRule(Employee employee)
        {
            _employee = employee;
        }
        public string GetName()
        {
            return "Dependent insurence";
        }
        public bool IsApplicable()
        {
            //here's where we could check if employee opted out.  as is everyone gets one
            return _employee !=null;
        }
        public decimal UseRule()
        {
            var costPerDependent = Decimal.Divide(yearCost, payPeriods);
            return Decimal.Multiply(costPerDependent, _employee.Dependents.Count);
        }
    }
}
