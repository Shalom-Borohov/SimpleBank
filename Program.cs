using SimpleBank.Bank.Classes;
using SimpleBank.IO.Readers;
using SimpleBank.IO.Writers;

namespace SimpleBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customerService = new CustomerService { Reader = new Reader(), Writer = new ColorWriter() };
            customerService.StartCustomerChat();
        }
    }
}
