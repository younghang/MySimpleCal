 
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace calculator1_0
{
	class Program
	{
		public static void Main(string[] args)
		{
			 
//			Calculte cal=new Calculte ();
//			string str=cal.GetString ();
//			string strcal=cal .BackSort (str);
//			double result=cal .Calculator (strcal );
			
//------------------------------------------------------------------------------
		
//----------------------主程序---------------------------------------------------
//			char op = '0';
//			while (op != 'q') {
//				CalString cal = new CalString("");
//				cal.UIGetString();
//
//
//
//				SortBlock2G sort = new SortBlock2G();
//				sort.GetCalString(cal);
//
//				double result = sort.GetResult();
//				if (sort.IsError()) {
//					Console.WriteLine(sort.ShowInfo());
//				}
//				Console.Write(cal.GetString() + "=" + result.ToString() + '\n' + "按q退出,其他键继续" + '\n');
//				
//				SortBlock2G.error.ErrorMessage="";
//				op = Console.ReadKey().KeyChar;
//			}

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
//				for(int i=0;i<10000;i++)
//				{
//					  sort = new SortBlock2();
//				    sort.GetCalString(cal);
//				    
//					result = sort.NoGetResult();
//				}
//				
//				Parallel.For( 0,10000,(i)=>
//				{
//				    SortBlock2 sort= new SortBlock2();
//				    sort.GetCalString(cal);
//				    
//					result = sort.NoGetResult();
//				             });
//				if (sort.IsError()) {
//					Console.WriteLine(sort.ShowInfo());
//				}
//				Console.Write(cal.GetString() + "=" + result.ToString() + '\n' + "按q退出,其他键继续" + '\n');
//				sw.Stop();
//				long time=sw.ElapsedMilliseconds;
//				Console.WriteLine(time);
//				op = Console.ReadKey().KeyChar;
//			}
//		

//			测试查找字符串 《测试通过》
while (true) {
	
			CalString cs=new CalString();
			cs.UIGetString();
			string st=Console.ReadLine();
			Console.WriteLine(cs.FindString(0,st));
				
//			cs.SetString("fx(1,2)");			 
//			int []result=cs.FindAllString("caos");
//			foreach (var element in result) {
//				Console.WriteLine(element);
			}
//			cs.UIGetString();
			
			
//			cs.SetString(cs.ReplaceAllEks("000",result,4));
//			Console.WriteLine(cs.GetString());
//			string []strr=cs.GetParamersData();
			
//			string []strr=cs.FindUnKnown();
//			foreach (var element in strr) {
//				Console.WriteLine(element);
//			}
			
			

//}

			
			
			
			
			
			
			
			
			
			
			
			
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
//2015/6/20 将StringCal 改名为CalString 并添加了查找指定字符数组的方法FindAllElements ,并尝试使用了
//委托实现方法注入
//------------------------------------------------------------
//1.2.5版本 2015/8/18
//	实现1.2.3要求添加双参数，多参数支持sum, avg log 等 还加了一个阶乘 没怎么测试
//	主要完成了对FuncName的改进过程，静态化了参数，添加一些方法 移除一些不要的参数
//	PutFuncToData函数弄得很复杂 加入了一些错误提示
//	并对Calculator类进行了相应的调整
//后期改进：
//	继续优化PutFuncToData FuncName中的成员变量改成Stack静态堆栈
//	添加多线程

//1.2.5.1版本 2015/09/27
//解决一部分错误显示问题 用了一个多小时 （行号287 忘记加提示，145 陈旧错误判定忘记删除导致错误提示一直在）
//发现新bug 就是算 pow(2,pow(2,1)) 的时候会出错 仅用‘,’对于函数参数范围的判定是错误的
//又手贱搞了半个小时解决了 新添加呢一个 FindOpOutOfBrackets
//1.2.5.2版本 2015/10/06
//给CalString添加了两个函数实现了查找指定字符串位置的功能弄了两三个小时 脑子越来越不好使了
//1.2.5.3 2015/10/11 
//搞了十几分钟完成了之前弄得ReplaceEks 函数 还算比较好使 比之前的个方法重新写了一下简洁有效多了 果然脑子清醒做事才好
//又搞了50分钟 新建了一个FuncStiring类 解决了解析函数表达式的问题 可以实现f(x,y)=skjhf => f ; x y ; skjhf;
//1.2.5.9 2015/10/11
//解决了将参数替换为数值的问题FuncString类中的ReplacedFuncExpress函数
//新建了Function 类 封装了FuncString并包含了MyCallDll中的计算部分 完成了计算任务
//基本上解决了 fun(x,y)=sin(x)+y 这样的计算问题 就是如何输入数值还没弄好
//下午弄了一个坐标轴 呵呵
//1.2.5.9.3 2015/10/17
//添加了一个UIController项目专门负责交互 function专门负责提供函数的功能
//改了一些名字做了一点规划
//1.2.6.0 2015/10/24
//对UIController进行了一定程度的编写 主要完成了存数的任务 解析还没弄
//-----------------------------------------------------------------------------------
//1.2.6.1 2015/10/31
//今天下午作死 还敢搞几个小时 真心醉了 考研是不允许失败的 你知道吗！！！！！
//对UIController类进行了大面积的修改调试  TempDataCollection类添加了一些功能
//实现了 对纯数值计算的接入
//输入值的记录
//完成了类似 f(x,y)=x+y^2 能够求f(1,2)的功能
//-------------------------------------
//1.2.6.1.1 2015/11/21
//今天继续作死 搞了一个小函数FindUnKnown 和附加的CheckParamerIn 希望完成 x+t的计算  话说啊 如果你不努力这个世界废人太多 垃圾更多 不想和垃圾生活在一起 或者不想像垃圾一样生活 你就必须好好努力这一点时可以肯定的  很多人不会在乎你什么感受 他们就是垃圾 渣滓社会毒瘤而已 真正关心你的只有你的父母家人而已 我希望你能够对得起他们 即使说不为自己什么的也要为家人而努力  更努力 让那些瞧不起你的人看看 老子根本不屑与你在一个地方 人要有志气
//x=1 y=2 x+y 完成了 还有救赎上面那个报错竟然还没解决
//-----------------------------------------------------------
//1.2.6.1.2 2015/11/23
//修复若干问题 
//改进目标：
//在存值的时候尤其是f()=sdf  f(x,y)=x+t 这种得多多判断改进 还有出错信息的管理问题需要改进 还有程序结构优化UIController
//1.2.6.1.3 2016/01/03
//改进了UIControl的 部分错误 比较麻烦 cos(x)中的cos不会被当做未知数
//添加Chart控件来画函数图形 有个小问题 科学计数法会导致出错2.3E-13这种不会被解析的  这样((decimal)temp).toString();就好了
//发现x+x当x为负数时会出错 自动添加一个0 顺便2(x+3) 自动添加*
//1.2.6.1.5 2016/01/04
//基本绘图实现了 但还存在许多问题 像是 x*cos(x)+x->(x)*cos(x)+(x) 的预处理 y=x+2->y(x)=x+2
//还有各种错误提示问题，单纯依靠FuncString 解决输入问题不妥 各种输入情况的处理存值没解决好
//Chart控件的使用没有完成 ，画图变量区间的问题，还有矩阵没添加
//UIController过于繁杂没处理好
//---------------------------------------------------------------
//1.2.6.2 2016/01/07
//感觉脑子越来越差了，注释越写越多，以前都不写注释的更不谈提示了，现在老了得一个一个添加 不然真心看不懂
//写逻辑处理的时候最好在脑子清醒的时候不然很乱 头疼
//1.2.6.2.1 2016/01/07
//还好啦，接着凌晨2点的写 现在是9点 基本上改写的都写的差不多了
//UIController 里面的AnalyseInputG彻底重写了一遍之前脑袋不清晰写得不好
//还有添加了ReplaceParamer这个函数总算是把思路理清楚了 
//最后还添加了FindFuncInTDC这个函数方便查函数
//还有这个GetFuncResult也是之前一起弄的改进版
//总之主要是处理一些结构化程序处理的问题，感觉面向对象思想越来越少了，还不如之前的Calculator里面的类写得好
// t=3  f(x,y)=x+y+t  (x,y)=x+y都是是可以的
//接下来就是处理1.2.6.1.5中提到的问题了
//ReplaceFuncExpressTemp里面加了个括号2333 就可以直接3x了 还不行QAQ 下次再试试

//1.2.6.2.2 2016/01/10
//3x可以啦 错误处理及前处理还没弄好 还有修改了FindString这个函数为了出来3x 不知道有没有什么问题还没测试
//x*cos(0.3x) 竟然算不出来，下次弄弄吧 还有用Parallel绘图点数改为300就报错了 绘制两次也会报错
//3e 没问题可以算 2*3e就会报错 下次再看吧
//接下来：
//	  完善底层计算或者加新东西 区间 行列式 矩阵 
//    添加三维绘图 完善二维绘图并添加细节 掌握Chart控件
//    区间与函数结合
//    绘图窗口设计wpf
//    UIController大刀阔斧改
//    整个窗口处理流程还得改，存值校验也得有
//    解方程 求导之类的看有没有机会吧，估计要更深层次的数学知识，数值计算方法之类的
//--------------------------------------------------------------------------------------------------------------
 
//1.2.6.3  2016/01/15
//		基本上解决了FindString（有错）的错误问题，还有对于数据存储引入了继承CalData类，只是存储数据不包括名字 x=1+2也是可以得
//		总体来说比较好，其他类基本没做什么变动，就能正常编译通过
//      添加了SortBlockG（没错）的一个能力可以计算3*4e了
//接下来：
//		可以考虑加区间 加矩阵 完善绘图了 t=x ， f(x)+8等都可以试试

//1.2.6.3.1 2016/01/30
//		做了些小完善工作
//		为CalData添加了数据类型的枚举，方便判断存入的数据的类型
//		UIControllerl的CheckDataType，解决单输入的问题，比如>>f(x)=x ,>>f   >>x=3 >>x
//		将SimpleCal转为UIControllerl的静态方法，tdc转为静态成员，方便外部类(ExpData)进行调用求含参数的表达式的值
//		解决t=3x之类的赋值问题，防止x=2x循环调用SimpleCal--> ReplaceParamers--> GetValueEx-->SimpleCal
//			为防止循环调用：例如x=1 x=2x 因x=2x将覆盖x=1 因此只有x=2x 所以求x-->2x 2x-->x 无穷尽也 
//			可以考虑将结果2x先算出来，再存x进去  或者  保留x=1不覆盖  即更改TempDataCollection的存数机制
//			姑且采用第一种，在存数之前先调用了GetValueEx()
//			又饶了一个钟头 加了GetValueFinal t=x+4  实时更新x, t也能跟着更新了,原有功能已经恢复了
//接下来：
//		sin=x 之类的问题 底层Cal的错误提示还有好多问题  可以考虑加区间 加矩阵 完善绘图了
//1.2.6.3.2 2016/01/31
//		解决sin=4的问题 写了些帮助信息help命令
//			if(funstring.FindUnKnown().Length==0)//FindUnKnown还是会出差比如sin=a就会覆盖掉sin 已经改为直接检查函数名
//			{
//				PushToShow("Variable Name not acceptable!");
//				continue;
//			}
//
//
//1.2.6.3.3 2016/02/04
//		解决pi=2的问题 写了些帮助信息help(list)命令 可以list(exp|func|block) CalData的TOString写好了
//		解决两个隐藏会导致FC 的BUG e. 和f(1++) 其他有待观察
//	话说发现一个神奇的现象 有时候输入e 会提示没定义！！！clc()就恢复了 有时候有很正常 O GA XI
//		话说是时候添加新功能了。一直维护算什么？

//1.2.6.5 2016/4/25
//	新建Matrix矩阵类
//	将BlockData 和 Matrix 添加到保存名单 使用DealAssignment 解决输入问题
//	添加一个MatrixTest类 单元测试 测试Matrix中的方法
//	Plot 能够接收区间Block对象作为参数画图，或者自定义两端点。
	
//1.2.6.6 2016/5/4-2016/5/6
//	新建一个ConsoleCal项目 用以替换UIController 其中将数据结构CalData的数种类型放入CalString中
//  新建MatrixProject项目 复制Calculator1.0 中的基础类，加以修改 完成矩阵的运算处理 
//  修改量非常少 主要是Calculator类的泛型处理 数据录入放在ConsoleCal中 
//  原来的功能全部保留 只不过是加了一层抽象 double->ExpData 
//  矩阵的函数处理没有完成 只是完成简单四则运算 为解决可能的错误输入多次调用SimpleCal检查错误不好

//目标:实现基本运算 <完成>
//	实现括号运算  <完成>
//	实现多位数运算<完成>
//	实现小数点<完成>
//	实现函数<完成>
//  实现方程
//  实现求解方程
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

	