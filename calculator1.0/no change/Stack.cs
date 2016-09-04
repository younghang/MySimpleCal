 
using System;

namespace calculator1_0
{
	/// <summary>
	/// Description of Stack.
	/// 定义数据结构及其操作，主要是用来方便运算中置表达式
	/// </summary>
	public class Stack<T>  
	{
		const int max=100;
		public Stack()
		{
			Top=-1;
		}
 
		private T popbuttom;
		public CalError message=new CalError ();
		private int Top;
		private T[] Data=new T [max];
		public void SetBottom(T a)//这个有待利用
		{
			popbuttom =a;//直接负号开头的时候比如-3*4，能够计算 不设定 系统默认为0
			
		}
		public void Push(T num)
		{
			if(Top<=max)
			{
				Top++;
				Data [Top]=num;
				
			}
			else 
			{
				message.IF=true;
				message .ErrorMessage +="到栈顶！\n";
			}
				
			
		}
		public T TopElement()//这个没必要,我错了这个还是很有用的，不同于Pop
		{
			 
				return Data[Top];
			
		}
		public bool IsNotEmpty()
		{//非空就返回真
			if (Top!=-1)
				return true  ;
			else return false ;
		}
		public T Pop()
		{
			if (Top!=-1)
			{
				T a= Data [Top];
				Top --;
				return a;
				
			}
			else //这个无奈必须要有返回，当到栈底的时候返回一个设定值
				//其实我是不想它有什么返回的因为控制不到栈底的if判断在其他地方写好了
			{
				message .ErrorMessage +="到栈底！\n";
				message.IF=true;
				return popbuttom ;
				
			}
			
			
		}
		public string ShowErrorInfomation()
		{
			return message.ErrorMessage;
		}
		public bool IsError()
		{
			if(message.IF)
				return true;
			else return false;
		}
		 
	}
}
