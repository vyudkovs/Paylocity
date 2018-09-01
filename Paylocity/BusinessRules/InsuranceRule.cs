using Paylocity.Models;
using System;

namespace Paylocity.BusinessRules
{
    public class InsuranceRule : IRule
    {
        //normally these would come from db or config
        const decimal yearCost = -1000m;
        //this is a gross simplification: a year has 26 weeks and a day, but we will roll with this here
        const int payPeriods = 26;

        private Employee _employee;
        public InsuranceRule(Employee employee)
        {
            _employee = employee ?? throw new ArgumentException("employee cannot be null");
        }
        public string GetName()
        {
            return "Employee insurance";
        }
        public bool IsApplicable
        {
            get
            {
                return _employee != null; //here's where we could check if employee opted out.  as is everyone gets insurance
            }
        }
        public decimal ApplyRule()
        {
            return Decimal.Divide(yearCost, payPeriods);
        }
    }
}
