/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2015/5/3
 * Time: 14:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace calculator1_0
{
	/// <summary>
	/// Description of Func.
	/// 定义函数名称作为计算的接口
	/// 起检查和在计算过程中临时保存函数名的作用（暂时）
	/// </summary>
	public class FuncName
	{
		public FuncName()
		{
			
			
		} 
		public static Stack<string> stackFuncName=new Stack<string>();
			
		public class funInfo:IComparable
		{
			#region IComparable implementation

		public int CompareTo(Object obj)
		{ 
			var objq=obj as funInfo;
			int result=0;
			if (this.funName==objq.funName&&this.funNum==objq.funNum) {
				result=1;
			}
			return result;
		}

		#endregion

			public funInfo(string funName  ,int funNum  )
			{
				this.funName=funName;
				this.funNum=funNum;
			}
			public int GetFunNum(){
				return funNum;
			}
			string funName    ;
			   int funNum  ;
		}
		public static List <funInfo> options=new List<funInfo>{
			new funInfo("sin",1),
			new funInfo("cos",1),
			new funInfo("tan",1),
			new funInfo("abs",1),
			new funInfo("sqrt",1),
			new funInfo("pow",2),
			new funInfo("log",2),
			new funInfo("circlearea",1)
	 
			
			
		};
		private string strfuncname="";
		private  static   List<string> option= new List<string>{ "sin","cos","tan","abs" ,"sqrt","pow","log","circlearea"};
		private static string character="";
		public  static string GetFunc()
		{
			return character ;
		}
		public    string GetFuncName()
		{
			return this.strfuncname ;
		}
		public static void SetFunc(string st)
		{
			character=st ;
			stackFuncName.Push(st);
		}
		public void SetFuncName(string st)
		{
			this.strfuncname=st;
		}
		public  static void InnerSetString()
		{
			if (stackFuncName.IsNotEmpty()) {
				stackFuncName.Pop();
			}
			Console.WriteLine("pop");
			character=stackFuncName.TopElement();
		}
		public static void  AddFunc(string funcname,int num)
		{
			 
			if (!CheckFunName(funcname)) {
				option.Add(funcname);
				options.Add(new funInfo(funcname,num));
//				Console.WriteLine("已添加函数"+funcname);
			}
			
		}
		public static int FindName(string strr)
		{
		 
			int index=option.FindIndex((str)=>str==strr);
			return index;
		
		}
		/// <summary>
		/// 有待进一步完善使用
		/// </summary>
		/// <param name="sr"></param>
		/// <param name="stn"></param>
		/// <returns></returns>
        public static bool CheckFun(string sr,int stn)
        {
            funInfo fi=new funInfo(sr, stn);
            bool result = false;
            result=options.Exists((s)=> {
				if (s.CompareTo(fi) == 1)
					return true;
				return false;
			});
            return result;
        }
		public static bool CheckFunName(string charac)
		{
			
			bool n=false;
			foreach( string strt in option)
			{
				n |= charac == strt;
				 
			}
			return n;
		}
	}
}
