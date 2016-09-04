/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2015/5/3
 * Time: 14:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace calculator1_0
{
	/// <summary>
	/// Description of Calculator.
	/// 此类保存运算方法
	/// </summary>exp   sum   avg   ln   lg   asin   acos   atan
	public class Calculator
	{//差一个3！之类的 阶乘 运算符  /finished
		public Calculator()
		{
			SetRad(false);
			FuncName.AddFunc("exp",1);
			FuncName.AddFunc("sum",0);
			FuncName.AddFunc("avg",0);
			FuncName.AddFunc("ln",1);
			FuncName.AddFunc("lg",1);
			FuncName.AddFunc("asin",1);
			FuncName.AddFunc("acos",1);
			FuncName.AddFunc("atan",1);
		}
		/// <summary>
		/// 为后续改的 避免没有初始化Calculator的时候发现未定义函数 解决输入检查的问题
		/// </summary>
		public  bool CheckFunName (string strfuncname)
		{
			return FuncName.CheckFunName(strfuncname);
		}
		
		public bool Wrong=false;
		private static double pi=1;
		public static double   PI=Math.PI;
		public static double   E=Math.E;
		public static void SetRad(bool i)
		{
			if (i) {
				pi=Math.PI/180;
			}
			else pi=1;
			
		}
		public double CalSingleOperator(double a,double b,char c)
		{
		
			switch (c ) {
				case '+':return a+b;
				case '-':return a-b;				
				case '*':return a*b;				
				case '/':return a/b;
				case '^':return Math.Pow(a,b);
				default:SortBlock2G.error.ErrorMessage+="包含未知运算符\n";Wrong=true; return 0;
			}
		}
		
		
		
		#region 函数集合
		private double Sum(double[] add)
		{
			double result=0;foreach (var element in add) {
						result+=element;
						}
					return result;
		}
		private double Average(double [] add)
		{
			
			return Sum(add)/add.Length;
		}
		public int  Factorial(double num)
		{
			int re=1;
			// disable once CompareOfFloatsByEqualityOperator
			if (Int32.Parse(num.ToString())==num) {
				try {
					for (int i = 1; i <= num; i++) {
					re*=i;
				}
				} catch (Exception) {
					
					 SortBlock2G.error.ErrorMessage+="阶乘对象出问题maybe 数值过大";
					 Wrong=true;
				
				 
				}
				
				return re;
			}
			SortBlock2G.error.ErrorMessage+="阶乘对象出问题";
			Wrong=true;
				
				return 0;
				
		}
		#endregion
		
		
		
		public double CalFunc(string str,   double[]  add)
		{
			//无参数数量限制
			switch (str) {
					case "sum":return Sum(add);
					case "avg": return Average(add);
					}
			//有限制		 
			if (!FuncName.CheckFun(str,add.Length)) {
				SortBlock2G.error.ErrorMessage+="函数: "+str+"参数个数错误,应为"+FuncName.options[FuncName.FindName(str)].GetFunNum()+"\n";
				Wrong=true;
				
				return 0;
			}
			
 
			switch (add.Length) {
					case 1 :return CalFunc(str,add[0]);
					case 2 :return CalFunc(str,add[0],add[1]);
					default:SortBlock2G.error.ErrorMessage+="该函数参数个数错误 \n";Wrong=true; return 0;
			}
		}
		public double CalFunc(string str,double num1,double num2)
		{
			switch (str) {
					
					case "pow":return Math.Pow(num1,num2);
					 
					case "log":return Math.Log(num2,num1);
					 
					
					
				 
				default:SortBlock2G.error.ErrorMessage+="该函数参数错误，仅包含两个参数\n";Wrong=true;
					return 0;
					 
			}
		}/// <summary>
		/// 单参数函数的求值
		/// </summary>
		/// <param name="str">函数名 添加新的函数必须在FuncName的Option[] 数组中添加登记才有效</param>
		/// <param name="num">参数</param></param>
		/// <returns>计算结果</returns>
		public double  CalFunc(string str,double num)
		{
			switch (str) {
					
					case "sin":return Math.Sin(num*pi);
					 
					case "cos":return Math.Cos(num*pi);
					 
					case "tan":return Math.Tan(num*pi);
					
					 
					case "sqrt":return Math.Sqrt(num);
					case "abs":return Math.Abs(num);
					case "circlearea":return Math.PI*num*num; 
					case "exp": return Math.Exp(num);
					case "ln":return Math.Log(num);
					case "lg" :return Math.Log10(num);
					case "asin":return Math.Asin(num)*180/PI;
					case "acos":return Math.Acos(num)*180/PI;
					case "atan":return Math.Atan(num)*180/PI;
				default:SortBlock2G.error.ErrorMessage+="该函数参数错误，仅包含一个参数或者函数错误\n";Wrong=true;
					return 0;
					 
			}
		}
		
	}
}
