/*
 * Created by SharpDevelop.
 * User: young
 * Date: 2016/4/30 星期六
 * Time: 13:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace calculator1_0
{
	/// <summary>
	/// Description of StringCalculatorProvided.
	/// </summary>
	  
	public class StringCalculatorProvided
	{
		public StringCalculatorProvided()
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
