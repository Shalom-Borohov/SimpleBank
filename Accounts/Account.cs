namespace SimpleBank.Accounts
{
    public abstract class Account
    {
        public string Id { get; set; }
        public int Balance { get; set; } = 0;

        public virtual void Deposit(uint amount) => Balance += (int)amount;

        public virtual void Withdraw(uint amount) => Balance -= (int)amount;
    }
}
