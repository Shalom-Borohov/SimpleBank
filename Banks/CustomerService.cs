using System;
using System.Collections.Generic;
using System.Resources;
using Logger.Loggers.Interfaces;
using SimpleBank.IO.Readers;
using SimpleBank.IO.Writers;
using static SimpleBank.Banks.Enums.MenuOptionEnum;
using static SimpleBank.Banks.Enums.AccountOptionEnum;

namespace SimpleBank.Banks
{
    public class CustomerService
    {
        public Bank Bank { get; set; }
        public Reader Reader { get; set; }
        public ColorWriter ColorWriter { get; set; }
        public Dictionary<MenuOption, Action> ActionsByOption;
        public ILog Logger { get; set; }
        public ResourceManager ExceptionsResources { get; set; }
        public ResourceManager CustomerResources { get; set; }

        public CustomerService()
        {
            ActionsByOption = new Dictionary<MenuOption, Action>
            {
                { MenuOption.AddAccount, AddAccount },
                { MenuOption.RemoveAccount, RemoveAccount },
                { MenuOption.DepositAll, DepositAll },
                { MenuOption.Deposit, Deposit },
                { MenuOption.Withdraw, Withdraw },
            };
        }

        public void StartCustomerChat()
        {
            var menu = new MenuBuilder().BuildMenu();

            try
            {
                ShowMenu(menu);
                var option = ReadOption();
                ColorWriter.WriteNewLine();

                while (option != MenuOption.Exit)
                {
                    ActionsByOption[option]();
                    ShowMenu(menu);
                    option = ReadOption();
                    ColorWriter.WriteNewLine();
                }
            }
            catch (ArgumentException argumentException)
            {
                ShowExceptionMessage(argumentException, GetExceptionString("ArgumentException"));
            }
            catch (KeyNotFoundException keyNotFoundException)
            {
                ShowExceptionMessage(keyNotFoundException, GetExceptionString("KeyNotFoundException"));
            }
            catch (OverflowException overflowException)
            {
                ShowExceptionMessage(overflowException, GetExceptionString("OverflowException"));
            }
            catch (Exception exception)
            {
                ShowExceptionMessage(exception, exception.Message);
            }
        }

        private void AddAccount()
        {
            var menu = new MenuBuilder().BuildNewAccountMenu();

            ColorWriter.WriteLine(menu);
            var accountOption = Reader.ReadEnum<AccountOption>();

            if (accountOption != AccountOption.Back)
            {
                ColorWriter.WriteLine("What is your account id?");
                var accountId = Reader.ReadLine();
                ColorWriter.WriteNewLine();

                Bank.AddNewAccount(accountOption, accountId);
                Logger.WriteInfoEntry($"Added account, accountId: {accountId}");
                ColorWriter.WriteLine("Huge success!");
            }

            ColorWriter.WriteNewLine();
        }

        private void RemoveAccount()
        {
            ColorWriter.WriteLine("What is the account id to remove?");
            var id = Reader.ReadLine();

            Bank.RemoveAccount(id);
            Logger.WriteInfoEntry($"Removed account, accountId: {id}");
            ColorWriter.WriteLine("Removed account!");
            ColorWriter.WriteNewLine();
        }

        private void DepositAll()
        {
            ColorWriter.WriteLine("What is the amount to deposit to everyone?");
            var amount = Reader.ReadUInt();
            Bank.DepositAll(amount);

            Logger.WriteInfoEntry($"Deposited {amount} to all accounts");
            ColorWriter.WriteLine("Deposited to all!");
            ColorWriter.WriteNewLine();
        }

        private void Deposit()
        {
            ColorWriter.WriteLine("What is the id to deposit to?");
            var id = Reader.ReadLine();
            ColorWriter.WriteLine("What is the amount to deposit?");
            var amount = Reader.ReadUInt();
            Bank.Deposit(id, amount);

            Logger.WriteInfoEntry($"Deposited {amount} to {id}");
            ColorWriter.WriteLine("Deposited successfully!");
            ColorWriter.WriteNewLine();
        }

        private void Withdraw()
        {
            ColorWriter.WriteLine("What is the id to withdraw from?");
            var id = Reader.ReadLine();
            ColorWriter.WriteLine("What is the amount to withdraw?");
            var amount = Reader.ReadUInt();
            Bank.Withdraw(id, amount);

            Logger.WriteInfoEntry($"Withdrawn {amount} from {id}");
            ColorWriter.WriteLine("Taken money successfully!");
            ColorWriter.WriteNewLine();
        }

        private void ShowMenu(string menu) => ColorWriter.WriteLine(menu);

        private MenuOption ReadOption() => Reader.ReadEnum<MenuOption>();

        private void ShowExceptionMessage(Exception exception, string message)
        {
            ColorWriter.ChangeForegroundColor(ConsoleColor.DarkRed);
            ColorWriter.WriteLine(message);
            ColorWriter.WriteNewLine();
            ColorWriter.ResetForegroundColor();

            Logger.WriteErrorEntry(exception.Message);
            StartCustomerChat();
        }

        private string GetExceptionString(string resourceKey) => ExceptionsResources.GetString(resourceKey);
    }
}
