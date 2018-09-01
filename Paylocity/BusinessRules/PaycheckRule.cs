using Paylocity.Models;

namespace Paylocity.BusinessRules
{
    public class PaycheckRule: IRule
    {
        //this is a gross simplification.  _payAmount should come from employee
        private const decimal _payAmount = 2000m;
        private Employee _employee;
        public PaycheckRule(Employee employee)
        {
            _employee = employee;
        }
        public string GetName()
        {
            return "Paycheck amount";
        }
        public bool IsApplicable
        {
            get
            {
                return _employee != null;
            }
        }
        public decimal ApplyRule()
        {
            return _payAmount;
        }
    }
}
