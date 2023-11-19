﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCLogging
{
	public interface ILoggin
	{
		public void Debug(string message);
		public void Info(string message);
		public void Warning(string message);
		public void Error(string message);
		public void Fatal(string message);
	}
}
