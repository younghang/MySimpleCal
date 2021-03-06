﻿/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2016/1/15
 * Time: 11:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace calculator1_0
{
	/// <summary>
	/// Description of CalData.
	/// </summary>
	 
	
	public abstract class  CalData : System.ComponentModel.INotifyPropertyChanged   
	{
		public CalData()
		{
		}
//		public virtual CalData Add(CalData d)
//		{
//			return this;
//		}
//		public virtual CalData Sub(CalData d)
//		{
//			return this;
//		}
//		public virtual CalData Pow(CalData d)
//		{
//			return this;
//		}
//		public virtual CalData Multi(CalData d)
//		{
//			return this;
//		}
//		public virtual CalData Divided(CalData d)
//		{
//			return this;
//		}
		DataType type;
		
		// disable once ConvertToAutoProperty
		public DataType CalType {
			get { return type; }
			set { type = value; }
		} 
		

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
		public abstract new  string ToString();
		 
	 
		
	 
	}
	public enum DataType{NONE=0,EXP=1,FUNC=2,BLOCK=3,MATRIX=4};
}
