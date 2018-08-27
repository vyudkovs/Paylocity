using Paylocity.Models;

namespace Paylocity.BusinessRules
{
    public class PaycheckRule: IRule
    {
        private Employee _employee;
        public PaycheckRule(Employee employee)
        {
            _employee = employee;
        }
        public string GetName()
        {
            return "Paycheck amout";
        }
        public bool IsApplicable()
        {
            return _employee != null; //here's where we could check if employee opted out.  as is everyone gets one
        }
        public decimal UseRule()
        {
            return 2000m;
        }
    }
}
