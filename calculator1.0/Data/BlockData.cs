/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2016/1/4
 * Time: 14:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace calculator1_0
{
	/// <summary>
	/// Description of Block.
	/// </summary>
	public class BlockData:CalData
	{
		public BlockData()
		{
			CalType=DataType.BLOCK;
		}
		private double x_start;
		private double x_end;
		private bool left=true;
		private bool right=true;
		
		public BlockData(double x0,double x1){
			CalType=DataType.BLOCK;
			x_start=x0;
			x_end=x1;
			
		}
		public void SetBlock(double x0,double x1){
			x_start=x0;
			x_end=x1;
			
		}
		public void SetBlockBounderAvailable(bool left,bool right)
		{
			this.left=left;
			this.right=right;
			
		}
		public bool IsLeftAvailable()
		{
			return left;
		}
		public bool IsRightAvailable()
		{
			return  right ;
		}
		public double GetXStart()
		{
			return x_start;
		}
		public double GetXEnd()
		{
			return x_end;
		}
		public override string ToString()
		{
			string str_block="";
			if (left) {
				str_block+="[";
			}
			else
				str_block+="(";
			str_block+=x_start;
			str_block+=",";
			str_block+=x_end;
			if (right) {
				str_block+="]";
			}
			else 
				str_block+=")";
			return str_block;
		}
		
		
	}
}
