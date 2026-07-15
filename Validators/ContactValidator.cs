using System.Linq;

namespace PhoneBook.Validators
{
    public static class ContactValidator
    {
        public static bool IsValidPhoneNumber(string? number)
        {
            return !string.IsNullOrWhiteSpace(number)
                && number.Length == 9
                && number.All(char.IsDigit);
        }

        public static bool IsValidName(string? name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }
    }
}