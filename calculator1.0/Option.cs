 
using System;

namespace calculator1_0
{
	/// <summary>
	/// Description of Option.
	/// 规定运算优先级
	/// </summary>
	public class Option:IComparable <Option >
	{
		public Option(char opq)
		{
			op =opq;
		}
		public char op;
		public  int CompareTo(Option other)
		{
			//压入堆栈，返回-1
			//弹出堆栈，返回1
			//2 表示一直弹出直到（为止
			
			if (op =='('||op =='^'||op=='!') {
				return -1;
			}
//			if (other .op =='#') {//这样就不需要判断第一次压栈，其实你一开始就已经不需要第一次判断了
//				return -1;//这个if也没有必要写
//			}
			if (op ==')') {
				if (other .op =='(') {
					return 2;//特殊标记一下，
				}
				else return 1;
			}
			if (other .op =='(') {
				return -1;
			}
			else
			{
				if (other.op=='*'||other.op=='/'||other.op=='^'||other.op=='!') 
				{
					return 1;
				}
				
			
				else 
				{
					if (op =='*'||op=='/'||op=='^')  {
						return -1;
					}
					 
					else return 1;
				}
			}
		}
	}
}
