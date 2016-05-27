using System;
using System.Threading.Tasks;
using calculator1_0;

namespace MatrixProject
{
	
	/// <summary>
	/// SortBlock2的简化改进版 
	/// 能算函数 先将函数先算出来 变成没有函数的 
	/// 再除去括号变成仅含有四则运算的后置表达式 
	/// 最后用数字堆栈计算后置表达式得到结果调用Calculator函数
	/// 这个比较复杂

	/// <summary>
	/// 大概是这样  先完成
	/// </summary>
	/// </summary>
 
     public 	class SortBlockData
	{
		public static CalError error = new CalError();
		public string errorMessage="";
		private CalString strcal = null;
		private Calculator calculator = new Calculator();
		private string strNum = "";
		private string strFun = "";
		private int da = 0;
		private int strtype = 0;
		public  bool Wrong = false;
		private Data[] data = new Data [100];//存储分割后的后置表达式
		private Stack <Option > stackchop = new Stack<Option >();//保存运算符，最后由后置表达式求值的时候使用
		private Stack <CalData> stacknum = new Stack<CalData>();//保存运算数，最后由后置表达式求值的时候使用
		private static TempDataCollection tdc=null;
		
	 
		int type = 0;
		bool push = false;
		
		public static void SetTdc(TempDataCollection ptdc )
		{
			 tdc=ptdc;
		}
		public static TempDataCollection GetTdc()
		{
			return tdc;
		}
		
		private CalData CalculatorArithmetic()
		{//bugaid,只是最终完成简单的四则运算,添加双目运算符支持很简单的,基本上不用改什么
			//带参函数部分在PutFuncIntoData里面完成
			CalData sum =null;
			for (int i = 0; data[i] != null; i++) {
				
				if (data[i].GetTypeN() == 1) {
					stacknum.Push(data[i].GetCalData());
				} else {
					if (data[i].GetOption().op == '!') {
						CalData num1 = stacknum.Pop();
						int sumNumber= calculator.Factorial((int )(double .Parse(((ExpData)num1).GetValueEx())));
						sum=new ExpData(sumNumber.ToString());
					} else {
						char op= data[i].GetOption().op;
						CalData num1 = stacknum.Pop();
						CalData num2 = stacknum.Pop();
						if (num2 is ExpData && num1 is Matrix) {
							CalData temp=num2;
							num2=num1;
							num1=temp;
							if (op=='-') {
								op='+';
								num2=(num2 as Matrix)*(-1);
							}
						}
						sum = Calculator.CalSingleOperatorGeneric(num2, num1,op);
					}
					stacknum.Push(sum);
				}
			}
			CalData result = stacknum.Pop();
			 
			if (stacknum.IsNotEmpty()) {
				Wrong = true;
				stacknum.message.ErrorMessage += "Express Wrong！";
			}
			if (this.calculator.Wrong) {
				this.Wrong=true;
			}
			return result;
		}
		 
		public void  SetCalString(CalString cn)//获取计算式
		{
			strcal = cn;
		}
		public string  ShowInfo()
		{
			string er= SortBlockData.error.ErrorMessage+ stackchop.ShowErrorInfomation() + stacknum.ShowErrorInfomation();
			SortBlockData.error.ErrorMessage="";
			stackchop.message.ErrorMessage="";
			stacknum.message.ErrorMessage="";
			return er;
		}
		public bool IsError()
		{
			if ( Wrong||stacknum.IsError() || stackchop.IsError())
			
				return true;
		
				
	 
				return false;
		}
		public CalData GetCalDataFromTDC(string strName)
		{
			if (tdc.CheckName(strName)) {
					CalData datatemp = tdc.GetData(strName).GetCalData();					
					return datatemp;					 
			}
					return null;
		}
		public void PushToShow(string str)
		{
			Console.WriteLine(str);
		}
	 
