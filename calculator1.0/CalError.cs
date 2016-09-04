 
using System;

namespace calculator1_0
{
	/// <summary>
	/// Description of CalError.
	/// 收集出错信息 添加提示信息
	/// </summary>
	public class CalError//收集出错信息
	{
		public CalError()
		{
			ErrorMessage ="";
		}
		public bool IF=false;
		public string ErrorMessage{set ;get;}
		
	}
}
