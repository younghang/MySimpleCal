/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2015/5/3
 * Time: 14:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using calculator1_0;
namespace MatrixProject
{
	/// <summary>
	/// Description of Calculator.
	/// 此类保存运算方法
	/// </summary>exp   sum   avg   ln   lg   asin   acos   atan
	public class Calculator
	{
		//差一个3！之类的 阶乘 运算符  /finished
		public Calculator()
		{
			SetRad(false);
			FuncName.AddFunc("exp", 1);
			FuncName.AddFunc("sum", 0);
			FuncName.AddFunc("avg", 0);
			FuncName.AddFunc("ln", 1);
			FuncName.AddFunc("lg", 1);
			FuncName.AddFunc("asin", 1);
			FuncName.AddFunc("acos", 1);
			FuncName.AddFunc("atan", 1);
		}
		/// <summary>
		/// 为后续改的 避免没有初始化Calculator的时候发现未定义函数 解决输入检查的问题
		/// </summary>
		public  bool CheckFunName(string strfuncname)
		{
			return FuncName.CheckFunName(strfuncname);
		}
		
		public bool Wrong = false;
		private static double pi = 1;
		public static double PI = Math.PI;
		public static double E = Math.E;
		public static void SetRad(bool i)
		{
			if (i) {
				pi = Math.PI / 180;
			} else
				pi = 1;
			
		}

		public Matrix CalSingleOperatorMatrix(Matrix a, Matrix b, char c)
		{
			
			switch (c) {
				case '+':
					return a + b;
				case '-':
					return a - b;
				case '*':
					return a * b;
				case '/':
					return a / b;
					
				default:
					SortBlockData.error.ErrorMessage += "包含未知运算符\n";
					Wrong = true;
					return null;
			}
		}
		/// <summary>
		/// 计算四则运算
		/// </summary>
		/// <param name="a">返回值类型，第一个运算数</param>
		/// <param name="b">第二个运算数</param>
		/// <param name="c">运算符</param>
		/// <returns></returns>
		public  static T CalSingleOperatorGeneric<T,S>(T a, S b, char c)
//			where T :IComparable<T>,new()
		{
			dynamic ca = a;
			dynamic cb = b;
			
			switch (c) {
				case '+':
					
					return ca + cb;
				case '-':
					return ca - cb;
				case '*':
					return ca * cb;
				case '/':
					return ca / cb;
				case '^':
					return ca ^ cb;
				default:
					throw new CalculatorException("包含未知运算符\n");
					
			}
		}
		public   double CalSingleOperator(double ca, double cb, char c)
//			where T :IComparable<T>,new()
		{
			
			
			switch (c) {
				case '+':
					
					return ca + cb;
				case '-':
					return ca - cb;
				case '*':
					return ca * cb;
				case '/':
					return ca / cb;
				case '^':
					return Math.Pow(ca, cb);
				default:
					SortBlockData.error.ErrorMessage += "包含未知运算符\n";
					Wrong = true;
					return 0;
					
			}
		}
		
		
		#region 函数集合
		private static  T Sum<T>(T[] add)
		{
			dynamic result = default(T);
			foreach (var element in add) {
				result += element;
			}
			return (T)result;
		}
		private static T Average<T>(T[] add)
		{
			dynamic sum = Sum(add);
			return  sum / add.Length;
		}
		public  int  Factorial(double num)
		{
			int re = 1;
			// disable once CompareOfFloatsByEqualityOperator
			if (Int32.Parse(num.ToString()) == num) {
				try {
					for (int i = 1; i <= num; i++) {
						re *= i;
					}
				} catch (Exception) {
					
					SortBlockData.error.ErrorMessage += "阶乘对象出问题maybe 数值过大";
					Wrong = true;
					
					
				}
				
				return re;
			}
			SortBlockData.error.ErrorMessage += "阶乘对象出问题";
			Wrong = true;
			
			return 0;
			
		}
		#endregion
		
		
		
		public static CalData CalFunc (string str, CalData[]  add)
		{
			//无参数数量限制
			switch (str) {
				case "sum":
					return Sum(add);
				case "avg":
					return Average(add);
			}
			//有限制
			if (!FuncName.CheckFun(str, add.Length)) {
				SortBlockData.error.ErrorMessage += "函数: " + str + "参数个数错误,应为" + FuncName.options[FuncName.FindName(str)].GetFunNum() + "\n";
				throw new CalculatorException(SortBlockData.error.ErrorMessage);
			}
			
			
			switch (add.Length) {
				case 1:
					return CalFunc(str, add[0]);
				case 2:
					return CalFunc(str, add[0], add[1]);
				default:
					SortBlockData.error.ErrorMessage += "该函数参数个数错误 \n";
					throw new CalculatorException("该函数参数个数错误 \n");
					
			}
		}
		public static T CalFunc<T>(string str, T paramer1, T paramer2)
		{
			dynamic num1 = paramer1;
			dynamic num2 = paramer2;
			switch (str) {
					
				case "pow":
					return Math.Pow(num1, num2);
					
				case "log":
					return Math.Log(num2, num1);
				default:
					SortBlockData.error.ErrorMessage += "该函数参数错误，仅包含两个参数\n";
					throw new CalculatorException("该函数参数错误，仅包含两个参数\n");
					
					
			}
		}
		/// <summary>
		/// 单参数函数的求值
		/// </summary>
		/// <param name="str">函数名 添加新的函数必须在FuncName的Option[] 数组中添加登记才有效</param>
		/// <param name="num">参数</param></param>
		/// <returns>计算结果</returns>
		public static CalData CalFunc(string str, CalData paramer)
		{
			double num =0;
			if (new Calculator().CheckFunName(str)) {
				num = double.Parse((paramer as ExpData).GetValueEx());
			}
			
			
			switch (str) {
					
				case "sin":
					return    new ExpData(Math.Sin(num * pi).ToString());
					
				case "cos":
					return   (new ExpData(Math.Cos(num * pi).ToString()));
					
				case "tan":
					return   (new ExpData(Math.Tan(num * pi).ToString()));
					
					
				case "sqrt":
					return   (new ExpData(Math.Sqrt(num).ToString()));
				case "abs":
					return   (new ExpData(Math.Abs(num).ToString()));
				case "circlearea":
					return    (new ExpData((Math.PI * num * num).ToString()));
				case "exp":
					return   new ExpData((Math.Exp(num).ToString()));
				case "ln":
					return   new ExpData((Math.Log(num)).ToString());
				case "lg":
					return   new ExpData((Math.Log10(num)).ToString());
				case "asin":
					return   new ExpData((Math.Asin(num) * 180 / PI).ToString());
				case "acos":
					return   new ExpData((Math.Acos(num) * 180 / PI).ToString());
				case "atan":
					return  new ExpData((Math.Atan(num) * 180 / PI).ToString());
				default:
					throw new CalculatorException("该函数参数错误，仅包含一个参数或者函数错误\n");
					
					
			}
		}
		
	}
	class CalculatorException:Exception
	{
		public CalculatorException(string str)
			: base(str)
		{
			
		}
	}
}
