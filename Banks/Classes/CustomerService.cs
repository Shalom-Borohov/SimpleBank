using System;
using System.Collections.Generic;
using SimpleBank.IO.Readers;
using SimpleBank.IO.Writers;
using static SimpleBank.Banks.Enums.MenuOptionEnum;
using static SimpleBank.Banks.Enums.AccountOptionEnum;

namespace SimpleBank.Banks.Classes
{
    public class CustomerService
    {
        public Bank Bank { get; set; }
        public Reader Reader { get; set; }
        public Writer Writer { get; set; }
        public Dictionary<MenuOption, Action> ActionsByOption;

        public CustomerService()
        {
            ActionsByOption = new Dictionary<MenuOption, Action>
            {
                { MenuOption.AddAccount, AddNewAccountChat },
                { MenuOption.RemoveAccount, RemoveAccountChat },
                { MenuOption.DepositAll, () => { } },
                { MenuOption.Deposit, () => { } },
                { MenuOption.Withdraw, () => { } },
                { MenuOption.Exit, () => { } },
            };
        }

        public void StartCustomerChat()
        {
            var menu = new MenuBuilder().BuildMenu();

            try
            {
                ShowMenu(menu);
                var option = ReadOption();
                Writer.WriteNewLine();

                while (option != MenuOption.Exit)
                {
                    ActionsByOption[option]();
                    ShowMenu(menu);
                    option = ReadOption();
                    Writer.WriteNewLine();
                }
            }
            catch (Exception exception)
            {
                Writer.WriteLine(exception.Message);
            }
        }

        private void AddNewAccountChat()
        {
            var menu = new MenuBuilder().BuildNewAccountMenu();

            try
            {
                Writer.WriteLine(menu);
                var accountOption = Reader.ReadEnum<AccountOption>();

                if (accountOption != AccountOption.Back)
                {
                    Writer.WriteLine("What is your account id?");
                    var accountId = Reader.ReadLine();
                    Writer.WriteNewLine();
                    Bank.AddNewAccount(accountOption, accountId);
                    Writer.WriteLine("Huge success!");
                }

                Writer.WriteNewLine();
            }
            catch (Exception exception)
            {
                Writer.WriteLine(exception.Message);
                Writer.WriteNewLine();
                AddNewAccountChat();
            }
        }

        private void RemoveAccountChat()
        {
            try
            {
                Writer.WriteLine("What is the account id to remove?");
                var id = Reader.ReadLine();
                Bank.RemoveAccount(id);
                Writer.WriteLine("Removed account!");
                Writer.WriteNewLine();
            }
            catch (Exception exception)
            {
                Writer.WriteLine(exception.Message);
                Writer.WriteNewLine();
            }
        }

        private void ShowMenu(string menu) => Writer.WriteLine(menu);

        private MenuOption ReadOption() => Reader.ReadEnum<MenuOption>();
    }
}
