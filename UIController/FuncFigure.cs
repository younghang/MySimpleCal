/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2015/10/11
 * Time: 14:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace UIController
{
	/// <summary>
	/// Description of FuncForm.
	/// 完成函数图形的绘制
	/// </summary>
	public partial class FuncFigure : Form
	{
		public FuncFigure()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		Chart mchart;
		public void AddChart(Chart chart)
		{
			mchart=chart;
//			chart.MouseHover += new EventHandler((x, y) => MessageBox.Show("Mouse over")); //增加事
		}
		void FuncFormPaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的.就不应调用Disposal()
//			Graphics  g = this.CreateGraphics();
			Pen p = new Pen(Color.Black, 2);//定义了一个蓝色,宽度为的画笔
//			int leftbottom=0;
			int size=150;
			string xlable="X";
			string ylable="Y";
			
			int righttop=size;
			
           #region 画坐标系
           
			g.TranslateTransform(righttop,righttop);
			g.ScaleTransform(1, -1);//y轴反向 或者下面这个
//		    g.Transform.Multiply(new Matrix(1, 0, 0, -1, 0, 0)); 
			
			Rectangle rect=new Rectangle(-righttop, -righttop, 2*righttop, 2*righttop);
			SolidBrush b1 = new SolidBrush(Color.AliceBlue);//定义单色画刷
			
			p.Brush=b1;
			p.DashPattern = new  float[] { 2, 1 };
//			g.DrawRectangle(p, -righttop, -righttop, righttop, righttop);//在画板上画矩形,起始坐标为(10,10),宽为,高为
			g.FillRectangle(b1, rect);//填充这个矩形
			p.DashStyle = DashStyle.Solid;//恢复实线
			p.EndCap = LineCap.ArrowAnchor;//定义线尾的样式为箭头
			 
			//画箭头,只对不封闭曲线有用
			System.Drawing.Drawing2D.AdjustableArrowCap _LineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(9, 9, false);   //设置一个线头	
            Pen _Pen = new Pen(Brushes.Black, 1);
            _Pen.CustomEndCap = (System.Drawing.Drawing2D.CustomLineCap)_LineCap;  
			g.DrawLine(_Pen, -righttop+righttop/10,0 ,righttop-righttop/10, 0);//X轴 在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
			g.DrawLine(_Pen, 0, -righttop+righttop/10, 0,righttop-righttop/10);//在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
			//写坐标名
			g.ScaleTransform(1,-1);
			g.DrawString(xlable,new Font("宋体",12),_Pen.Brush,righttop-righttop/10, 0);
			g.DrawString(ylable,new Font("宋体",12),_Pen.Brush, -righttop/10,-righttop+righttop/20);
			g.DrawString("O",new Font("宋体",12),_Pen.Brush, righttop/20,-righttop/10);
         
			#endregion
			
			
//			g.Dispose();
			p.Dispose();

//			g.DrawEllipse(p, 10, 10, 100, 100);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
			
			
			
			
			
			
			
			
			
			
			
			
//			g.DrawLine(p, 10, 10, 100, 100);//在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
			//画虚线
//			p.DashStyle = DashStyle.Dot;//定义虚线的样式为点
//			g.DrawLine(p, 10, 10, 200, 10);
//
//			//自定义虚线
//			p.DashPattern = new  float[] { 2, 1 };//设置短划线和空白部分的数组
//			g.DrawLine(p, 10, 20, 200, 20);
			
			//单色填充
			//SolidBrush b1 = new SolidBrush(Color.Blue);//定义单色画刷
//			g.FillRectangle(b1, rect);//填充这个矩形
//
//			//字符串
//			g.DrawString("字符串", new Font("宋体", 10), b1, new PointF(90, 10));
//
//			//用图片填充
//			TextureBrush b2 = new TextureBrush(Image.FromFile(@"e:\picture\1.jpg"));
//			rect.Location = new Point(10, 70);//更改这个矩形的起点坐标
//			rect.Width = 200;//更改这个矩形的宽来
//			rect.Height = 200;//更改这个矩形的高
//			g.FillRectangle(b2, rect);
//
//			//用渐变色填充
//			rect.Location = new Point(10, 290);
//			LinearGradientBrush b3 = new  LinearGradientBrush(rect, Color.Yellow , Color.Black , LinearGradientMode.Horizontal);
//			g.FillRectangle(b3, rect);
			
			
			
//			Pen p = new Pen(Color.Blue,1);
//
//			//转变坐标轴角度
//			for (int i = 0; i < 90; i++)
//			{
//				g.RotateTransform(i);//每旋转一度就画一条线
//				g.DrawLine(p, 0, 0, 100, 0);
//				g.ResetTransform();//恢复坐标轴坐标
//			}
//
//			//平移坐标轴
//			g.TranslateTransform(100, 100);
//			g.DrawLine(p, 0, 0, 100, 0);
//			g.ResetTransform();
//
//			//先平移到指定坐标,然后进行度旋转
//			g.TranslateTransform(100,200);
//			for (int i = 0; i < 8; i++)
//			{
//				g.RotateTransform(45);
//				g.DrawLine(p, 0, 0, 100, 0);
//			}
//
//			g.Dispose();
//			public  void  DrawLineFloat(PaintEventArgs  e)
//			{
//				//  Create  pen.
//				Pen  blackPen  =  new  Pen(Color.Black,  3);
//				//  Create  coordinates  of  points  that  define  line.
//				float  x1  =  100.0F;
//				float  y1  =  100.0F;
//				float  x2  =  500.0F;
//				float  y2  =  100.0F;
//				//  Draw  line  to  screen.
//				e.Graphics.DrawLine(blackPen,  x1,  y1,  x2,  y2);
//			}
//			2、正方形
//				g.DrawRectangle(thepen, ps.X, ps.Y, 0.5F, 0.5F);
//			3、指定的图形
//				Bitmap  bm=new  Bitmap(2,2);    //这里调整点的大小
//			bm.SetPixel(0,  0,  color);      //设置点的颜色
//			bm.SetPixel(0,  1,  color);
//			bm.SetPixel(1,  0,  color);
//			bm.SetPixel(1,  1,  color);
//			Graphics  g  =  Graphics.FromHwnd(this.panel1.Handle);    //画在哪里
//			g.DrawImageUnscaled(bm,  e.X,  e.Y);      //具体坐标
//
//
//			关于最后一种方法，还有一个详细的例子，如下：
//				用Bitmap的SetPixel()函数来实现。其实现是通过设置像素点生成一张图片，然后显示图片。
//				//定义图片
//				Bitmap bmp;
//			private void Form1_Load(object sender, EventArgs e)
//			{
//				bmp = new Bitmap(this.ClientRectangle.Width,this.ClientRectangle.Height);
//
//				Graphics graphics = Graphics.FromImage(bmp);
//
//				int i,j;
//				int w= bmp.Width;
//				int h = bmp.Height;
//
//				int interval = 5;
//				//每隔5个像素点画设置一个黑颜色点，生成图片。
//				for (i = 0; i < w; i += interval)
//				{
//					for (j = 0; j < h; j += interval)
//					{
//						//使用SetPixel()来设置像素点。
//						bmp.SetPixel(i,j,Color.Black);
//					}
//				}
//			}
//
//			private void Form1_Paint(object sender, PaintEventArgs e)
//			{
//				Graphics graphics = e.Graphics;
//				//显示图片
//				graphics.DrawImage(bmp,new Rectangle(0,0,this.ClientRectangle.Width,this.ClientRectangle.Height));
//			}
			if (!Controls.Contains(mchart)) {
				Controls.Add(mchart);
			}
			mchart.BackImageAlignment= ChartImageAlignmentStyle.Center;
			mchart.SetBounds(20,30,350,350);
		}
		
		 
	}
}
