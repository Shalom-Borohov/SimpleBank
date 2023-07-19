using System;
using SimpleBank.IO.Readers;
using SimpleBank.IO.Writers;
using static SimpleBank.Bank.Enums.MenuOptionEnum;

namespace SimpleBank.Bank.Classes
{
    public class CustomerService
    {
        public Bank Bank { get; set; }
        public Reader Reader { get; set; }
        public Writer Writer { get; set; }

        public void StartCustomerChat()
        {
            var menu = new MenuBuilder().BuildMenu();

            ShowMenu(menu);
            var option = ReadOption();

            while (option != (int)MenuOption.Exit)
            {
                Writer.WriteLine("yes");
                ShowMenu(menu);
                Writer.WriteNewLine();
                option = ReadOption();
            }
        }

        private void ShowMenu(string menu) => Writer.WriteLine(menu);

        private int ReadOption() => Reader.ReadInt();
    }
}
