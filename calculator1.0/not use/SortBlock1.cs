using System;
/// <summary>
/// 能算多位数
/// </summary>
namespace calculator1_0
{
	
	class SortBlock1
	{
		private string strNum="";
		private int da=0;
		private bool Wrong=false;
		private Data[] data=new Data [100];
		private Stack <Option > stackchop=new Stack<Option > ();//保存运算符
		private Stack <double> stacknum=new Stack<double>() ;//保存运算数
		bool CheckOption(char  str)
		{
			if(str=='+'||str =='-'||str=='*'||str=='/'||str=='('||str==')'||str=='^')
				return true ;
			else
			{
				return false ;
			
			}
		}
	    private double Calculator()
		{
			double sum=0;
			for (int i = 0;data[i]!=null ; i++) {
				
				if (data[i].GetTypeN()==1) {
					stacknum .Push (data[i].GetNum());
				}
				else
				{
					double num1=stacknum .Pop ();
					double num2=stacknum .Pop ();
					sum =SampleCal(num2,num1 ,data[i].GetOption().op);
					stacknum .Push (sum );
					
				}
					
			}
			double result=stacknum .Pop ();
			 
			if (stacknum .IsNotEmpty ()) {
				Wrong=true;
				stacknum .message.ErrorMessage+="Express Wrong！"  ;
			}
			return result ;
		}
		private double SampleCal(double a,double b,char c)
		{
		
			switch (c ) {
				case '+':return a+b;
				case '-':return a-b;				
				case '*':return a*b;				
				case '/':return a/b;
				case '^':return Math.Pow(a,b);
				default:return 0;
			}
		}
		public string  GetString()//获取计算式
		{
			string str;
			Console .WriteLine ("输入计算式：\n");
			str=Console .ReadLine ();
			return str;
		}
		public string  ShowInfo()
		{
			return stackchop.ShowErrorInfomation()+stacknum.ShowErrorInfomation();
		}
		public bool IsError()
		{
			if(stacknum.IsError()||stackchop.IsError()||Wrong)
				return true;
			else return false;
		}
		private void SortString(string str)
		{
			
			
			Option opti=new Option('#');
			stackchop.SetBottom(opti);
			for (int i = 0; i < str.Length; i++) {
				if (str[i]<='9'&&str[i]>='0'||str[i]=='.') {
					strNum+=str[i];
				}
				else {
					if (strNum!="") {
				   PutNumToData();
					}
					
					if (CheckOption(str[i])) {
						if (str[i]=='('&&str[i+1]=='-') {
						data[da]=new Data();
						data[da].SetNum(0);
					 	da++;
						}
					
					
						bool push=false ;//还没有压入
						Option opt=new Option (str [i]);
						//压入堆栈，返回-1
						//弹出堆栈，返回1
						if (!stackchop .IsNotEmpty ()) {
							stackchop .Push (opt );
							push=true;
							continue;
						}
						while (stackchop .IsNotEmpty ())
						{
							int rank=opt.CompareTo (stackchop .TopElement ());
							if(rank ==-1){
								stackchop .Push (opt );
								push =true ;break ;
							}
							else if (rank ==1) {
								data[da]=new Data();
								data[da].SetOption(stackchop .Pop ()) ;
								da++;
						 
							}
							else if (rank ==2) {
								stackchop .Pop () ;
								push =true ;break ;
							}
							else if(rank ==0) break ;
						}//
						if(!push )
							stackchop .Push (opt );
																
					}
					else {stackchop .message .ErrorMessage +="include unkown characters\n";
//					      Wrong=true;//其实这句话可以不要，不要就可以 时间6+你好9=15 而不出错；
					}
				}}
			if (strNum!="") {
				PutNumToData();
					
			}
			
			while (stackchop .IsNotEmpty ())
			{
				data[da]=new Data();
			    data[da].SetOption(stackchop .Pop ()) ;
				da++;
			}
			}
		public double GetResult(string str)
		{
			SortString(str);
			return Calculator();
		}
		private void PutNumToData( )
		{
			if(IsNumRight(strNum)){
					double numer=Double.Parse(strNum);
					strNum="";
					data[da]=new Data();
					data[da].SetNum(numer);
					 
					da++;}
					else{
						Wrong=true;
						stacknum.message.ErrorMessage+="小数点错了";
						data[da]=new Data();
						data[da].SetNum(0);
					 	da++;
					}
		}
		private bool IsNumRight(string str)
		{
			int count=0;
			for (int i = 0; i < str.Length; i++) {
				if(str[i]=='.')
					count++;
			}
			if(count>1)
				return false;
			else
				return true;
		}
	}
}
