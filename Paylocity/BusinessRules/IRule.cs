namespace Paylocity.BusinessRules
{
    /// <summary>
    /// Interface for rules
    /// One improvement would be to add "applies" to the IRule to see who gets insurance, discount, etc
    /// </summary>
    public interface IRule
    {
        string GetName();
        bool IsApplicable { get; }
        decimal ApplyRule();
    }
}
