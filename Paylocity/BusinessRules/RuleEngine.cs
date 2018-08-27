using Paylocity.Controllers;
using Paylocity.Models;
using System.Collections.Generic;

namespace Paylocity.BusinessRules
{
    public class RuleEngine
    {
        public RuleEngine(Employee employee)
        {
            _rules = new List<IRule>()
            {
                new PaycheckRule(employee),
                new InsuranceRule(employee),
                new DependentInsuranceRule(employee),
                new NameRule(employee),
            };
        }
        private List<IRule> _rules;
        public Cost GetCost()
        {
            var cost = new Cost();
            foreach (var rule in _rules)
            {
                var subtotal = rule.IsApplicable() ? rule.UseRule() : 0m;
                cost.Total += subtotal;
                cost.Items.Add(new Item() { Name = rule.GetName(), Subtotal = subtotal });
            }
            return cost;
        }
    }
}
