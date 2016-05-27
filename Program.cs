 
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace calculator1_0
{
	class Program
	{
		public static void Main0(string[] args)
		{
			 
//			Calculte cal=new Calculte ();
//			string str=cal.GetString ();
//			string strcal=cal .BackSort (str);
//			double result=cal .Calculator (strcal );
			
//------------------------------------------------------------------------------
		
//----------------------主程序---------------------------------------------------
			char op = '0';
			while (op != 'q') {
				CalString cal = new CalString("");
				cal.UIGetString();



				SortBlock2 sort = new SortBlock2();
				sort.GetCalString(cal);

				double result = sort.GetResult();
				if (sort.IsError()) {
					Console.WriteLine(sort.ShowInfo());
				}
				Console.Write(cal.GetString() + "=" + result.ToString() + '\n' + "按q退出,其他键继续" + '\n');
				SortBlock2.Wrong=false;
				SortBlock2.error.ErrorMessage="";
				op = Console.ReadKey().KeyChar;
			}

//----------------------------------------------------------------------------------------------
//          cos(sin(20+30-20)*20+50)*4/2^2+1/2+cos(sin(20+30-20)*20+50)*4/2^2+1/2
//          pow(sin(30)*4,2)
//          SortBlock2 Release模式下用时32
//			int i=cal.FindOp(0,'(');
//			int k=cal.FindBrackets(i);
//			string str=cal.FromToEnd(i,k);
//			Console.WriteLine(str);
			
//			其实C#自带的就已经很屌了 Console.WriteLine(3+30*3*(3-4));
			/**
			 * 测试找括号
			 */
//			char []opts={'(',')' };
//			string str="(1+2)+1*(2+3)";
//			CalString scal=new CalString(str);
//			int [] ars=scal.FindAllElements(scal.FindOps,opts);
//			foreach (int element in ars) {
//				Console.WriteLine(element);
//			}
			/*
			 * 测试逗号查找
			 */
//		    char []opts={','};
//			string str="pow(1,1,2,3)";
//			CalString scal=new CalString(str);
//			int [] ars=scal.FindAllElements(opts);
//			foreach (int element in ars) {
//				Console.WriteLine(element);
//			}
			
//			Console.WriteLine(Math.Log(Math.E));
			/*
			 * 测试FuncName的FindFunName方法
			 */
//			Console.WriteLine(FuncName.FindName("cos"));
//				Console.WriteLine(FuncName.CheckFun("cos",1));
			//测试FindOp
//			int c=scal.FindOp(0,opts);
//			Console.WriteLine(c);
//			测试时间
			//不改730多
			//加一个方法 改成NoGetResult 740多
			//用Paraller 1300多
			//Paraller 干for循环只要410多
//				char op = '0';
//			while (op != 'q') {
//				CalString cal = new CalString("");
//				cal.UIGetString();
//			    Stopwatch sw=new Stopwatch();
//			    sw.Start();
//				
//			   
//				double result=0;
////				for(int i=0;i<10000;i++)
////				{
////					  sort = new SortBlock2();
////				    sort.GetCalString(cal);
////				    
////					result = sort.NoGetResult();
////				}
////				
//				Parallel.For( 0,10000,(i)=>
//				{
//				    SortBlock2 sort= new SortBlock2();
//				    sort.GetCalString(cal);
//				    
//					result = sort.NoGetResult();
//				             });
////				if (sort.IsError()) {
////					Console.WriteLine(sort.ShowInfo());
////				}
//				Console.Write(cal.GetString() + "=" + result.ToString() + '\n' + "按q退出,其他键继续" + '\n');
//				sw.Stop();
//				long time=sw.ElapsedMilliseconds;
//				Console.WriteLine(time);
//				op = Console.ReadKey().KeyChar;
//			}
//		
//			
//			
//			
//			
			
			
			
			
			
			
			
			
			
			Console.ReadKey();
 

			
		}
	}
}

