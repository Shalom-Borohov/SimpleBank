namespace SimpleBank.Accounts
{
    public abstract class Account
    {
        public int Balance { get; set; }

        public virtual void Deposit(uint amount) => Balance += (int)amount;

        public virtual void Withdraw(uint amount) => Balance -= (int)amount;
    }
}
