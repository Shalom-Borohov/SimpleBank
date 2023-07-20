using Logger.Utils;
using SimpleBank.Banks.Classes;
using SimpleBank.IO.Readers;
using SimpleBank.IO.Writers;
using System.IO;
using Logger.Loggers.Classes;
using static Logger.Loggers.Enums.LoggerTypes;
using System;
using Logger.Loggers.Interfaces;

namespace SimpleBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            var root = Directory.GetCurrentDirectory();
            var dotenvPath = Path.Combine(root, ".env");
            var dotEnv = new DotEnv();
            dotEnv.Load(dotenvPath);

            var loggerCreator = new LoggerCreator();
            var logger = loggerCreator.Create(GetEnvLoggerType());

            var colorWriter = new ColorWriter();
            colorWriter.ChangeForegroundColor(ConsoleColor.Cyan);

            var customerService = new CustomerService
            {
                Reader = new Reader(),
                Writer = new ColorWriter(),
                Bank = new Bank(),
                Logger = logger
            };

            customerService.StartCustomerChat();
        }

        private static LoggerType GetEnvLoggerType()
        {
            var enumUtil = new EnumUtil();

            return enumUtil.ParseEnum<LoggerType>(Environment.GetEnvironmentVariable("LOGGER_TYPE"));
        }
    }
}
