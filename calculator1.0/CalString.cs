/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2015/5/3
 * Time: 14:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace calculator1_0
{
	/// <summary>
	/// Description of CalString.
	/// 接受输入的载体，包含内部和界面操作方法
	/// </summary>
	public class CalString
	{
		
		public CalString(string str)
		{
			
			if (str == null)
				str = "";
			this.str = str;
		}
		public CalString()
		{
		}
		
		private string str;
		//		public void  SetString(string str)
		//		{
		//			this.str=str;
		//		}
		public string GetString()
		{
			return str;
		}
		public double ToDouble(string s)
		{
			return Double.Parse(s);
		}
		/// <summary>
		/// 返回字符串
		/// </summary>
		/// <param name="start">按从1开始计数</param>
		/// <param name="end">按从0开始计数</param>
		/// <returns></returns>
		public string FromToEnd(int start, int end)
		{
			string strab = "";
			
			for (int i = start + 1; i <= end; i++) {
				strab += str[i];
				
			}
			return strab;
		}
		/// <summary>
		/// 查找字符串中的所有变量记号
		/// 但不包括这些NotInclude
		/// </summary>
		/// <returns></returns>
		public string[] FindUnKnown(string []NotInclude)
		{
			string []re=new string[20] ;
			string tpm="";
			int j=0;
			for (int i = 0; i < str.Length; i++) {
				if (tpm=="") {
					if (AcceptableBegin(str[i])) {
						
						tpm+=str[i];
					
					}else
					{
						if (tpm!="") {
							if(CheckParamerIn(re,tpm)&&!(new Calculator()).CheckFunName(tpm)&&CheckParamerIn(NotInclude,tpm))
				{
								re[j]=tpm;
					         j++;}
							tpm="";
						}
					}
				}
				else
				{
					if (AllowedInVariable(str[i])) {
						tpm+=str[i];
					}else
					{
						if (tpm!="") {
							if(CheckParamerIn(re,tpm)&&!(new Calculator()).CheckFunName(tpm)&&CheckParamerIn(NotInclude,tpm))
				{re[j]=tpm;
					j++;}
							tpm="";
						}
					}
				}
				
				
			}
			if (tpm!="") {
				if(CheckParamerIn(re,tpm)&&!(new Calculator()).CheckFunName(tpm)&&CheckParamerIn(NotInclude,tpm))
				{re[j]=tpm;
					j++;}
							tpm="";
						}
			string [] reb=new string[j];
		 
			for (int i = 0; i < j; i++) {
				reb[i]=re[i];
			}
			return reb;
			
		}
		public bool CheckFunName(string str)
		{
			return (new Calculator()).CheckFunName(str);
		}
		public string[] FindUnKnown( )
		{
			string []re=new string[20] ;
			string tpm="";
			int j=0;
			for (int i = 0; i < str.Length; i++) {
				if (tpm=="") {
					if (AcceptableBegin(str[i])) {
						
						tpm+=str[i];
					
					}else
					{
						if (tpm!="") {
							if(CheckParamerIn(re,tpm)&&!(new Calculator()).CheckFunName(tpm))
				{
								re[j]=tpm;
					         j++;}
							tpm="";
						}
					}
				}
				else
				{
					if (AllowedInVariable(str[i])) {
						tpm+=str[i];
					}else
					{
						if (tpm!="") {
				if(CheckParamerIn(re,tpm)&&!(new Calculator()).CheckFunName(tpm) )
				{re[j]=tpm;
					j++;}
							tpm="";
						}
					}
				}
				
				
			}
			if (tpm!="") {
				if(CheckParamerIn(re,tpm)&&!(new Calculator()).CheckFunName(tpm))
				{re[j]=tpm;
					j++;}
							tpm="";
						}
			string [] reb=new string[j];
		 
			for (int i = 0; i < j; i++) {
				reb[i]=re[i];
			}
			return reb;
			
		}
		/// <summary>
		/// 判断变量是否重复了
		/// </summary>
		/// <param name="strarr"></param>
		/// <param name="strtemp"></param>
		/// <returns>没重复返回真</returns>
		public bool CheckParamerIn(string [] strarr,string strtemp)
		{
			bool IsNotRepeat=true;
			foreach (var element in strarr) {
				if (element==strtemp) {
					IsNotRepeat=false;
				}
			}
			return IsNotRepeat;
		}
		public string FromToEnd(int start )
		{
			string strab = "";
			
			for (int i = start + 1; i <str.Length; i++) {
				strab += str[i];
				
			}
			return strab;
		}
		
		public string ReplaceEks(int startpos,int endpos,string inputstring)
		{
			string output="";
			output+=FromToEnd(-1,startpos);
			string temp=FromToEnd(endpos,str.Length-1);
			output+=inputstring;
			output+=temp;
			return output;
			
		}
		
		/// <summary>
		/// 替换字符串中的子字符串
		/// </summary>
		/// <param name="option">替换后的子串</param>
		/// <param name="arr">记录位置信息</param>
		/// <returns>替换之后的字符串</returns>
		/// <param name = "originallength">原来子串的长度</param>
		public string ReplaceAllEks(string option,int []arr,int originallength)
		{
			string output="";
			int j=0;
			for (int i = 0; i < str.Length; i++) {
				if (j<arr.Length&&i==arr[j]) {
					j++;
					i+=originallength-1;
					output+=option;
					
				}
				else
					output+=str[i];
				
			}
			return output;
			
		}
		public int GetLength()
		{
			return str.Length;
		}
		/// <summary>
		/// 获取输入计算式
		/// </summary>
		public void  UIGetString()//获取计算式
		{
			string stri;
			Console.WriteLine("输入计算式：\n");
			stri = Console.ReadLine();
			this.str = stri;
		}
		public void SetString(string str)
		{
			this.str=str;
		}
		public string[] GetParamersData()
		{
			string equation=this.GetString();
			int leftbraket=this.FindOp(0,'(');
//			int equalsign=this.FindOp(0,'=');
			int rightbraket=this.FindOp(leftbraket,')');

			
			string lefteq=FromToEnd(leftbraket,rightbraket);
			CalString leftfunc=new CalString();
			leftfunc.SetString(lefteq);
			int[] split = leftfunc.FindOpOutOfBrackets( ',' );
			
			split = PushToHead<int >(split, -1);
			string[] strsplit = new string[20];//保存分割后的字符串
			for (int j = 0; j < split.Length - 1; j++) {
				strsplit[j] = leftfunc.FromToEnd(split[j], split[j + 1] - 1);
			}
			
			strsplit[split.Length - 1] = leftfunc.FromToEnd(split[split.Length - 1], leftfunc.GetLength() -2);
			
			return strsplit;
		}
		public int FindOpsBasedonFindOp(int start, char[]options)
		{
			int c = 0;
			int c1 = 0;
			bool first = true;
			
			foreach (char op in options) {
				
				
				c = FindOp(start, op);
				if (c < 0) {
					continue;
				}
				if (first) {
					c1 = c;
					first = false;
				}
				if (c1 > c) {
					c1 = c;
				}
			}
			return c1;
			
		}
		
		//从0开始标记位置
		public int FindOp(int start, char option)
		{
			if (start < 0) {
				return -1;
			}
			for (int i = start; i < str.Length; i++) {
				if (str[i] == option) {
					return i;
				}
				
			}
			return -1;
		}
		
		//判断是存在
		public static bool CheckOp(char c, char[]ops)
		{
			bool result = true;
			for (int i = 0; i < ops.Length; i++) {
				if (c == ops[i]) {
					result = true;
					break;
				}
				result = false;
				
			}
			return result;
		}
		/// <summary>
		/// 找某几个字符第一次字符出现的位置
		/// </summary>
		/// <param name="start">开始位置</param>
		/// <param name="options">所找范围</param>
		/// <returns></returns>
		public int FindOps(int start, char[]options)
		{
			int result = -1;
			for (int i = start; i < str.Length; i++) {
				if (CheckOp(str[i], options)) {
					result = i;
					break;
				}
			}
			return result;
		}
		
		public int []   FindAllElements(Func<int ,char[],int >  FindOp, char[] options)
		{
			int[] brackets = new int[100];
			int j = 0;
			
			for (int i = 0; i < str.Length; i++) {
				if (FindOp(i, options) != -1) {
					i = FindOp(i, options);
					brackets[j] = i;
					j++;
				}
			}
			int[] result = new int[j];
			for (int i = 0; i < j; i++) {
				result[i] = brackets[i];
			}
			
			
			
			return result;
			
		}
		/// <summary>
		/// 查找所有元素位置并返回
		/// </summary>
		/// <param name="options">要查找的元素集合</param>
		/// <returns>返回的位置信息</returns>
		public int [] FindAllElements(char[] options)
		{
			int[] brackets = new int[100];
			int j = 0;
			
			for (int i = 0; i < str.Length; i++) {
				if (FindOps(i, options) != -1) {
					i = FindOps(i, options);
					brackets[j] = i;
					j++;
				}
			}
			int[] result = new int[j];
			for (int i = 0; i < j; i++) {
				result[i] = brackets[i];
			}
			
			return result;
		}
		/// <summary>
		/// 找指定字符串从起始位置起第一次出现的位置  必须是除数字字母单独存在
		/// </summary>yhz hz<=//shiduide aaaax aaax aaaxa
		/// <param name="start">起始位置</param>
		/// <param name="options">指定位置</param>
		/// <returns>返回第一次出现位置</returns>		
		public int FindString(int start, string options)
		{
			for (int i = start; i <= str.Length - options.Length; i++) {
				int j = 0;
				if (str[i] == options[j]) {
					for (int k = 1; k < options.Length && i+k<str.Length; k++) {
						if (str[i + k] != options[k]) {
							j = k - 1;
							break;
						}
						j = k;
					}
					
					if (j == options.Length - 1) {
						
						if (i == 0) {
							if (j+1<str.Length&&AllowedInVariable(str[j + 1])) {
								
								i = i + j ;
								continue;
							}
							return i;
							
						}
						if (i + j + 1 == str.Length) {
							if (AcceptableBegin(str[i - 1])) {
//								return i;
//								i = i + j - 1;
								continue;
							}
							return i;
						}
						if (AcceptableBegin(str[i - 1]) || AllowedInVariable(str[i + j + 1])) {
							
							
							i = i + j ;
							continue;
							
						}
						return i;
						
						
					}
//					i = i + j - 1;
					
					
					
				}
				
			}
			return -1;
			
		}
		/// <summary>
		/// 判断字符是否为字母 或者数字
		/// </summary>
		/// <param name="c">被判断字符</param>
		/// <returns></returns>
		public bool AllowedInVariable(char c)
		{
			bool result = false;
			if (c <= 'Z' && c >= 'A' || c <= 'z' && c >= 'a' || c <= '9' && c >= '0'||c=='_') {
				result = true;
			}
			return result;
		}
		public bool AcceptableBegin(char c)
		{
			bool result = false;
			if (c <= 'Z' && c >= 'A' || c <= 'z' && c >= 'a'||c=='_' ) {
				result = true;
			}
			return result;
		}
		
		/// <summary>
		/// 找出字符串中包含的字符串的所有位置 用除字母和数字分隔
		/// </summary>
		/// <param name="options">被包含的字符串</param>
		/// <returns></returns>
		public int [] FindAllString(string options)
		{
			int[] brackets = new int[100];
			int j = 0;
			
			for (int i = 0; i < str.Length; i++) {
				int re = FindString(i, options);
				if (re != -1) {
					brackets[j] = re;
					i = re + options.Length - 1;
					j++;
				}
			}
			int[] result = new int[j];
			for (int i = 0; i < j; i++) {
				result[i] = brackets[i];
			}
			
			
			
			return result;
		}
		public  T [] PushToHead<T>(T[]array, T num)
		{
			T[] returnArr = new T[array.Length + 1];
			returnArr[0] = num;
			for (int i = 0; i < array.Length; i++) {
				returnArr[i + 1] = array[i];
			}
			return returnArr;
		}
		/// <summary>
		/// 查找指定字符出现的所有位置 括号里面的除外
		/// </summary>
		/// <param name="op">所找的字符</param>
		/// <returns>位置的数组</returns>
		public int [] FindOpOutOfBrackets(char op)
		{
			int[] brackets = new int[100];
			int j = 0;
			
			for (int i = 0; i < str.Length; i++) {
				if (str[i] == '(') {
					i = FindBrackets(i + 1);
					
				} else {
					if (str[i] == ',') {
						brackets[j] = i;
						j++;
					}
				}
			}
			
			int[] result = new int[j];
			for (int i = 0; i < j; i++) {
				result[i] = brackets[i];
			}
			
			
			
			return result;
		}
		public int FindBrackets(int start)//自动找成对的
		{
			int k = 1;
			for (int i = start; i < str.Length; i++) {
				if (str[i] == '(') {
					k++;
				} else if (str[i] == ')') {
					k--;
				}
				if (k == 0) {
					k = i;
					break;
				}
				
			}
			if (k == 1) {
				k = -1;
			}
			return k;
		}
		//判断是否为单目运算符
		public	bool CheckOption(string  str)
		{
			if (str == "+" || str == "-" || str == "*" || str == "/" || str == "(" || str == ")" || str == "^" || str == "!")
				return true;
			else {
				return false;
				
			}
		}
		/// <summary>
		/// 判断数字串中的小数点是否为一个
		/// </summary>
		/// <param name="str">数字串</param>
		/// <returns></returns>
		public bool IsNumPointRight(string str)
		{
			int count = 0;
			for (int i = 0; i < str.Length; i++) {
				if (str[i] == '.' || str[i] > '9' || str[i] < '0')
					count++;
				if (i==0&&count==1) {
					return false;
				}
			}
			if (count > 1)
				return false;
			else
				return true;
		}
		public bool CheckNum(char a)
		{
			if (a <= '9' && a >= '0' || a == '.') {
				return true;
			} else
				return false;
		}
		
	}
}
