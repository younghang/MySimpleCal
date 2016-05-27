/*
 * Created by SharpDevelop.
 * User: young
 * Date: 2016/4/29 星期五
 * Time: 13:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using calculator1_0;

namespace MatrixProject
{
	[TestFixture]
	public class MatrixCalTest
	{
		[Test]
		public void TestMethod()
		{
			Matrix a=new Matrix(3);
			a.SetUnit(3);
			double  re=Calculator.CalSingleOperatorGeneric(2.2,2,'*');
			ShowStr(re);
			
		}
		static void  ShowStr(  object str)
		{
			Console.WriteLine(str.ToString() + "\n");
		}
	}
}
