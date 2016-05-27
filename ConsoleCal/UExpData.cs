/*
 * Created by SharpDevelop.
 * User: young
 * Date: 2016/5/5 星期四
 * Time: 19:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using calculator1_0;
using ConsoleCal;

namespace ConsoleCal
{
	/// <summary>
	/// Description of UExpData.
	/// </summary>
	public class UExpData:ExpData
	{
		public UExpData(string input):base(input)
		{
			 
		}
		 
		 
		/// <summary>
		/// 计算返回结果 但是不修改表达式的值
		/// </summary>
		/// <returns></returns>
		public override string GetValueEx()
		{
			CalData cd=UIController.SimpleCal(express) ;
			if (cd==null) {
				throw new ExpError("ExpError::Not defined "+express+"!Ex");		
			}
			string str =  (cd as ExpData)  .GetValueEx();
			if (str == null) {
				str = "0";
				throw new ExpError("ExpError::Something Wrong Happened!Ex");				
			}
			value = str;
			return str;
		}
		/// <summary>
		/// 一次性计算出结果 返回结果值并修改表达式
		/// </summary>
		/// <returns></returns>
		public string GetValueFinal()
		{
			CalData cd=UIController.SimpleCal(value) ;
			if (cd==null) {
				throw new AssignedError("AssignedError::Not defined "+express+"!Ex");		
			}
			ExpData ed=cd as ExpData;
			string str=ed.GetValueEx();
			
//			string s =new UExpData ((cd as ExpData).GetExpress()).GetValueEx();
			if (str == null) {
				str = "0";
				throw new ExpError("ExpError::Something Wrong Happened!Final"+'\n');
				
			}
			value = str;
			express = str;
			return str;
		}
		 
		 
		public  override string  ToString()
		{
			return("Express:" + GetExpress() + "  Value:" + GetValueEx());
		}
		
	 
	}
}
