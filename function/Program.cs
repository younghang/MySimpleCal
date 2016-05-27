/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2015/8/18
 * 时间: 20:23
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Threading;
 
using function;
using System.Windows.Forms.DataVisualization.Charting;
namespace function
{
	class Program
	{
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World! This is an essential part to that claculator.");
			Thread.Sleep(1000);
			return;
			
			// TODO: Implement Functionality Here
//			StringCalculator cs=new StringCalculator();
//			string str="1+6/3-2*1+sin(30)*3!+2^2-pow(3d-1,2*cos(0))";
//			cs.SetCalString(str);
//			Console.WriteLine(str+"\n"+cs.GetResult());
			

			
//			while (true) {
//				FuncString funcstring=new FuncString();
//			    funcstring.UIGetString();
//			    funcstring.AnalyseEquation();
//			    Console.WriteLine(funcstring.GetFuncExpressTemp());
//			    FuncCal fun=new FuncCal();
//			    fun.SetFuncString(funcstring);
//			    fun.DealFuncstring(30,13);
//			    Console.WriteLine(fun.GetResult().ToString());
//			    funcstring.ShowParamers();
//			    FuncForm ff=new FuncForm();
//			    Thread th=new Thread(new ThreadStart(()=>ff.ShowDialog()));
//			    th.Start();
//			    fun.DealFuncstring("2","3");
//			     Console.WriteLine(fun.GetResult().ToString());
//			      f(x,y)=x^2+y^2
//			    funcstring.ShowParamers();
//			}
			
			
			#region 画图测试
			MyChart mc=new MyChart();
			mc.SetChartArea();
			FuncCal fc=new FuncCal();
			fc.SetFuncString(new FuncString("f(x)=cos(x)"));
			double x=-Math.PI;
			for (int i = 0; i <300; i++) {
//				fc.DealFuncstring(fc.ChangeDataToD(x.ToString()).ToString());
//				fc.DealFuncstring( ((decimal)x).ToString());
				fc.DealFuncstring(x.ToString("f5"));
				mc.CreateSeriesData(x,fc.GetResult());
				 
				x=x+2.0*Math.PI/300;
				Console.WriteLine(i+"  X={0}\tY={1}",x.ToString(),fc.GetResult());
			}
//			mc.CreateSeriesDatas(new double[]{1,2,3,4,5,6,7,8},new double[]{1,-1,1,-1,1,-1,1,-1});
			mc.SetSeries();
			FuncFigure ff=new FuncFigure();
			ff.AddChart(mc.GetChart());
		    Thread th=new Thread(new ThreadStart(()=>ff.ShowDialog()));
		    th.Start();
			#endregion
			
		
		 
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		 
		
		
	
    
		
	}
}