using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCLogging
{
	public class ConsoleLoggin : LoggingBase, ILoggin
	{
		
		public void Debug(string message)
		{
			Log(LogginLevel.Debug,message);
		}

		public void Error(string message)
		{
			Log(LogginLevel.Error, message);
		}

		public void Fatal(string message)
		{
			Log(LogginLevel.Fatal, message);
		}

		public void Info(string message)
		{
			Log(LogginLevel.Info, message);
		}

		public void Warning(string message)
		{
			Log(LogginLevel.Warning, message);
		}

		public override void Log(LogginLevel logginLevel, string message)
		{
			if (logginLevel < GetMinLevel())
				return;
			Console.WriteLine(getMessage(message,logginLevel));
		}

	}
}
