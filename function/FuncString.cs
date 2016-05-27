/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2015/10/11
 * Time: 0:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
 
using calculator1_0;
namespace function
{
	/// <summary>
	/// Description of FuncString.
	/// 完成函数字符串的解析 和 参数的替换 返回一个包含 函数名，函数表达式，参量 的对象
	/// </summary>
	public class FuncString: CalString
	{
		public FuncString()
		{
			
		}
		public FuncString(string strName,string strExpress,string [] paramers)
		{
			this.FuncName=strName;
			FuncExpress=strExpress;
			Parameters=paramers;
		}
		public FuncString(string str)
		{
			this.SetString(str);
		}
		string FuncName="";
		string FuncExpress="";
		string FuncExpressTemp="";
		string [] Parameters=null;
		public bool Wrong=false;
		
		/// <summary>
		/// 完成输入表达式的转换
		/// </summary>
		/// <returns>
		/// return 4; f(1,2)保留了FuncName="f",FuncExpressTemp="1,2"
		/// return 1; x,x+y 类型返回FuncName=x,x+y
		/// return 2; 赋值x=1
		/// return 3; 表达式定义 f(x,y)=x+y
		/// return 5; x=[1,2]
		/// </returns>
		public int  AnalyseEquation()
		{
			
			string equation=this.GetString();
			int leftbraket=this.FindOp(0,'(');
			int leftsquarebracket=this.FindOp(0,'[');
			int equalsign=this.FindOp(0,'=');
			if (equalsign==-1) {//没有等号
				if (leftbraket != -1) {//有括号
					int rightbraketd = this.FindOp(leftbraket, ')');
					FuncName = this.FromToEnd(-1, leftbraket - 1);
					FuncExpressTemp = this.FromToEnd(leftbraket, rightbraketd - 1);
					return 4;//f(1,2)保留了FuncName="f",FuncExpressTemp="1,2"
				}
				
					//没有括号
				FuncName = equation.Trim();
				
				return 1;//变量 x , f(1,2)， x+y，plot(f)等情况
			
			}
			if (leftbraket==-1||equalsign<leftbraket||equalsign<leftsquarebracket) {
				FuncName=this.FromToEnd(-1,equalsign-1);
				FuncExpress=this.FromToEnd(equalsign,this.GetLength()-1);
				return 2;//赋值 x=1
			}
			int rightbraket=this.FindOp(leftbraket,')');
			FuncName=this.FromToEnd(-1,leftbraket-1);
			
			string lefteq=FromToEnd(leftbraket,rightbraket);
			FuncString leftfunc=new FuncString();
			leftfunc.SetString(lefteq);
			int[] split = leftfunc.FindOpOutOfBrackets( ',' );
			
			split = PushToHead<int >(split, -1);
			string[] strsplit = new string[20];//保存分割后的字符串
			for (int j = 0; j < split.Length - 1; j++) {
				strsplit[j] = leftfunc.FromToEnd(split[j], split[j + 1] - 1);
			}
			
			strsplit[split.Length - 1] = leftfunc.FromToEnd(split[split.Length - 1], leftfunc.GetLength() -2);
			Parameters=strsplit;
			int EqualSign=FindOp(rightbraket,'=');
			
			FuncExpress=FromToEnd(EqualSign,GetLength()-1);
			FuncExpressTemp=FuncExpress;
			//   f(x,y)=skjhf
			return 3;//表达式
			
			
		}
		public string GetFuncExpress()
		{
			return this.FuncExpress;
		}
		public string GetFuncExpressTemp()
		{
			return this.FuncExpressTemp;
		}
		public string[] GetParamers(){
			return Parameters;
		}
		public string GetFuncName()
		{
			return FuncName;
		}
		public void SetFuncName(string  name)
		{
			FuncName=name;
		}
		public void SetFuncExpress(string  express)
		{
			FuncExpress=express;
		}
		public void SetParamers(string[]ss)
		{
			Parameters=ss;
		}
		public void SetFuncExpressTemp(string  temp)
		{
			FuncExpressTemp=temp;
		}
		public void ResetWrong(){
			Wrong=false;
		}
		public void ReplaceFuncExpressTemp( params string  [] number)
		{//让FuncExpressTemp这个属性发生改变
			Wrong=false;
			if (Parameters==null||Parameters[0]==null||Parameters[0]==""||number[0]=="") {
				Wrong=true;
				return ;
			}
			FuncString funcexpress=new FuncString();
			funcexpress.SetString(FuncExpress);//初始化
			for (int i = 0;i<number.Length&&Parameters[i]!=null; i++) {
				
		 		FuncExpressTemp=funcexpress.ReplaceAllEks("("+number[i]+")",funcexpress.FindAllString(Parameters[i]),Parameters[i].Length);
//				FuncExpressTemp=funcexpress.ReplaceAllEks(number[i],funcexpress.FindAllString(Parameters[i]),Parameters[i].Length);
				
				funcexpress.SetString(FuncExpressTemp);
			}
			
			
		}
		
		public void ShowParamers()
		{
			string paramers="";
			if (Parameters!=null)
				foreach (var element in Parameters) {
				paramers+=element+"   ";
			}
			Console.WriteLine(FuncName+'\n'+paramers+'\n'+FuncExpress+'\n'+FuncExpressTemp);
		}
	}
}
