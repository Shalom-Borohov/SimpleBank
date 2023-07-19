using System.Text;
using static SimpleBank.Bank.Enums.MenuOptionEnum;

namespace SimpleBank.Bank.Classes
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
    }
}
