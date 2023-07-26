using SimpleBank.IO.Readers;
using SimpleBank.IO.Writers;
using System.IO;
using Logger.Loggers.Classes;
using static Logger.Loggers.Enums.LoggerTypes;
using System;
using System.Reflection;
using System.Resources;
using SimpleBank.Banks;
using SimpleBank.Utils;
using EnumUtil = Logger.Utils.EnumUtil;

namespace SimpleBank
{
    public class Program
    {
        public static void Main()
        {
            LoadDotEnv();

            var colorWriter = new ColorWriter();
            colorWriter.ResetForegroundColor();

            InitCustomerService(colorWriter).StartCustomerChat();
        }

        private static void LoadDotEnv()
        {
            var dotEnvPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
            new DotEnv().Load(dotEnvPath);
        }

        private static CustomerService InitCustomerService(ColorWriter colorWriter) =>
            new CustomerService
            {
                Reader = new Reader(),
                ColorWriter = colorWriter,
                Bank = new Bank(),
                Logger = new LoggerCreator().Create(GetEnvLoggerType()),
                CustomerResources = new ResourceManager("CustomerService", typeof(Program).Assembly),
                ExceptionsResources =
                    new ResourceManager("SimpleBank.Resources.ExceptionMessages", typeof(Program).Assembly),
            };

        private static LoggerType GetEnvLoggerType()
        {
            var enumUtil = new EnumUtil();

            return enumUtil.ParseEnum<LoggerType>(Environment.GetEnvironmentVariable("LOGGER_TYPE"));
        }
    }
}
