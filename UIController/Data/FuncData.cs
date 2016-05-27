/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2016/1/15
 * Time: 11:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UIController
{
	/// <summary>
	/// Description of FuncData.
	/// </summary>
	public class FuncData:CalData
	{
		public FuncData()
		{
			CalType=DataType.FUNC;
		}
		
		public FuncData(string value,string []paramers)
		{
			
			this.expvalue=value;
			this.Paramer=paramers;
			CalType=DataType.FUNC;
		}
		public string [] GetParamers()
		{
			return Paramer;
		}
 
		private string expvalue=null;

		public string ExpValue {
			get {
				return expvalue;
			}
			set {
				expvalue = value;
			}
		}

		private string []Paramer=null;
	 
		public string GetExpValue()
		{
			return expvalue;
		}
		public void SetValue(string value)
		{
			this.expvalue=value;
		}
		public  override string  ToString (){
			return("The express is:" +GetExpValue());
		}
		 
		 
	}
}
