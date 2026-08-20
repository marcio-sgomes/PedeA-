using PedeAi.Domain.Rules;

namespace PedeAi.Domain.BusinessRules
{
    internal class CustomerBusinesRules(
        string name,
        string email) 
        : IBusinessRule
    {
        private bool _status = false;
        private readonly string _name = name;
        private readonly string _email = email;

        public string Code => "INVALID_CUSTOMER_RULE";

        public string Message { get; private set; }

        public bool IsBroken()
        {
            if (!IsValidName(_name))
            {
                Message = "Name should be between 3 and 100 characters long. ";
                _status = true;
            }

            if (!IsValidEmail(_email))
            {
                Message += "Invalid email format.";
                _status = true;
            }

            return _status;
        }

        private bool IsValidName(string name) 
            => !name.IsWhiteSpace() && 
                name.Length >= 3 && 
                name.Length <= 100;

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
