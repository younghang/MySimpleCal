/*
 * Created by SharpDevelop.
 * User: young
 * Date: 2016/5/5 星期四
 * Time: 18:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ConsoleCal
{
	class Program
	{
		public static void Main(string[] args)
		{
//			Console.WriteLine("Hello World!");
			
			UIController uc=new UIController();
			uc.Run();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}