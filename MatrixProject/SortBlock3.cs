/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2015/6/12
 * Time: 1:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using calculator1_0;


namespace MatrixProject
{
	/// <summary>
	/// Description of SortBlock3.
	/// 暂时不用 尚未完成 不想弄了
	/// 版本号1.2.3.1
	/// 这个类主要采取 数字+函数名称的方式来计算 配以多线程 
	/// 先用括号分割 分别计算后,在压入Data数组中,最后调用函数计算结果
	/// 或者还是保留+-*^等和数值 函数符号 一起压入Data?
	/// </summary>
	public class SortBlock3
	{
		Calculator calculator=new Calculator();
		FuncName funcName=new FuncName();
		Stack<double> stacknum=new Stack<double>();
		Stack<string> stackfunc=new Stack<string>();
		Data []data=new Data[100];
		CalString calstr=null;
        //bool Wrong=false;
		public SortBlock3()
		{
		}
		public void SetCalString(string str)
		{
			calstr=new CalString(str);
		}
		public void PutNumToData()
		{
			
		}
		public void PutFuncToData()
		{
			
		}
		public double GetResult()
		{
			double result=0;
			
			
			
			return result;
		}
		public double GetSimpleResult()
		{
//			//bugaid,只是最终完成简单的四则运算,添加单目运算符支持很简单的,基本上不用改什么
//			double sum=0;
//			for (int i = 0;data[i]!=null ; i++) {
//				
//				if (data[i].GetTypeN()==1) {
//					stacknum .Push (data[i].GetNum());
//				}
//				else
//				{
//					double num1=stacknum .Pop ();
//					double num2=stacknum .Pop ();
//					sum =calculator.CalSingleOperator(num2,num1 ,data[i].GetOption().op);
//					stacknum .Push (sum );
//					
//				}
//					
//			}
//			double result=stacknum .Pop ();
//			 
//			if (stacknum .IsNotEmpty ()) {
//                //Wrong=true;
//				stacknum .message.ErrorMessage+="Express Wrong！"  ;
//			}
//			return result ;
//			

return 0;
		
		}
		public void SortString()
		{
			
		}
		
	}
}
