using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CCLogging
{
	public class FileLoggin : LoggingBase,ILoggin
	{
		public void Debug(string message)
		{
			Log(LogginLevel.Debug, message);
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
			Log(LogginLevel.Warning,message);
		}
		public override void Log(LogginLevel logginLevel, string message)
		{
			WriteString(logginLevel,message);
		}

		private void WriteString (LogginLevel logginLevel,string message)
		{
			var path=ConfigHelper.GetPath();
			//il1|
			try
			{
				if (logginLevel < GetMinLevel())
					return;
				LogRoll(path);
				var stream = File.AppendText(path);
				stream.Write(getMessage(message,logginLevel));
				stream.Close();
				limitfileCount(path);
			}
			catch (Exception)
			{
				throw;
			}
		}
		private void LogRoll(string path)
		{
			var rollSize = ConfigHelper.GetRollByKb();
			var rollTime =ConfigHelper.GetRollByTime();
			if (rollSize <= 0) return;
			if (!File.Exists(path)) return;
			var fileinfo = new FileInfo(path);
			var currentsize = fileinfo.Length / 1024;
			var differenceTime = (DateTime.Now - fileinfo.CreationTime).TotalMinutes;
			if ((rollSize>0&&currentsize >= rollSize)||
				(differenceTime>rollTime&&rollTime>0))
			{
				try
				{
					File.Move(path, $"{fileinfo.Name.Split('.')[0]}.{DateTime.Now:yyyy-MM-dd-HH-mm-ss}" +
						$"{fileinfo.Extension}");
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		private void limitfileCount(string path)
		{
		
			var maxcount = ConfigHelper.GetMaxCount();
			if (maxcount <= 0) return;
            if (!File.Exists(path)) return;
			var fileinfo = new FileInfo(path);
			string pattern = @$"^{fileinfo.Name.Split('.')[0]}.*{fileinfo.Name.Split('.')[1]}$";
			var files = Directory.EnumerateFiles(fileinfo.DirectoryName!)
				.Select(path => new FileInfo(path))
				.Where(file => Regex.IsMatch(file.Name, pattern))
				.ToList();
			files.OrderBy(f => f.LastWriteTime);
			for(int i=0;i<files.Count-maxcount;i++)
			{
				try
				{
					File.Delete(files[i].FullName);
				}
				catch (Exception ex)
				{

					throw ex;
				}
			}
		}
	}
}
