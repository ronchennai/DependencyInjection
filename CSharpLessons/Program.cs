using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLessons
{
    class Program
    {
		
        static void Main(string[] args)
        {
			ILogger logger;

			//read the type of logger from config file
			string loggerType = "text";
			switch (loggerType)
			{
				case "database":
					logger = new DatabaseLogger();
					break;
				default:
					logger = new TextLogger();
					break;
			}
			 
			LogManager logManager = new LogManager(logger);

			try
			{
				throw new DivideByZeroException();
			}
			catch (Exception e)
			{
				logManager.Log(e.Message);
				Console.ReadLine();
			}
        }
    }
	interface ILogger
	{
		void Log(string message);
	}
	class LogManager
	{
		private ILogger _logger;
		public LogManager(ILogger logger)
		{
			_logger = logger;
		}
		public void Log(string message)
		{
			_logger.Log(message);
		}
	}
	class TextLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine("Log to a text file: " + message);
		}
	}
	class DatabaseLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine("Log to a database: " + message);
		}
	}
}
