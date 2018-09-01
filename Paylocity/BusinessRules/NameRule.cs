using Paylocity.Models;
using System;

namespace Paylocity.BusinessRules
{
    public class NameRule : IRule
    {
        //normally this would come from db or config
        const decimal _discount = -.1m;
        const string _discountedLetter = "a";

        private Employee _employee;
        public NameRule(Employee employee)
        {
            _employee = employee;
        }
        public string GetName()
        {
            return "Name discount";
        }
        public bool IsApplicable
        {
            get
            {
                return _employee != null && !string.IsNullOrEmpty(_employee.LastName) && _employee.LastName.StartsWith(_discountedLetter, StringComparison.OrdinalIgnoreCase);
            }
        }
        public decimal ApplyRule()
        {
            InsuranceRule insuranceRule = new InsuranceRule(_employee);
            return insuranceRule.IsApplicable ? Decimal.Multiply(insuranceRule.ApplyRule(), _discount) : 0;
        }
    }
}
