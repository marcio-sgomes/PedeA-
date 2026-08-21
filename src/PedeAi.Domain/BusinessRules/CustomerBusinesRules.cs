using PedeAi.Domain.Enums;
using PedeAi.Domain.Rules;

namespace PedeAi.Domain.BusinessRules
{
    internal class CustomerBusinesRules(
        string name,
        string email,
        Status status) 
        : IBusinessRule
    {
        private bool _isBroken = false;
        private readonly string _name = name;
        private readonly string _email = email;
        private readonly Status _status = status;

        public string Code => "INVALID_CUSTOMER_RULE";

        public string Message { get; private set; } = string.Empty;

        public bool IsBroken()
        {
            if (!IsValidName(_name))
            {
                Message = "Name should be between 3 and 100 characters long. ";
                _isBroken = true;
            }

            if (!IsValidEmail(_email))
            {
                Message += "Invalid email format.";
                _isBroken = true;
            }

            if (!IsValidStatus(_status))
            {
                Message += "Invalid status value.";
                _isBroken = true;
            }

            return _isBroken;
        }

        private bool IsValidName(string name) 
            => !name.IsWhiteSpace() && 
                name.Length >= 3 && 
                name.Length <= 100;

        private bool IsValidStatus(Status status)
            => Enum.IsDefined(typeof(Status), status);

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length < 5 || email.Length > 100)
                return false;

            int atIndex = email.IndexOf('@');
            int lastDotIndex = email.LastIndexOf('.');

            return atIndex > 0
                && lastDotIndex > atIndex + 1
                && lastDotIndex < email.Length - 1;
        }
    }
}
