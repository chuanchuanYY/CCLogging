using CCLogging;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestLoggin
{
	//Assert.AreEqual(expected, actual):用于比较两个值是否相等,如果相等则返回 true,否则返回 false。
	//Assert.IsTrue(condition):用于检查一个条件是否为 true,如果为 true 则返回 true,否则返回 false。
	//Assert.IsFalse(condition):用于检查一个条件是否为 false,如果为 false 则返回 true,否则返回 false。
	//Assert.IsNull(object):用于检查一个对象是否为 null,如果为 null 则返回 true,否则返回 false。
	//Assert.IsNotNull(object):用于检查一个对象是否不为 null,如果不为 null 则返回 true,否则返回 false。
	//Assert.Throws(expectedException, method):用于检查一个方法是否抛出指定的异常,如果抛出则返回 true,否则返回 false。
	//Assert.Fail():用于断言失败,返回 false。
	public class LogginTest
	{
		[Test]
		public void TestLogginTarget()
		{
			//Loggin to Console 
			var loggin = LogginHelper.CreateInstance();
			if (loggin is null)
			{
				TestContext.Out.WriteLine("loggins  value is null ");
				return;
			}
			loggin.Error("Hello world"+new OverflowException().Message);
		}
	}
}