//Log :
//	0.1版本
//	首先用一个堆栈实现了对数字的计算，即后置表达式求值
//	用C写的，通过if-else实现运算符的控制
//	后续改进目标：
//	          添加括号支持
//	-----------------------------------------------------
//	1.0版本
//	实现了0.1的功能基础上，添加对括号的支持
//	用C#写的，通过泛型堆栈Stack，数字堆栈和运算符堆栈，实现对字符串的排列
//	添加Option类保存运算符，并实现IComparable接口，规定了优先级（出栈规则）
//	添加CalError类保存出错信息，
//	Calculte类完成字符串转换为后置表达式及求值的任务，今天早上2015/04/04简化了BackSort方法中的复杂逻辑
//	后续改进目标：
//	          添加十位数及以上及double类型的支持->改进BackSort中对数值和运算符的划分规定
//	          添加函数支持->改进Calculator中运算处理，及Option.Compare中对括号的处理
//	-----------------------------------------------------
//  1.2版本  2015/5/1
//  实现1.0要求，添加小数点，添加多位数支持，添加负号支持，支持开头就是负号 -2*3=-6
//  新建了一个SortBlock类完成计算工作，替代了Calculate
//  主要表现为用Data类的数组将所有的数值和运算符进行了统一包容，用TypeN区分
//	BackSort（亦即SortBlock中的SortString）大体复杂的运算符进出栈仍未改动，只是用Double.Parse()将连续的数字变成多位数
//	对出错信息进行了简单封装ShowInfo
//	计算过程完全封装到内部
//	对Option类的rank小幅简化
//  开头是括号或者多重括号也是可以的（好像本来就可以）。。
//  总感觉Option类有问题，太冗余，逻辑不清晰，好像没考虑完全似得，但是别人就是没问题，完全不用修改，改了几次也没出逻辑问题。。
//	后续改进目标：
//	       添加函数支持->改进Calculator中运算处理，及Option.Compare中对括号的处理，递归解决？一块块拼接试试
//	       加强异常处理：对多个小数点等问题(小数点解决了,会自己报错了Orz)
//         将运算部分从SortBlock中分离出来
//  ------------------------------------------------------------------------------

//1.2.1版本 2015/05/09
//  实现1.2.0要求 添加了几个简单函数的支持
//	对SortString继续改进 增加几个判断
//	将获取string的UI放置在CalString中，然后对象注入到SortBlock中
//	在Func类中添加一个Calculator对象，添加计算支持
//	CalString类 添加 FromToEnd 截取字符串 和 FindOp 查找指定字符
//  完善一点三角计算
//后期改进：
//   继续尝试分离SortString中的PutOptionToData 最好还是把它分离出来 毕竟（多压入了一次
//   继续优化SortString
//   添加SortBlock自引用
//   添加函数多重嵌套支持
//   比如说Data 用dynamic属性的元素
//   添加常量pi试试，添加指数类等，还有^ %等一些东西 试试     0.。9   insin(3)baocuo
//   计算sin(sin(30)*20+10*cos(60)*4) chucuo

//-----------------------------------------------------------------------------
//1.2.3版本 2015/06/06
//	实现1.2.1要求 分离出了PutOptionToData 添加了^符号的支持
//	多重嵌套及自引用在1.2.2中已经完成了
//	简化了SortBlock2的SortString函数 在SortBlock2中新写了一个GetType
//	对整体计算会出问题的算式进行了修正
//后期改进：
//    继续优化吧，下个星期再看	1.2.3（GetType）好厉害！去掉了之前好多意义不明但不能删的东西
//    添加双参数支持，比如sum(a,b)之类的
//    把后置排序和计算分离
//    嵌套计算用多线程试试
//-----------------------------------------------------------------------------------
//1.2.5版本 2015/8/18
//	实现1.2.3要求添加双参数，多参数支持sum, avg log 等 还加了一个阶乘 没怎么测试
//	主要完成了对FuncName的改进过程，静态化了参数，添加一些方法 移除一些不要的参数
//	PutFuncToData函数弄得很复杂 加入了一些错误提示
//	并对Calculator类进行了相应的调整
//后期改进：
//	继续优化PutFuncToData FuncName中的成员变量改成Stack静态堆栈
//	添加多线程




//-----------------------------------------------------------------------------------
//2015/6/20 将StringCal 改名为CalString 并添加了查找指定字符数组的方法FindAllElements ,并尝试使用了
//委托实现方法注入
	
//目标:实现基本运算 <完成>
//	实现括号运算  <完成>
//	实现多位数运算<完成>
//	实现小数点<完成>
//	实现函数
//  听了一下金旭亮的貌似还有10..03 -3这种东西没有处理
//  之前不仅可以用堆栈还可以用树的厉遍方式，之前我也曾思考过但是不知如何实现，接受堆栈的方式之后就没再考虑了
//  基本思想是依据运算符优先级 和 括号规定 得到不同要求下的后置表达式，然后计算e.g. 1+2*3 1*(2+3)
//  x.8之前完成计算  (包括符号运算和多参数函数，自定义函数，动态提示等)
//  x.5版本开始添加矩阵
//  2.0版本开始实现界面
//  2.3版本实现绘图
//  3.0版本实现三维
//  5.0版本开始实现编程计算
//
//

	