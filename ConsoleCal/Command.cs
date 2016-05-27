/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2016/1/4
 * Time: 0:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using function;
 

namespace ConsoleCal
{
	/// <summary>
	/// Description of Command.
	/// </summary>
	public class Command
	{
		public Command()
		{
		}
		private UIController uc = new UIController();
		public static List<string > cl = new List<string>() {
			"plot",
			"clc",
			"clear",
			"help",
			"list",
			"exit",
			"beep"
		};
		
		public void Help(string  parameters)
		{
//			Console.WriteLine(parameters);
			string showlines = "";
			AppendString apps = new AppendString();
			
			if (parameters == "") {
				
				const string firstline = "This is a discription of this calclator.\n";
				const string secondline = "You can type like this:\n";
				const string thirdline = "\t3.1+6/2+3!+3(2+7)  sin(30*pi/180)*2  or  ln(e)  \n\tA variable X can be start wtih letter or _:\n\t   a=3  t=3a  _x2=6   x=2a+3+t  try enter  a+4  a   x   \n\tf(x)=x^2+3 enter f(4/2) to get value at x=2 also fx(x,y)=x+y^2\n\t matrix is allowed e.g.   a=[1 2;   3,5 54 ] "+
					" \n\tseperated by space or commaSymbol\",\" each line by semicolon';'  try  type  a^2\n";
				const string forthline = "Here is some command:\n\tclc()\tplot()\tclear()\tlist()\tbeep()\n";
				const string fifthline = "To known the normal math function it supports:\n\ttype help(func)\n";
				const string sixthline = "The following can be explained by typing help(arg)\n\targ can be:plot clc func list\n";
				showlines += firstline;
				showlines += secondline;
				showlines += thirdline;
				showlines += forthline;
				showlines += fifthline;
				showlines += sixthline;
				Console.WriteLine(showlines);
				return;
			}
			switch (parameters) {
				case "func":
					apps.Append("Support following:\n\tsin   cos   tan   abs   sqrt   pow   log   circlearea\n\texp   sum   avg   ln   lg   asin   acos   atan");
					break;
				case "list":
					apps.Append("To show you the data it has stored\n\t");
					apps.Append("You can use it like this:\tlist(arg)\t arg can be:\n\t\texp   func   block   ");
					break;
				case "plot":
					apps.Append("To show you the function figure\n\t");
					apps.Append("\n\tf(x)=sin(x) \ta=[-pi,pi] \tplot(f,a) or \tplot(f,-3.1415,3.1415)");
					break;
				case "clc":
					apps.Append("To clear the data it has stored\n\t");
					apps.Append("\ne.g.\tclc()\t also You can use like this a=7  f(x)=x  clc(a) clc(f)");
					break;
				case "clear":
					apps.Append("To clean up the screen\n\t");
					apps.Append("\ne.g.\te.g.clear()");
					break;
				default:
					apps.Append("Not support to help  " + parameters);
					break;
			}
			Console.WriteLine(apps);
		}
		
		public void  PlotFunc(FuncString fs, int decimallength = 6, int points = 100, params double[]xstart)
		{
//			if (decimallength==0) {
//				decimallength=6;
//			}
//			if (points==0) {
//				points=100;
//			}
			double xa = xstart[0];
			double xb = xstart[1];
			double x = xa;
			MyChart mc = new MyChart();
			mc.SetChartArea();
			for (int i = 0; i < points; i++) {
				
//				fc.DealFuncstring( ((decimal)x).ToString());
//				fc.DealFuncstring(x.ToString(("f"+decimallength.ToString())));
				double result = uc.GetFuncResult(fs, x.ToString(("f" + decimallength.ToString())));
				mc.CreateSeriesData(x, result);
				
				x = x + 1.0 * (xb - xa) / points;
//				Console.WriteLine(i+"  X={0}\tY={1}",x.ToString(),fc.GetResult());
			}
//			mc.CreateSeriesDatas(new double[]{1,2,3,4,5,6,7,8},new double[]{1,-1,1,-1,1,-1,1,-1});
			mc.SetSeries();
			FuncFigure ff = new FuncFigure();
			ff.AddChart(mc.GetChart());
			ff.ShowDialog();
			
		}
		
		public void  PlotFuncParallel(FuncString fs, int decimallength = 6, int points = 100, params double[]xstart)
		{
//			if (decimallength==0) {
//				decimallength=6;
//			}
//			if (points==0) {
//				points=100;
//			}
			double xa = xstart[0];
			double xb = xstart[1];
			double x = xa;
			MyChart mc = new MyChart();
			mc.SetChartArea();
			int times = 0;
			Parallel.For(times, points,
				(i) => {
			             	
//				fc.DealFuncstring( ((decimal)x).ToString());
//				fc.DealFuncstring(x.ToString(("f"+decimallength.ToString())));
					//在调用之前就已经把参数代进去了 fs是经过替换得到的
					double result = uc.GetFuncResult(fs, x.ToString(("f" + decimallength.ToString())));
					mc.CreateSeriesData(x, result);
			             	
					x = x + 1.0 * (xb - xa) / points;
			             	
				});
//			mc.CreateSeriesDatas(new double[]{1,2,3,4,5,6,7,8},new double[]{1,-1,1,-1,1,-1,1,-1});
			mc.SetSeries();
			FuncFigure ff = new FuncFigure();
			ff.AddChart(mc.GetChart());
			ff.ShowDialog();
			
		}
		
	}
	public  class AppendString
	{
		public string Append(string str)
		{
			strline += str;
			return strline;
		}
		public override string ToString()
		{
			return strline;
		}
		private string strline = "";
	}
}