		private void SortString(string str)
		{//这个是核心
			
			if (str[0] == '-') {
				data[da] = new Data();
				data[da].SetCalData(new ExpData("0"));
				da++;
			}
			for (int i = 0; i < str.Length; i++) {//开始
				type = GetType(str[i].ToString());
				if (type == 0) {//永远不可能出现
					SortBlockData.error.ErrorMessage += "包含未知字符!\n";
					errorMessage += "包含未知字符!\n";
					this.Wrong = true;
				}	
				if (strtype != type) {
					if (strNum != "") {
						PutNumToData();
					}


					if (strFun != "") {
						i = PutFuncToData(i);//返回另一个括号
						if (i == -1) {
							stackchop.message.ErrorMessage += "括号不对\n";
							Wrong = true;
							return;
						}
						type = strtype;
						continue;
					}
					
				}
					
				if (str[i] <= '9' && str[i] >= '0' || str[i] == '.') {//数字
					strNum += str[i];
					strtype = 1;
				} else {
					if (strcal.CheckOption(str[i].ToString())) {//处理单目运算符
						strtype = 3;
						if (i+1<str.Length&&str[i] == '(' && str[i + 1] == '-') {//处理负数的问题
							data[da] = new Data();
							data[da].SetCalData(new ExpData("0"));
							da++;
						}
						if (str[i] == '(' && (i>0  && (str[i - 1] <='9'&&str[i-1]>='0'))) {//处理3(x+2)的问题
							Option opti = new Option('*');
							stackchop.Push(opti);//这一句话修改之后就好了可以计算3*4e
				 
			   			 
						}
						if (i+1<str.Length&&str[i] == '+' && str[i + 1] == '-') {//处理3+x(x<0)的问题
							data[da] = new Data();
							data[da].SetCalData(new ExpData("0"));
							da++;
						}
						push = false;//还没有压入
						Option opt = new Option(str[i]);
						bool k = PutOptionToData(opt);//强制分离出来但增加了全局变量
						if (k) {
							continue;
						}
																
					}//处理运算符完毕
					else {
						strFun += str[i];
						strtype = 2;
						
//						stackchop .message .ErrorMessage +="include unkown characters\n";
//					    SortBlock2G.error.ErrorMessage+="include unkown character\n"; 
//					    errorMessage+="Include Unknown 字符";
//					    Wrong=true;//其实这句话可以不要，不要就可以 时间6+你好9=15 而不出错；
					}
				}
			}//for循环完成一次
			if (strNum != "") {
				PutNumToData();
					
			}
			if (strFun!="") {
				PutFuncToData(strcal.GetString().Length);
			}
			
			while (stackchop.IsNotEmpty()) {
				data[da] = new Data();
				data[da].SetOption(stackchop.Pop());
				da++;
			}
		}
		
		
		public CalData GetResult()
		{
			string str = strcal.GetString();
			if (str == "") {
				SortBlockData.error.ErrorMessage += "Input Is Wrong!\n";
				errorMessage+="输入错误\n";
				this.Wrong = true;
				return new ExpData("0");
			} else {
				SortString(str);
			
			
				return CalculatorArithmetic();
			}
		}
		
