/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2015/5/1
 * Time: 11:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using calculator1_0;

namespace MatrixProject
{
	/// <summary>
	/// Description of Data.
	/// 数据保存形式
	/// </summary>
	public class Data 
	{
		#region implemented abstract members of CalData

		public override string ToString()
		{
			throw new NotImplementedException();
		}

		#endregion

		public Data()
		{
		}
		private CalData caldata=null;
		private Option option = null;
//		private Double num;
		private FuncName fun = null;
//		public void SetNum(double a)
//		{
//			this.num = a;
//			TypeN = 1;
//		}
		public void SetCalData(CalData a)
		{
			this.caldata = a;
			TypeN = 1;
		}
		public void SetFun(FuncName a)
		{
			this.fun = a;
			TypeN = 3;
		}
		public void SetOption(Option op)
		{
			this.option = op;
			TypeN = 2;
			
		}
		int TypeN = 0;
		public int GetTypeN()
		{
			return TypeN;
		}
//		public double GetNum()
//		{
//			return num;
//		}
		public Option GetOption()
		{
			return option;
		}
		public CalData GetCalData()
		{
			return caldata;
		}
			
		public FuncName GetFunc()
		{
			return fun;
		}
		
	}
}
