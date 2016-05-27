/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2015/10/16
 * Time: 23:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UIController
{
	class Program
	{
		public static void Main(string[] args)
		{
//			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			UIController con=new UIController();
			con.Run();
//			TestMatrixConvert();
//			
//			Console.ReadKey(true);
			//     fx(x,y)=x+y^2
			//     fx(1,3)
		}
		public static void TestMatrixConvert()
		{
			DealAssignment da = new DealAssignment("[ 1  ,   2      ; 4     5    ]");
			Matrix ma = da.ConvertToMatrix();
			Matrix re=ma^2;
			Matrix remulti=ma*ma;
			ShowStr(re.ToString());
			ShowStr(remulti.ToString());
				
			
		}
		static void  ShowStr(string str)
		{
			Console.WriteLine(str + "\n");
		}
	}
}