using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCLogging
{
	public abstract  class LoggingBase
	{
		public abstract void Log(LogginLevel logginLevel,string message);
		protected  LogginLevel GetMinLevel()
		{
			var minlevel = ConfigHelper.GetMinLevel();
			return minlevel.ToLower() switch
			{
				"debug" => LogginLevel.Debug,
				"info" => LogginLevel.Info,
				"error" => LogginLevel.Error,
				"warning" => LogginLevel.Warning,
				"fatal" => LogginLevel.Fatal,
				_ => LogginLevel.Debug
			};
		}

		public virtual string getMessage(string message, LogginLevel level)
		{
			var pattern=ConfigHelper.GetPattern();
			try
			{
				return pattern.Replace("%date", DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss"))
				.Replace("%level", level.ToString())
				.Replace("%message", message)
				.Replace("%newline", Environment.NewLine);
			}
			catch (Exception)
			{

				throw;
			}
		
		}
	}
	public enum LogginLevel
	{
		Debug,
		Info,
		Warning,
		Error,
		Fatal
	}
}
