namespace Paylocity.BusinessRules
{
    public interface IRule
    {
        string GetName();
        bool IsApplicable();
        decimal UseRule();
    }
}
