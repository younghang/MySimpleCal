/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2015/10/11
 * Time: 13:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UIController
{
	/// <summary>
	/// Description of DealInput.
	/// </summary>
	class DealAssignment
	{
		public DealAssignment(string str)
		{
			strExpress = str;
		}
		readonly string strExpress = "";
		CalData cd;
		
		public   DataType GetDataType()
		{
			DataType dt = new DataType();
			
			function.FuncString funstring = new function.FuncString(strExpress);
			
			int leftSquareBracket = funstring.FindOp(0, '[');
			int rightSquareBracket = funstring.FindOp(0, ']');
			int leftBracket = funstring.FindOp(0, '(');
			int rightBracket = funstring.FindOp(0, ')');
			int commaSymbol = funstring.FindOp(0, ',');
			int semicolon = funstring.FindOp(0, ';');
			
			if (commaSymbol == -1 && semicolon == -1) {
				dt = DataType.EXP;
				cd = new ExpData(strExpress);
				(cd as ExpData).GetValueFinal();
				return dt;
			}
			if (semicolon != -1) {
				dt = DataType.MATRIX;
				ConvertToMatrix();
				
				return dt;
				
			}
			if (commaSymbol != -1) {
				dt = DataType.BLOCK;
				ConverToBlock();
				return dt;
				
			}
			
			
			return dt;
		}
		public CalData GetCalData()
		{
			if (cd == null) {
				GetDataType();
			}
			return cd;
		}
		public BlockData ConverToBlock()
		{
			function.FuncString funstring = new function.FuncString(strExpress);
			int leftBracket = funstring.FindOp(0, '(');
			int rightBracket = funstring.FindOp(0, ')');
			int commaSymbol = funstring.FindOp(0, ',');
		 
			string[] ab = strExpress.Split(',');
			double a = 0;
			double b = 0;
			try {
				string strA = new ExpData(ab[0].Substring(1)).GetValueEx();
				string strB = new ExpData(ab[1].Substring(0, ab[1].Length - 1)).GetValueEx();
				a = double.Parse(strA);
				b = double.Parse(strB);
				
			} catch (ExpError e) {
				throw new AssignedError(e.Message+"\nAssignmentError::区间转换出错"+"\n");
			 
			}
			BlockData bd = new BlockData(a, b);
			bool left;
			bool right;
			if (leftBracket != -1 && leftBracket < commaSymbol) {
				left = false;
			} else
				left = true;
			if (rightBracket != -1 && rightBracket > commaSymbol) {
				right = false;
			} else
				right = true;
			bd.SetBlockBounderAvailable(left, right);
			cd = bd;
			return bd;
		}
		public Matrix ConvertToMatrix()
		{
			string tempExpress = strExpress.Substring(1, strExpress.Length - 2);
			string[] rows = tempExpress.Split(';');
			string[] firstRow = rows[0].Trim().Split(new char[]{ ' ', ',' });
			int col =0;
			for (int i = 0; i < firstRow.Length; i++) {
				if (string.IsNullOrEmpty(firstRow[i])) {
					
				}
				else
				{
					col++;
				}
			}
			int row = rows.Length;
			double[,] data = new double[row, col];
			try {
				for (int i = 0; i < row; i++) {
					string[] singlerow = rows[i].Trim().Split(new char[]{ ' ', ',' });
					int column = 0;
					for (int j = 0; column < col; j++) {
						if (j < singlerow.Length) {				
						
							if (string.IsNullOrEmpty(singlerow[j])) {							 
								continue;
							}
							string str = new ExpData(singlerow[j].Trim()).GetValueEx();
							data[i, column] = double.Parse(str);
						} else {
							data[i, column] = 0;
						}
						column++;
					}
				}
			} catch(ExpError e) {
				throw new AssignedError(e.Message+"\nAssignmentError::矩阵转换出错\n");
			}
			Matrix matrix = new Matrix(data);
			cd = matrix;
			return matrix;
			
		}
		
		
	}
	class AssignedError :Exception
	{
		readonly string strError = "";
		public AssignedError(string str)
			: base(str)
		{
			strError = str;
		}
	}
}
