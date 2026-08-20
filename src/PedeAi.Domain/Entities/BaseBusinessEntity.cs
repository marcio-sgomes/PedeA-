using PedeAi.Domain.Exceptions;
using PedeAi.Domain.Rules;

namespace PedeAi.Domain.Entities
{
    public abstract class BaseBusinessEntity
    {
        private readonly List<IBusinessRule> _rules = new();

        protected void CheckBusinessRules()
        {
            foreach (var businessRule in _rules)
            {
                if (businessRule.IsBroken())
                    throw new BusinessRulesValidationException(businessRule);
            }
        }

        protected void AddRule(IBusinessRule rule)
        {
            _rules.Add(rule);
        }
    }
}