		private bool PutOptionToData(Option opt)
		{
			
			//压入堆栈，返回-1
			//弹出堆栈，返回1
			if (!stackchop.IsNotEmpty()) {
				stackchop.Push(opt);
				push = true;
				return true;
			}
			while (stackchop.IsNotEmpty()) {
				int rank = opt.CompareTo(stackchop.TopElement());
				if (rank == -1) {
					stackchop.Push(opt);
					push = true;
					break;
				} else if (rank == 1) {
					data[da] = new Data();
					data[da].SetOption(stackchop.Pop());
					da++;
							 
						 
				} else if (rank == 2) {
					stackchop.Pop();
					push = true;
					break;
				} else if (rank == 0)
					break;
			}
			if (!push)
				stackchop.Push(opt);
			return false;
			
		}
		private int GetType(string  t)
		{
			int k = 0;
			if (strcal.CheckNum(t[0])) {
				k = 1;
			} else {
				if (strcal.CheckOption(t)) {
					k = 3;
				} else {
					k = 2;//函数字符拼接 或者未知数
			 
				}
			}
			return k;
		}
		private int PutFuncToData(int i)
		{
			CalData cd=GetCalDataFromTDC(strFun) ;
			if (cd!=null) {
				 
				data [da] = new Data();
				data[da].SetCalData(cd);
				da++;
				
				string str=strcal.GetString();
				char str_Num_Check= str[i-strFun.Length-1];//此处还有问题
				if (strcal.CheckNum(str_Num_Check)) {//解决 t=6 2t
					data[da] = new Data();
					data[da].SetOption(new Option('*'));
					da++;
				}
				strFun = "";
				return i-1;
			}
			int k = 0;
			SortBlockData sortblock2 = new SortBlockData( ); 
			FuncName fn = new FuncName();
			fn.SetFuncName(strFun);
			strFun = "";
			if ((new Calculator()).CheckFunName(fn.GetFuncName())) {
				k = strcal.FindBrackets(i + 1);//只是简单的换个函数就可以实现多重嵌套函数了
				if (k == -1) {
					SortBlockData.error.ErrorMessage += "括号不成对\n";
					errorMessage+="括号不成对\n";
					this.Wrong = true;
					return -1;
				 	
				}
				string stri = strcal.FromToEnd(i, k - 1);
				 
				//此处应该提取一个专门把函数里面的参数弄出来的类或方法
				CalString str = new CalString(stri);
//				int[] split = str.FindAllElements(new char[]{ ',' });
				int[] split = str.FindOpOutOfBrackets( ',' );
				 
				split = str.PushToHead<int >(split, -1);
				string[] strsplit = new string[20];//保存分割后的字符串
				for (int j = 0; j < split.Length - 1; j++) {
					strsplit[j] = str.FromToEnd(split[j], split[j + 1] - 1);
				}
				 	
				int count = 0;
				strsplit[split.Length - 1] = str.FromToEnd(split[split.Length - 1], str.GetLength() - 1);
				
				
				
				CalData[] res = new CalData[split.Length];//保存结果
				foreach (var element in strsplit) {
//					Console.WriteLine(element);
					if (element == null)
						break;
					CalString strpart = new CalString(element);
					SortBlockData sortblock = new SortBlockData();
					sortblock.SetCalString(strpart);
					res[count] = sortblock.GetResult();
					if (sortblock.Wrong) {
						sortblock2.Wrong=true;
						sortblock2.errorMessage+=sortblock.errorMessage;
					}
					count++;
				}
				CalData resu =null;
				resu = Calculator.CalFunc(fn.GetFuncName(), res);
				if (sortblock2.Wrong||sortblock2.calculator.Wrong) {
					this.Wrong=true;
					errorMessage+=sortblock2.errorMessage;
				}
				data [da] = new Data();
				data[da].SetCalData(resu);
				da++;
			} else {
				stackchop.message.ErrorMessage += "include unkown characters\n";
				SortBlockData.error.ErrorMessage+=fn.GetFuncName().Length>1?"Include UnKnown 字符串":"Include UnKnown 字符";
				throw new SortBlockException(fn.GetFuncName().Length>1?"Include UnKnown 字符串":"Include UnKnown 字符"+fn.GetFuncName()+"  还未定义");
				errorMessage+=fn.GetFuncName().Length>1?"Include UnKnown 字符串\n":"Include UnKnown 字符\n";
				Wrong = true;//其实这句话可以不要，不要就可以 时间6+你好9=15 而不出错；
				return i;
			}
			return k;
 
		}
		private void PutNumToData()
		{
			if (strcal.IsNumPointRight(strNum)) {
				double numer = Double.Parse(strNum);
				strNum = "";
				data[da] = new Data();
				data[da].SetCalData(new ExpData(numer.ToString()));
				da++;
			} else {
				Wrong = true;
				stacknum.message.ErrorMessage += "小数点错了";
				data[da] = new Data();
				data[da].SetCalData(new ExpData("0"));
				da++;
			}
		}
		 
	}
   public  class SortBlockException:Exception
     {
     	public SortBlockException (string str):base(str)
     	{
     		
     	}
     }
}
