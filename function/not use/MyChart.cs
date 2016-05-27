/*
 * 由SharpDevelop创建。
 * 用户： yanghang
 * 日期: 2015/12/28
 * 时间: 22:10
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;

using System.Windows.Forms.DataVisualization.Charting;

namespace function
{
	/// <summary>
	/// Description of MyChart.
	/// 画图的
	/// </summary>
	public class MyChart
	{
		public MyChart()
		{
			//加边框
			chart.Palette = ChartColorPalette.BrightPastel;
			chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
			
		}
		private Chart chart=new Chart();
		private Series series=new Series();
		public void CreateSeriesDatas(double []xx,double []yy)
		{
						
			for (int i = 0; i < xx.Length; i++) {
		 
//				series.ChartArea="zheshisha";
				series.Points.AddXY(xx[i],yy[i]);
			}
						
		}
		public void CreateSeriesData(double xx,double yy)
		{
						 	 
//				series.ChartArea="zheshisha";
				series.Points.AddXY(xx,yy);
		 
						
		}
		public Chart GetChart()
		{
			return chart;
		}
		public void SetChartArea()
		{
				#region ChartArea
			ChartArea chartArea = new ChartArea("ChartArea1");
			chartArea.BorderDashStyle = ChartDashStyle.Solid;
			chartArea.BackColor = Color.WhiteSmoke;// Color.FromArgb(0, 0, 0, 0);       
			chartArea.ShadowColor = Color.FromArgb(0, 0, 0, 0);
			chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;//设置网格为虚线
			chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
			chart.ChartAreas.Add(chartArea);
			#endregion

		
		}
		public void SetSeries()
		{
				#region Series
//			Series serDValue = new Series("SerDValue");
			series.ChartArea = "ChartArea1";
			series.YValueType = ChartValueType.Double;
//			series.LabelFormat = "0.ms";
			series.XValueType = ChartValueType.Auto;
			series.ShadowColor = Color.Black;
			series.CustomProperties = "DrawingStyle=Emboss";
          
			#endregion
			 
			
			series.BorderWidth = 3;
			series.ShadowOffset = 2;
			series.ChartType=SeriesChartType.Line;
			series.Color = Color.FromArgb(20, 230, 20);
			chart.Series.Add(series);
		}
		public    void SimpleChart(Chart Chart1)
		{
			 
			Series series = new Series("Spline");
			series.ChartType = SeriesChartType.Spline;
			series.BorderWidth = 3;
			series.ShadowOffset = 2;

			// Populate new series with data
			series.Points.AddY(67);
			series.Points.AddY(57);
			series.Points.AddY(83);
			series.Points.AddY(23);
			series.Points.AddY(70);
			series.Points.AddY(60);
			series.Points.AddY(90);
			series.Points.AddY(20);
			series.Color = Color.FromArgb(20, 230, 20);

			// Add series into the chart's series collection
			Chart1.Series.Add(series);
       
		}
		/// <summary>
		/// 设置Chart基本信息
		/// </summary>
		/// <param name="chartName"></param>
		/// <returns></returns>
		public Chart ChartSetting(string chartName)
		{
			Chart newChart = new Chart();

			#region chart properies
			newChart.Width = 200;
			newChart.Height = 200;
			newChart.BackColor = Color.White;// Color.FromArgb(211, 223, 240);
//        newChart.ID = chartName;
//        newChart.CssClass = "chartInfo";
			newChart.Name = chartName;
			newChart.Palette = ChartColorPalette.BrightPastel;
			newChart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
			#endregion

			#region ChartArea
			ChartArea chartArea = new ChartArea("ChartArea1");
			chartArea.BorderDashStyle = ChartDashStyle.Solid;
			chartArea.BackColor = Color.WhiteSmoke;// Color.FromArgb(0, 0, 0, 0);       
			chartArea.ShadowColor = Color.FromArgb(0, 0, 0, 0);
			chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;//设置网格为虚线
			chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
			newChart.ChartAreas.Add(chartArea);
			#endregion

			#region Series
			Series serDValue = new Series("SerDValue");
			serDValue.ChartArea = "ChartArea1";
			serDValue.YValueType = ChartValueType.Double;
			serDValue.LabelFormat = "0.ms";
			serDValue.XValueType = ChartValueType.Auto;
			serDValue.ShadowColor = Color.Black;
			serDValue.CustomProperties = "DrawingStyle=Emboss";
         
			newChart.Series.Add(serDValue);
			#endregion

			#region 添加单击事件
//        newChart.Click+=new ImageMapEventHandler(NewChart_Click);
//        newChart.Attributes["onclick"] = ClientScript.GetPostBackEventReference(newChart, "@").Replace("'@'", "'chart:'+_getCoord(event)");
//        newChart.Style[HtmlTextWriterStyle.Position] = "relative";       
			#endregion

			return newChart;
		}
    
		//    public void DrawChart()
		//    {
		//       #region 根据缓存获取相关数据
		//       object cacheCodeData = DataCache.GetCache(Guid.Next());
		//       if (cacheCodeData != null)
		//       {
		//           dtData = cacheCodeData as DataTable;
		//       }
		//       else
		//       {
		//           dtData =GetDataTableInfo();//获取数据
		//           //重新写入缓存
		//           if (dtData != null)
		//           {
		//               DataCache.SetCache(Guid.Next());
		//           }
		//       }
		//       #endregion
		//
		//        Series series = null;
		//        series = new Series("Spline");
		//        series.Color = Color.FromArgb(220, 65, 140, 240);
		//
		//        if (rblChartType.SelectedValue == "0")
		//        {
		//            series.ChartType = SeriesChartType.Column;//柱状图
		//        }
		//        else
		//        {
		//            series.ChartType = SeriesChartType.Line;//折线图
		//        }
		//       Chart NewChart = ChartSetting(strStationID +"_"+ paramCode);
		//       IsShowAbnormal = cbAbnormalValue.Checked;
		//
		//       if (dsStationData == null)
		//       {
		//           //标题
		//           NewChart.Titles.Add("：暂无相关值");
		//       }
		//       else
		//       {
		//           NewChart.Titles.Add(strDefaultDataParamName);
		//           for (int i = 0; i < dtData.Rows.Count; i++)
		//           {
		//               DataRow row = dtData.Rows[i];
		//               string x = row["DataTime"] == null ? "" : row["DataTime"].ToString();
		//               string y = row["dValue"] == null ? "0" : row["DataValue"].ToString();
		//               series.Points.AddXY(x, y);
		//               //鼠标悬停显示值
		//               series.Points[i].ToolTip = "检测时间=[" + x + "]\n检测值=" + y;
		//               //处理鼠标单击时获取的数据
		//               series.Points[i].PostBackValue = "series=" + series.Name + ",INDEX=#INDEX,X=#VALX,Y=#VALY,CODE=" + strDefaultDataParamName;
		//           }
		//       }
		//       NewChart.ChartAreas[0].AxisX.Title = "检测时间";
		//       NewChart.ChartAreas[0].AxisY.Title = "检测值" + "(" + CRtdData.GetParamUnit(paramCode) + ")";
		//       NewChart.Series.Remove(series);
		//       NewChart.Series.Add(series);
		//       //NewChart.Series["Spline"].MapAreaAttributes = "onclick=javascript:alert('Data point with index #INDEX was clicked')";
		//       PanelChartInfo.Controls.Add(NewChart);//将chart添加到aspx页面上的Panel控件
		//    }
	}
}
