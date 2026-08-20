using PedeAi.Domain.Rules;

namespace PedeAi.Domain.Exceptions
{
    public class BusinessRulesValidationException(IBusinessRule businessRule) 
        : Exception(businessRule.Message)
    { }
}
