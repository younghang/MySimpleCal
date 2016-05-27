/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2015/10/11
 * Time: 13:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UIController
{
	/// <summary>
	/// Description of TempData.
	/// 保存常量式x=8 函数式 f(x)=x 之类的 之后还会有数组之类的
	/// </summary>
	public class TempData
	{
		public TempData(string name,CalData value)
		{
			this.Name=name;
			this.Value=value;
		}
		 
		 
		private string Name="";
		private CalData Value=null;
		 
		public string  GetName()
		{
			return Name;
		}
		public CalData GetCalData()
		{
			return Value;
		}
		public void SetValue(CalData value)
		{
			this.Value=value;
		}
		public void SetName(string name)
		{
			this.Name=name;
		}
		public override string ToString()
		{
			return string.Format("[Data Name={0}, Value=( {1} )]", Name, Value.ToString());
		}

		public function.FuncString ConvertTOFunString()
		{
			FuncData fd=(FuncData)Value;
			return new function.FuncString(Name,fd.GetExpValue(),fd.GetParamers());
		}
		 
	}
}
