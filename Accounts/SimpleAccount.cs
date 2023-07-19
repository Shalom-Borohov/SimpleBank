using SimpleBank.Exceptions;

namespace SimpleBank.Accounts
{
    public class SimpleAccount : Account
    {
        public override void Withdraw(uint amount)
        {
            if (Balance < amount)
            {
                throw new OverdraftException("Can't withdraw. This simple account has insufficient funds.");
            }

            base.Withdraw(amount);
        }
    }
}
