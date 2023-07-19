using System;
using System.Collections.Generic;
using SimpleBank.Accounts;
using SuperList.Lists.Classes;
using static SimpleBank.Banks.Enums.AccountOptionEnum;

namespace SimpleBank.Banks.Classes
{
    public class Bank
    {
        public DoublyLinkedList<Account> Accounts = new DoublyLinkedList<Account>();

        public Dictionary<AccountOption, Func<Account>> AccountsByOption = new Dictionary<AccountOption, Func<Account>> {
            { AccountOption.Simple, () => new SimpleAccount()},
            { AccountOption.Vip, () => new VIPAccount()}
        };

        public void AddNewAccount(AccountOption option)
        {
            var account = AccountsByOption[option]();
            Accounts.Add(account);
        }
    }
}
