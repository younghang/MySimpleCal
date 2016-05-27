/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2015/10/6
 * Time: 16:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
 
using calculator1_0;
using System.Drawing;
namespace function
{
	/// <summary>
	/// Description of Function.
	/// 调用Caltor完成函数值的计算
	/// 提供绘图 求值计算 求导等 函数 应该能提供的功能
	/// </summary>
	 
	public class FuncCal
	{
		 
		public FuncCal()
		{
			
		}
		
		 

		public void SetFuncString(FuncString funcstring)
		{
			this.funcstring=funcstring;
			if (funcstring.GetFuncName()==""&&funcstring.GetFuncExpress()=="") {
				funcstring.AnalyseEquation();
			}
		}
		FuncString funcstring=null;
		public FuncString GetFuncString ()
		{
			return funcstring;
		}
		/// <summary>
		/// 这个使用前 必!须!paramers不为空 FuncExpress存在 
		/// 将表达式变成三个成员属性AnalysisEquation方法或用Set设置好
		/// 只是改变它的FuncExpressTemp属性
		/// </summary>
		/// <param name="numbers">用来改变FuncExpressTemp的方法</param>
		public void DealFuncstring(params string [] numbers)
		{
			
			funcstring.ReplaceFuncExpressTemp(numbers);
		}
		public int GetParamersCount()
		{
			return funcstring.GetParamers().Length;
		}
		public double GetResult()
		{
			if (funcstring==null) {
				return 0;
			}
			
			if(funcstring.Wrong)
				return 0;
			double result=0;
			StringCalculatorProvided sc=new StringCalculatorProvided();
			sc.SetCalString(funcstring.GetFuncExpressTemp());
			result=sc.GetResult();
			errormessge=sc.GetErrorMessage();
			return result;
		
		}
		string errormessge="";
		public bool IsWrong()
		{
			return funcstring.Wrong;
		}
		public string ErrorMessage()
		{
			funcstring.ResetWrong();
			return errormessge;
		}
		public static Decimal ChangeDataToDecimal(string strData)
        {
            Decimal dData = 0.0M;
            if (strData.Contains("E"))
            {
                dData = Convert.ToDecimal(Decimal.Parse(strData.ToString(), System.Globalization.NumberStyles.Float));
            }
            return dData;
        }
	}
}
