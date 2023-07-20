using System;
using System.Collections.Generic;
using Logger.Loggers.Interfaces;
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
        public ILog Logger { get; set; }

        public CustomerService()
        {
            ActionsByOption = new Dictionary<MenuOption, Action>
            {
                { MenuOption.AddAccount, AddNewAccountChat },
                { MenuOption.RemoveAccount, RemoveAccountChat },
                { MenuOption.DepositAll, DepositAllChat },
                { MenuOption.Deposit, DepositChat },
                { MenuOption.Withdraw, WithdrawChat },
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
                Logger.WriteErrorEntry(exception.Message);
                Writer.WriteLine(exception.Message);
                Writer.WriteNewLine();
                StartCustomerChat();
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
                    Logger.WriteInfoEntry($"Added account, accountId: {accountId}");
                    Writer.WriteLine("Huge success!");
                }

                Writer.WriteNewLine();
            }
            catch (Exception exception)
            {
                Logger.WriteErrorEntry(exception.Message);
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
                Logger.WriteInfoEntry($"Removed account, accountId: {id}");
                Writer.WriteLine("Removed account!");
                Writer.WriteNewLine();
            }
            catch (Exception exception)
            {
                Logger.WriteErrorEntry(exception.Message);
                Writer.WriteLine(exception.Message);
                Writer.WriteNewLine();
            }
        }

        private void DepositAllChat()
        {
            try
            {
                Writer.WriteLine("What is the amount to deposit to everyone?");
                var amount = Reader.ReadUInt();
                Bank.DepositAll(amount);
                Logger.WriteInfoEntry($"Deposited {amount} to all accounts");
                Writer.WriteLine("Deposited to all!");
                Writer.WriteNewLine();
            }
            catch (Exception exception)
            {
                Logger.WriteErrorEntry(exception.Message);
                Writer.WriteLine(exception.Message);
                Writer.WriteNewLine();
            }
        }

        private void DepositChat()
        {
            try
            {
                Writer.WriteLine("What is the id to deposit to?");
                var id = Reader.ReadLine();
                Writer.WriteLine("What is the amount to deposit?");
                var amount = Reader.ReadUInt();
                Bank.Deposit(id, amount);
                Logger.WriteInfoEntry($"Deposited {amount} to {id}");
                Writer.WriteLine("Deposited successfully!");
                Writer.WriteNewLine();
            }
            catch (Exception exception)
            {
                Logger.WriteErrorEntry(exception.Message);
                Writer.WriteLine(exception.Message);
                Writer.WriteNewLine();
            }
        }

        private void WithdrawChat()
        {
            try
            {
                Writer.WriteLine("What is the id to withdraw from?");
                var id = Reader.ReadLine();
                Writer.WriteLine("What is the amount to withdraw?");
                var amount = Reader.ReadUInt();
                Bank.Withdraw(id, amount);
                Logger.WriteInfoEntry($"Withdrawn {amount} from {id}");
                Writer.WriteLine("Taken money successfully!");
                Writer.WriteNewLine();
            }
            catch (Exception exception)
            {
                Logger.WriteErrorEntry(exception.Message);
                Writer.WriteLine(exception.Message);
                Writer.WriteNewLine();
            }
        }

        private void ShowMenu(string menu) => Writer.WriteLine(menu);

        private MenuOption ReadOption() => Reader.ReadEnum<MenuOption>();
    }
}
