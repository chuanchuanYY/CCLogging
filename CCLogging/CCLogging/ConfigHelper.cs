using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCLogging
{
	public static class ConfigHelper
	{
		private readonly static IConfigurationSection config;
		static ConfigHelper()
		{
			config = new ConfigurationBuilder()
			.AddXmlFile("LogginConfig.xml", true, true)
			.Build()
			.GetSection("loggin");
		}
		public static string GetOutPutTarget() => config["target:value"] ?? "console";
		public static string GetMinLevel() => config["target:minLevel"] ?? "debug";
		/// <summary>
		/// 0 默认不滚动   zero is default not roll  
		/// </summary>
		/// <returns>unit is kb</returns>
		public static int GetRollByKb() => int.Parse(config["target:rollByKb"] ?? "0");
		public static string GetPath() => config["target:path"] ?? "default.log";
		/// <summary>
		/// 按 时间 滚动 单位为分钟  ，为0则不滚动
		/// roll by time and unit is minute ,but not roll when value is zero 
		/// </summary>
		/// <returns>time for minute </returns>
		public static int GetRollByTime() => int.Parse(config["target:rollByTime"] ?? "0");
		/// <summary>
		/// 设置文件的最大总数量  setting max count of files 
		/// </summary>
		/// <returns>返回文件的最大数量</returns>
		public static int GetMaxCount() => int.Parse(config["target:maxCount"] ?? "0");

		/// <summary>
		/// 格式化输出 
		/// </summary>
		/// <returns></returns>
		public static string GetPattern() 
			=> config["target:parttern"] ?? "%date [%level] %message %newline";
	}
}
