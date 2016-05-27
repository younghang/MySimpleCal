/*
 * Created by SharpDevelop.
 * User: young
 * Date: 2016/4/24 星期日
 * Time: 0:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
 

namespace UIController
{
	[TestFixture]
	public class MatrixTest
	{
		//		[TestAction]
		public void TestMethod()
		{
			double[,] mdata = { { 1525220, 2, 3 }, { 4, 5.2663, 6 }, { 7, 8, 6 }, { 4, 2, 30.2663253 } };
			Matrix matrix = new Matrix(mdata);
			Console.WriteLine(matrix.ToString());
			Console.WriteLine(matrix.getColumn(2).ToString());
			Console.WriteLine(matrix.getRow(3).ToString());
			
		}
		
		public void OtherTest()
		{
			double[,] mdata = { { 1525220, 2, 3 }, { 4, 5.2663, 6 }, { 7, 8, 6 }, { 4, 2, 30.2663253 } };
			Console.WriteLine(mdata.GetLowerBound(0) + "\n");
			Console.WriteLine(mdata.GetLowerBound(1) + "\n");
			Console.WriteLine(mdata.GetUpperBound(0) + "\n");
			Console.WriteLine(mdata.GetUpperBound(1) + "\n");
			
			
		}
		
		public void OtherEqualTest()
		{
//			Matrix a=new Matrix(new Double[2,2]{{1,20},{4,6}});
			
//			Matrix b=new Matrix(new Double[2,2]{{2,20},{4,85}});
			Matrix a = new Matrix(3);
			Matrix b = new Matrix(3);
			ShowStr((a == b).ToString());
			
		}
		static void  ShowStr(string str)
		{
			Console.WriteLine(str + "\n");
		}
		static void  ShowStr(  Matrix str)
		{
			Console.WriteLine(str.ToString() + "\n");
		}
		[Test]
		public void TestMatrixConvert()
		{
			DealAssignment da = new DealAssignment("[ 1  ,   2      ; 4     5    ]");
			Matrix ma = da.ConvertToMatrix();
			Matrix re=ma^2;
			Matrix remulti=ma*ma;
			ShowStr(re.ToString());
			ShowStr(remulti.ToString());
			
			
		}
		
		public void TestMatricOperation()
		{
			Matrix m=new Matrix(3);
			m.SetValue(1);
			ShowStr(  m);
		}
		
		public void TestMatrixCal()
		{
			Matrix a = new Matrix(new Double[2, 2]{ { 1, 20 }, { 4, 6 } });
			
			Matrix b = new Matrix(new Double[2, 2]{ { 2, 20 }, { 4, 85 } });
			Matrix c=2.1*a;
			ShowStr(a.ToString());
			ShowStr(b.ToString());
			ShowStr(c.ToString());
		}
		
	}
}
