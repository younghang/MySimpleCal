using System;
using System.Threading.Tasks;

namespace calculator1_0
{
	
/// <summary>
/// 能算函数 先将函数先算出来 变成没有函数的 
/// 再除去括号变成仅含有四则运算的后置表达式 
/// 最后用数字堆栈计算后置表达式得到结果调用Calculator函数
/// 这个比较复杂

/// <summary>
/// 大概是这样  先完成
/// </summary>
/// </summary>
 
	class SortBlock2
	{
		public static CalError error=new CalError();
		private CalString strcal=null;
		private Calculator calculator=new Calculator();
		private string strNum="";
		private string strFun="";
		private int da=0;
		private int strtype=0;
		public static bool Wrong=false;
		private Data[] data=new Data [100];
		private Stack <Option > stackchop=new Stack<Option > ();//保存运算符
		private Stack <double> stacknum=new Stack<double>() ;//保存运算数
 
		private double result=0;
		int type=0;
//		int change=0;
//		bool first=true;
		bool push=false ;
		
		
	    private double Calculator()
		{//bugaid,只是最终完成简单的四则运算,添加双目运算符支持很简单的,基本上不用改什么
			double sum=0;
			for (int i = 0;data[i]!=null ; i++) {
				
				if (data[i].GetTypeN()==1) {
					stacknum .Push (data[i].GetNum());
				}
				else
				{
					if (data[i].GetOption().op=='!') {
						double num1=stacknum.Pop();
						sum=calculator.Factorial(num1);
					}
					else{
					double num1=stacknum .Pop ();
					double num2=stacknum .Pop ();
					sum =calculator.CalSingleOperator(num2,num1 ,data[i].GetOption().op);}
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
		 
		public void  GetCalString(CalString cn)//获取计算式
		{
			 
			 strcal=cn;
			
		}
		public string  ShowInfo()
		{
			return stackchop.ShowErrorInfomation()+stacknum.ShowErrorInfomation()+SortBlock2.error.ErrorMessage;
		}
		public bool IsError()
		{
			if(stacknum.IsError()||stackchop.IsError()||Wrong)
				return true;
			else return false;
		}
		#region "已废弃"
		private void SortStringFormer(string str)
		{//这个是核心呐
			
			
			Option opti=new Option('#');
			stackchop.SetBottom(opti);
			int change=0;
			bool first=true;
				
             //pow(1,2)   
			for (int i = 0; i < str.Length; i++) {//开始
					
					if (strtype != change)
                {
                    if (strNum != "")
                    {
                        PutNumToData();
                    }


                    if (strFun != "")
                    {
                        i=PutFuncToData(i);//返回另一个括号
						if (i==-1) {
							stackchop .message .ErrorMessage +="括号不对\n";
						    Wrong=true;
						    return;
	                    }
                    change = strtype;
                    continue;
                    }
					
					}
					
				if (str[i]<='9'&&str[i]>='0'||str[i]=='.') {//数字
					strNum+=str[i];
					strtype=1;
				}
				else {
					if (strNum!="") {
						
				    PutNumToData();//这一段要不要去掉
				    
					}
					
						if (strcal.CheckOption(str[i].ToString())) {
					strtype=3;
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
							first=true;//为了能嵌套 这个地方加了个东西，不知道会不会引入其他问题
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
					else {
						strFun+=str[i];
						strtype=2;
//						stackchop .message .ErrorMessage +="include unkown characters\n";
//					      Wrong=true;//其实这句话可以不要，不要就可以 时间6+你好9=15 而不出错；
					}
				}
		 
				 if(first)
                {
                	change=strtype;
                	first=false;
                }
			
			}//for循环一次
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
		#endregion
		private void SortString(string str)
		{//这个是核心呐
			
//			貌似没用到的样子
//			Option opti=new Option('#');
//			stackchop.SetBottom(opti);
				
                //sin(1*(10+20))
                if(str[0]=='-')
                {
                	data[da]=new Data();
						data[da].SetNum(0);
					 	da++;
                }
			for (int i = 0; i < str.Length; i++) {//开始
				type=GetType(str[i].ToString());
				if (type==0) {
					SortBlock2.error.ErrorMessage+="包含未知字符!\n";SortBlock2.Wrong=true;
				}	
					if (strtype != type )
                {
                    if (strNum != "")
                    {
                        PutNumToData();
                    }


                    if (strFun != "")
                    {
                        i=PutFuncToData(i);//返回另一个括号
						if (i==-1) {
							stackchop .message .ErrorMessage +="括号不对\n";
						    Wrong=true;
						    return;
	                    }
                    type= strtype;
                    continue;
                    }
					
				}
					
				if (str[i]<='9'&&str[i]>='0'||str[i]=='.') {//数字
					strNum+=str[i];
					strtype=1;
				}
				else {
//					if (strNum!="") {
//						
//				    PutNumToData();//这一段要不要去掉，不能 比如 1*1+2*(1+1)
//				    
//					}
						//后来1.2.3就确定它确实没什么用可以去掉
					
						if (strcal.CheckOption(str[i].ToString())) {//处理单目运算符
					    strtype=3;
						if (str[i]=='('&&str[i+1]=='-') {//处理负数的问题
						data[da]=new Data();
						data[da].SetNum(0);
					 	da++;
						}
					    push=false ;//还没有压入
						Option opt=new Option (str[i]);
					    bool k=PutOptionToData(opt);//强制分离出来但增加了全局变量
					    if (k) {
					    	continue;
					    }
					
					
						
																
					}//处理运算符完毕
					else {
						strFun+=str[i];
						strtype=2;
//						stackchop .message .ErrorMessage +="include unkown characters\n";
//					      Wrong=true;//其实这句话可以不要，不要就可以 时间6+你好9=15 而不出错；
					}
				}
		 
//				 if(first)
//                {
//                	change=strtype;
//                	first=false;
//                }
			
			}//for循环完成一次
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
		
		
		#region 加上一个workoutResult之后一个算式由32ms变成55ms,加Paralle直接变200多ms
		public double NoGetResult()
		{
//			Parallel.Invoke(this.WorkOutResult);
			WorkOutResult();
			return  result;
		}
		public void WorkOutResult()
		{
			string str=strcal.GetString();
			SortString(str);
			result=Calculator();
		}
		#endregion
		
		public double GetResult()
		{
			string str=strcal.GetString();
			if (str=="") {
				SortBlock2.error.ErrorMessage+="Input Is Wrong!\n";SortBlock2.Wrong=true;
				return 0;
			}
			else
			{
			SortString(str);
			
			
			return Calculator();}
		}
		
		private bool PutOptionToData(Option opt)
		{
			
						//压入堆栈，返回-1
						//弹出堆栈，返回1
						if (!stackchop .IsNotEmpty ()) {
							stackchop .Push (opt );
							push=true;
//							first=true;//为了能嵌套 这个地方加了个东西，不知道会不会引入其他问题
							//后来1.2.3就确定它确实没什么用可以去掉
							return true;
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
						return false;
			
		}
		private int GetType(string  t)
		{
			int k=0;
			if (strcal.CheckNum(t[0])) {
				k=1;
			}
			else
			{
				if (strcal.CheckOption(t)) {
					k=3;
				}
				else
				{
					k=2;//函数字符拼接
			 
				}
			}
			return k;
		}
		private int PutFuncToData(int i)
		{
            //stackchop.Pop();//在这里Pop一下就好了。。尽量不要这样
			//1.2.3修改一下就已经不用了，哈哈
			int k=0;
			SortBlock2 sortblock2=new SortBlock2(); 
			FuncName fn=new FuncName();
			fn.SetFuncName(strFun);
			strFun="";
			if((new Calculator()).CheckFunName(fn.GetFuncName()))
			{
//				 k=strcal.FindOp(i,')');
				k=strcal.FindBrackets(i+1);//只是简单的换个函数就可以实现多重嵌套函数了
//				Console.WriteLine("i={0}   k={1}",i,k);
				 if (k==-1) {
					SortBlock2.error.ErrorMessage+="括号不成对\n";SortBlock2.Wrong=true;
				 	return -1;
				 	
				 }
				 string stri=strcal.FromToEnd(i,k-1);
				 
				 CalString str=new CalString(stri);
				 int[] split=str.FindAllElements(new char[]{','});
				 
//				 if (split.Length!=0) {
				 	split=str.PushToHead<int >(split,-1);
				 	string []strsplit=new string[20];//保存分割后的字符串
				 	 for (int j = 0; j < split.Length-1; j++) {
				 		strsplit[j]=str.FromToEnd(split[j],split[j+1]-1);
				 	 }
				 	
				 	int count=0;
				 	strsplit[split.Length-1]=str.FromToEnd(split[split.Length-1],str.GetLength()-1);
				 	double []res=new double[split.Length];//保存结果
				 	foreach (var element in strsplit) {
				 		if (element==null) break;
				 		CalString strpart=new CalString(element);
				 		SortBlock2 sortblock=new SortBlock2();
				 	    sortblock.GetCalString(strpart);
				 	    res[count]=sortblock.GetResult();
//				 	    FuncName.InnerSetString();
				 	    count++;
				 		
				 		
				      
				 	}
                    double resu = 0;
                    resu= sortblock2.calculator.CalFunc(fn.GetFuncName(),res);
                   
                
				 	
				 	
				 	//pow(1+2*3+4,5-5+6,8,96,9-5,55)
//				 	string str1=str.FromToEnd(-1,split-1);
//				 	string str2=str.FromToEnd(split,str.GetLength()-1);
//				 	Console.WriteLine(str1+"      "+str2);
				 
//				 }//if 逗号存在 结束
				 
				
//				 sortblock2.GetCalString(str);
//				 double re=sortblock2.GetResult();
//				 
//				 
//				 re=sortblock2.calculator.CalFunc(FuncName.GetFunc(),re);
                 //PutNumToData();
				 data[da]=new Data();
					data[da].SetNum(resu);
					 da++;
					
			}
			else {
				stackchop .message .ErrorMessage +="include unkown characters\n";
			    Wrong=true;//其实这句话可以不要，不要就可以 时间6+你好9=15 而不出错；
			    return i;
			}
			 return k;
			
		}
		private void PutNumToData( )
		{
			if(strcal.IsNumPointRight(strNum)){
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
		 
	}
}
