/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2015/10/6
 * Time: 15:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using calculator1_0;
namespace MyCalDll
{
	/// <summary>
	/// Description of StringCalculator.
	/// </summary>
	
public class StringCalculator
	{
		public StringCalculator()
		{
		}
		
		private CalString cal = null;
		private SortBlock2G sbg = null;
		public void SetCalString(string strcal)
		{
			cal = new CalString(strcal);
		}
		public CalString GetCalString()
		{
			return cal;
		}
		public static bool CheckFunName(string strfun)
		{
			return (new Calculator()).CheckFunName(strfun);
		}
		public double GetResult()
		{
			sbg = new SortBlock2G();
			if (cal != null) {
				sbg.GetCalString(cal);
				double result=sbg.GetResult();
				return sbg.IsError() ? 0 :result;
			}
			return 0;
			
		 
		}
		public string GetErrorMessage()
		{
			return sbg.ShowInfo();
		}
		public bool IsError()
		{
			return sbg.IsError();
		}
	}
}
