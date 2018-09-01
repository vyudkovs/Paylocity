using Paylocity.Models;
using System;
using System.Collections.Generic;

namespace Paylocity.BusinessRules
{
    public class DependentInsuranceRule : IRule
    {
        //normally these would come from db or config
        const decimal yearCost = -500m;
        //this is a gross simplification: a year has 26 weeks and a day, but we will roll with this here
        const int payPeriods = 26;

        private Employee _employee;
        public DependentInsuranceRule(Employee employee)
        {
            _employee = employee ?? throw new ArgumentException("employee cannot be null");
        }
        public string GetName()
        {
            return "Dependent insurance";
        }
        public bool IsApplicable
        {
            get
            {
                //here's where we could check if employee opted out and not provide discount
                return _employee != null;
            }
        }
        public decimal ApplyRule()
        {
            var costPerDependent = Decimal.Divide(yearCost, payPeriods);
            return Decimal.Multiply(costPerDependent, _employee.Dependents.Count);
        }
    }
}
