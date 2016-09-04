 using System ;
namespace calculator1_0
{
	/// <summary>
	/// Description of Calculte.
	/// 能算括号
	/// 
	/// </summary>
	public class Calculte//完成字符串的处理(得到后置表达式)并且计算返回计算结果
	{
		public Calculte()
		{
			stacknum .SetBottom (0);
//			stacknum .Pu
			
			
//			sh (0);
			stackchop .SetBottom (new Option('#'));
		}
		public string  GetString()//获取计算式
		{
			string str;
			Console .WriteLine ("输入计算式：\n");
			str=Console .ReadLine ();
			return str;
		}
		private Stack <Option > stackchop=new Stack<Option > ();//保存运算符
		private Stack <double> stacknum=new Stack<double>() ;//保存运算数
		public string BackSort(string str)//转化为后置表达式
		{
			string backsort="";
		
			 
			for (int i = 0; i <str .Length ; i++) 
			{
				if(str [i]<'9'&&str [i]>'0')
				{
					backsort +=str [i];
				}
				else
				{
					if(CheckOption (str [i])){
					//压入堆栈，返回-1
			        //弹出堆栈，返回1
						bool push=false ;//还没有压入
						Option opt=new Option (str [i]);
						while (stackchop .IsNotEmpty ())
						{
							int rank=opt.CompareTo (stackchop .TopElement ());
							if(rank ==-1){
								stackchop .Push (opt );
								push =true ;break ;
							}
							else if (rank ==1) {
								backsort +=stackchop .Pop ().op ;
							}
							else if (rank ==2) {
								stackchop .Pop () ;
								push =true ;break ;
							}
							else if(rank ==0) break ;
						}
						if(!push )
							stackchop .Push (opt );
																
					}
					else stackchop .message .ErrorMessage +="include unkown characters";
					}
				
				
			}
			while (stackchop .IsNotEmpty ())
			{
				backsort +=stackchop .Pop ().op ;
			}
			return backsort ;

		}
		bool CheckOption(char  str)
		{
			if(str=='+'||str =='-'||str=='*'||str=='/'||str=='('||str==')')
				return true ;
			else
			{
				return false ;
			
			}
		}
		public double Calculator(string str)
		{
			double sum=0;
			for (int i = 0; i <str.Length ; i++) {
				if (str[i]<='9'&&str[i] >'0') {
					stacknum .Push (str [i]-'0');
				}
				else
				{
					double num1=stacknum .Pop ();
					double num2=stacknum .Pop ();
					sum =SampleCal(num2,num1 ,str [i]);
//					stacknum .Push (sum );
					
				}
					
			}
			double result=stacknum .Pop ();
			stacknum .Pop ();
			if (stacknum .IsNotEmpty ()) {
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
				default:return 0;
			}
		}
		public string ErrorMessage() 
		{
			string str="";
			str +=stacknum .message.ErrorMessage  ;
			str +=stackchop .message.ErrorMessage  ;
			return str ;
		}
		
	}

	
}
