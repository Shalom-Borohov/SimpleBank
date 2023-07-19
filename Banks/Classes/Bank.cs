using System;
using System.Collections.Generic;
using SimpleBank.Accounts;
using SuperList.Lists.Classes;
using System.Linq;
using SimpleBank.Exceptions;
using static SimpleBank.Banks.Enums.AccountOptionEnum;

namespace SimpleBank.Banks.Classes
{
    public class Bank
    {
        public DoublyLinkedList<Account> Accounts = new DoublyLinkedList<Account>();

        public Dictionary<AccountOption, Func<string, Account>> AccountsByOption = new Dictionary<AccountOption, Func<string, Account>> {
            { AccountOption.Simple, id => new SimpleAccount { Id = id } },
            { AccountOption.Vip, id => new VIPAccount { Id = id } }
        };

        public void AddNewAccount(AccountOption option, string id)
        {
            var isAccountIdExists = Accounts.Any(account => account.Id.Equals(id));

            if (isAccountIdExists)
            {
                throw new DuplicateAccountIdException("Can't add new account. Account id already taken.");
            }

            var newAccount = AccountsByOption[option](id);
            Accounts.Add(newAccount);
        }

        public void RemoveAccount(string id)
        {
            var accountToRemove = Accounts.Single(account => account.Id.Equals(id));
            Accounts.RemoveAt(Accounts.IndexOf(accountToRemove));
        }
    }
}
