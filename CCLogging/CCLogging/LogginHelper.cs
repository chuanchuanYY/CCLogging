using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCLogging
{
  
	public static class LogginHelper
	{
       // private static readonly ILoggin loggin; 
        public static ILoggin? CreateInstance()
        {
            var target=ConfigHelper.GetOutPutTarget();
            return target.ToLower() switch
            {
                "console" =>new ConsoleLoggin(),
                "file" => new FileLoggin(),
                _ => null
            }; 
        }



    }
}
