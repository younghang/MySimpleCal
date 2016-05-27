/*
 * Created by SharpDevelop.
 * User: younghang
 * Date: 2015/10/24
 * Time: 16:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
namespace UIController
{
	/// <summary>
	/// Description of TempDataCollection.
	/// </summary>
	public class TempDataCollection
	{
		public TempDataCollection()
		{
			Initial();
		}
		public int GetLength()
		{
			return inputs.Count;
		}
		private void Initial()
		{
			inputs.Add(new TempData("pi",new ExpData(Math.PI.ToString())));
			inputs.Add(new TempData("e",new ExpData(Math.E.ToString())));
//			CreateData("pi",));
//			CreateData("e",new ExpData(Math.E.ToString()));
		}
		private List<TempData> inputs=new List<TempData>();
		public int   FindPosition(string name)
		{
			
			return inputs.FindIndex((lp)=>{return lp.GetName()==name;});
		}
		public void Repalce(int pos,TempData td)
		{
			inputs.RemoveAt(pos);
			inputs.Insert(pos,td);
			
		}
		
		public TempData GetTop()
		{
			TempData td= inputs[inputs.Count-1];
			inputs.RemoveAt(inputs.Count-1);
			return td;
			
		}
		public TempData GetData(string name)
		{
			return inputs[FindPosition(name)];
		}
		public TempData GetData(int position)
		{
			if (position>1&&position<inputs.Count) {
				return inputs[position];
			}else
				return null;
			
		}
		public bool CheckName(string name)
		{
			bool isIn=false;
			foreach (var element in inputs) {
				if (element.GetName()==name) {
					isIn=true;
//					Console.WriteLine("数据位置："+inputs.FindIndex((lp)=>{return lp.GetName()==name;}));
					break;
				}
			}
			return isIn;
		}
		public bool CreateData(string name,CalData value)
		{
			bool right=true;
			if (name!="pi"&&name!="e") {
				inputs.Add(new TempData(name,value));
				
			}
			else right=false;
			return right;
			
		}
		public void Remove(int pos)
		{
			inputs.RemoveAt(pos);
		}
		public void RemoveAll()
		{
			inputs.Clear();
			Initial();
		}
		 
	}
}
