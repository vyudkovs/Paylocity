using Paylocity.Models;
using System;

namespace Paylocity.BusinessRules
{
    public class NameRule : IRule
    {
        //normally this would come from db or config
        const decimal discount = -.1m;

        private Employee _employee;
        public NameRule(Employee employee)
        {
            _employee = employee;
        }
        public string GetName()
        {
            return "Name discount";
        }
        public bool IsApplicable()
        {
            _employee = _employee ?? new Employee(); //this is needed when we are adding a new employee
            return (_employee.LastName ?? "Test").StartsWith("a", StringComparison.OrdinalIgnoreCase);
        }
        public decimal UseRule()
        {
            InsuranceRule insuranceRule = new InsuranceRule(_employee);
            return insuranceRule.IsApplicable() ? Decimal.Multiply(insuranceRule.UseRule(), discount) : 0;
        }
    }
}
