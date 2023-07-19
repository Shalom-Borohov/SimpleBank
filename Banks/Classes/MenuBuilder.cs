using System.Text;
using static SimpleBank.Banks.Enums.MenuOptionEnum;
using static SimpleBank.Banks.Enums.AccountOptionEnum;

namespace SimpleBank.Banks.Classes
{
    public class MenuBuilder
    {
        public string BuildMenu()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Welcome to the Bank!");
            stringBuilder.AppendLine($"Please Choose an option:");
            stringBuilder.AppendLine($"{(int)MenuOption.AddAccount}. Add an account");
            stringBuilder.AppendLine($"{(int)MenuOption.RemoveAccount}. Remove an account");
            stringBuilder.AppendLine($"{(int)MenuOption.DepositAll}. Deposit a certain amount to everyone");
            stringBuilder.AppendLine($"{(int)MenuOption.Deposit}. Deposit a certain amount to an account");
            stringBuilder.AppendLine($"{(int)MenuOption.Withdraw}. Withdraw money from a certain account");
            stringBuilder.AppendLine($"{(int)MenuOption.Exit}. Exit");

            return stringBuilder.ToString();
        }

        public string BuildNewAccountMenu()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Add new account!");
            stringBuilder.AppendLine($"Please Choose an option:");
            stringBuilder.AppendLine($"{(int)AccountOption.Simple}. Add simple Account");
            stringBuilder.AppendLine($"{(int)AccountOption.Simple}. Add vip Account");
            stringBuilder.AppendLine($"{(int)AccountOption.Back}. No I don't want to anymore");

            return stringBuilder.ToString();
        }
    }
}
