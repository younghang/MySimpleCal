/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2016/1/15
 * Time: 11:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using calculator1_0;

namespace calculator1_0
{
	/// <summary>
	/// Description of ExpData.
	/// </summary>
	public class ExpData:CalData
	{
		
		public ExpData(string input)
		{
			express = input;
			value = input;
			CalType = DataType.EXP;
		}
		//直接调用底层的StringCalculator 对象引用，没有经过UIController
		public virtual string GetValueEx()
		{
			double result = 0;
			string strr = "0";
			StringCalculatorProvided sc = new StringCalculatorProvided();
			sc.SetCalString(value);
					
			result = sc.GetResult();
			if (sc.IsError()) {
				Console.WriteLine("Wrong Input: " + express + "  Not Support Parameter Express!Value");
				Console.WriteLine(sc.GetErrorMessage());
						 
			} else
				strr = result.ToString();
			return  strr;
		}
		/// <summary>
		/// 计算返回结果 但是不修改表达式的值
		/// </summary>
		/// <returns></returns>
//		public string GetValueEx()
//		{
//			string str = UIController.SimpleCal(express);
//			if (str == null) {
//				str = "0";
//				throw new ExpError("ExpError::Something Wrong Happened!Ex");				
//			}
//			value = str;
//			return str;
//		}
		/// <summary>
		/// 一次性计算出结果 返回结果值并修改表达式
		/// </summary>
		/// <returns></returns>
//		public string GetValueFinal()
//		{
//			string str = UIController.SimpleCal(value);
//			if (str == null) {
//				str = "0";
//				throw new ExpError("ExpError::Something Wrong Happened!Final"+'\n');
//				
//			}
//			value = str;
//			express = str;
//			return str;
//		}
		protected string express = "0";
		protected string value;
		public string GetExpress()
		{
			return express;
		}
		public  override string  ToString()
		{
			return("Express:" + GetExpress() + "  Value:" + GetValueEx());
		}
		#region 四则运算
		
		public static ExpData operator *( ExpData a,ExpData b)
		{
			return   new ExpData((double.Parse(a.GetValueEx())* double.Parse(b.GetValueEx())).ToString());
		}
		public static ExpData operator /( ExpData a,ExpData b)
		{
			return   new ExpData((double.Parse(a.GetValueEx())/ double.Parse(b.GetValueEx())).ToString());
		}
		public static ExpData operator +( ExpData a,ExpData b)
		{
			return   new ExpData((double.Parse(a.GetValueEx())+ double.Parse(b.GetValueEx())).ToString());
		}
		public static ExpData operator -( ExpData a,ExpData b)
		{
			return   new ExpData((double.Parse(a.GetValueEx())- double.Parse(b.GetValueEx())).ToString());
		}
		public static ExpData operator ^( ExpData a,ExpData b)
		{
			return   new ExpData((Math.Pow(double.Parse(a.GetValueEx()),double.Parse(b.GetValueEx()))).ToString());
		}
		
		
		
		#endregion
		
		
		
	}
	public class ExpError:Exception
	{
	 
		 
			
		public ExpError(string str):base(str)
		{
			
		}
	}
}
