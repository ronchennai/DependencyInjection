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
			TextLogger logger = new TextLogger();
			try
			{
				throw new DivideByZeroException();
			}
			catch (Exception e)
			{
				logger.Log(e.Message);
			}
        }
    }

	class TextLogger
	{
		public void Log(string message)
		{
			Console.WriteLine("Log to a text file: " + message);
		}
	}
	
}
