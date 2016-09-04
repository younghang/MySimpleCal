/*
 * Created by SharpDevelop.
 * User: young
 * Date: 2016/4/24 星期日
 * Time: 0:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;

namespace calculator1_0
{
	/// <summary>
	/// Description of Matric.
	/// </summary>
	public 	class Matrix:CalData
	{
		public Matrix(int row)
		{
			CalType = DataType.MATRIX;
			mdata = new double[row, row];
			Row = row;
			Col = row;
		}
		public Matrix(double[,]data)
		{
			CalType = DataType.MATRIX;
			mdata = data;
			Row = data.GetUpperBound(0) + 1;
			Col = data.GetUpperBound(1) + 1;
		}
		public Matrix(int row, int col)
		{
			CalType = DataType.MATRIX;
			mdata = new double[row, col];
			Row = row;
			Col = col;
		}
		public int Row = 0;
		public int Col = 0;
		private double[,] mdata;
		
		public Matrix(Matrix m)
		{
			CalType = DataType.MATRIX;
			Row = m.Row;
			Col = m.Col;
			mdata = m.mdata;
		}
		
		#region 转置
		/// <summary>
		/// 将矩阵转置，得到一个新矩阵（此操作不影响原矩阵）
		/// </summary>
		/// <param name="input">要转置的矩阵</param>
		/// <returns>原矩阵经过转置得到的新矩阵</returns>
		public static Matrix Transpose(Matrix input)
		{
			double[,] inverseMatrix = new double[input.Col, input.Row];
			for (int r = 0; r < input.Row; r++)
				for (int c = 0; c < input.Col; c++)
					inverseMatrix[c, r] = input.GetData()[r, c];
			return new Matrix(inverseMatrix);
		}
		#endregion
		/// <summary>
		/// 返回矩阵二维数组
		/// </summary>
		/// <returns></returns>
		public double[,] GetData()
		{
			return mdata;
		}
		#region 得到行向量或者列向量
		public Matrix getRow(int r)
		{
			if (r > Row || r < 1)
				throw new MatrixException("没有这一行。");
			double[,] a = new double[1, Col];
			//         Array.Copy(mdata,  Col * (Row - 1), a, 0, Col);
			for (int i = 0; i < Col; i++)
				a[0, i] = mdata[r - 1, i];
			Matrix m = new Matrix(a);
			return m;
		}
		public Matrix getColumn(int c)
		{
			if (c > Col || c < 1)
				throw new MatrixException("没有这一列。");
			double[,] a = new double[Row, 1];
			for (int i = 0; i < Row; i++)
				a[i, 0] = mdata[i, c - 1];
			return new Matrix(a);
		}
		#endregion
//		
//		public override CalData Add(CalData d)
//		{
//			return this+d;
//		}
//		public override CalData Sub(CalData d)
//		{
//			return this-d;
//		}
//		public override CalData Pow(CalData d)
//		{
//			return this^d;
//		}
//		public override CalData Multi(CalData d)
//		{
//			return this*d;
//		}
//		public override CalData Divided(CalData d)
//		{
//			return this/d;
//		}
//		
//		
//		
		
		
		#region 操作符重载  + - * / == !=
		public static Matrix operator +(Matrix a, Matrix b)
		{
			if (a.Row != b.Row || a.Col != b.Col)
				throw new MatrixException("矩阵维数不匹配。");
			Matrix result = new Matrix(a.Row, a.Col);
			for (int i = 0; i < a.Row; i++)
				for (int j = 0; j < a.Col; j++)
					result[i, j] = a[i, j] + b[i, j];
			return result;
		}

		public static Matrix operator -(Matrix a, Matrix b)
		{
			return a + b * (-1);
		}
		 
		public static Matrix operator *(Matrix matrix, double factor)
		{
			Matrix result = new Matrix(matrix.Row, matrix.Col);
			for (int i = 0; i < matrix.Row; i++)
				for (int j = 0; j < matrix.Col; j++)
					result[i, j] = matrix[i, j] * factor;
			return result;
		}
		public static Matrix operator -(Matrix matrix, ExpData factor)
		{
			Matrix result = new Matrix(matrix.Row, matrix.Col);
			for (int i = 0; i < matrix.Row; i++)
				for (int j = 0; j < matrix.Col; j++)
					result[i, j] = matrix[i, j]- double.Parse(factor.GetValueEx());
			return result;
			 
		}
		public static Matrix operator +(Matrix matrix, ExpData factor)
		{			
			Matrix result = new Matrix(matrix.Row, matrix.Col);
			for (int i = 0; i < matrix.Row; i++)
				for (int j = 0; j < matrix.Col; j++)
					result[i, j] = matrix[i, j]+ double.Parse(factor.GetValueEx());
			return result;
		}
		 
		public static Matrix operator *(double factor, Matrix matrix)
		{
			return matrix * factor;
		}
		
		public static Matrix operator ^(Matrix matrix, int times)
		{
			Matrix result = new Matrix(matrix.Row);
			result.SetUnit();
			for (int i = 0; i < times; i++) {
				result = result * matrix;
			}
			return result;
		}
		public static Matrix operator ^(Matrix matrix, ExpData times)
		{
			Matrix result = matrix^int.Parse(times.GetValueEx());
			 
			return result;
		}
		
		public static Matrix operator *( Matrix matrix,ExpData factor)
		{
			return matrix * double.Parse(factor.GetValueEx());
		}
		public static Matrix operator *(Matrix a, Matrix b)
		{
			if (a.Col != b.Row)
				throw new MatrixException("矩阵维数不匹配。");
			Matrix result = new Matrix(a.Row, b.Col);
			for (int i = 0; i < a.Row; i++)
				for (int j = 0; j < b.Col; j++)
					for (int k = 0; k < a.Col; k++)
						result[i, j] += a[i, k] * b[k, j];
			
			return result;
		}
		public static bool operator ==(Matrix a, Matrix b)
		{
			if (object.Equals(a, b))
				return true;
			if (object.Equals(null, b))
				return a.Equals(b);
			return b.Equals(a);
		}
		public static bool operator !=(Matrix a, Matrix b)
		{
			return !(a == b);
		}
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			if (!(obj is Matrix))
				return false;
			Matrix t = obj as Matrix;
			if (Row != t.Row || Col != t.Col)
				return false;
			return this.Equals(t, 10);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		/// <summary>
		/// 按照给定的精度比较两个矩阵是否相等
		/// </summary>
		/// <param name="matrix">要比较的另外一个矩阵</param>
		/// <param name="precision">比较精度（小数位）</param>
		/// <returns>是否相等</returns>
		public bool Equals(Matrix matrix, int precision)
		{
			if (precision < 0)
				throw new MatrixException("小数位不能是负数");
			double test = Math.Pow(10.0, -precision);
			if (test < double.Epsilon)
				throw new MatrixException("所要求的精度太高，不被支持。");
			for (int r = 0; r < this.Row; r++)
				for (int c = 0; c < this.Col; c++)
					if (Math.Abs(this[r, c] - matrix[r, c]) >= test)
						return false;

			return true;
		}
		#endregion
		
		#region 属性和索引器
		public int rowNum { get { return Row; } }
		public int columnNum { get { return Col; } }

		public double this[int r, int c] {
			get{ return mdata[r, c]; }
			set{ mdata[r, c] = value; }
		}
		#endregion
		
		#region 设置初值
		//unit matrix:设为单位阵
		public void SetUnit(int a=1)
		{
			for (int i = 0; i < mdata.GetLength(0); i++)
				for (int j = 0; j < mdata.GetLength(1); j++)
					mdata[i, j] = ((i == j) ? a : 0);
		}

		//设置元素值
		public void SetValue(double d)
		{
			for (int i = 0; i < mdata.GetLength(0); i++)
				for (int j = 0; j < mdata.GetLength(1); j++)
					mdata[i, j] = d;
		}
		#endregion
		
		#region 初等变换 primary change
		
		/// <summary>
		/// 初等变换　对调两行：ri<-->rj
		/// </summary>
		/// <param name="i"></param>
		/// <param name="j"></param>
		/// <returns></returns>
		public Matrix Exchange(int i, int j)
		{
			double temp;

			for (int k = 0; k < Col; k++) {
				temp = mdata[i, k];
				mdata[i, k] = mdata[j, k];
				mdata[j, k] = temp;
			}
			return this;
		}


		
		/// <summary>
		///   初等变换　第index 行乘以mul
		/// </summary>
		/// <param name="index"></param>
		/// <param name="mul"></param>
		Matrix Multiple(int index, double mul)
		{
			for (int j = 0; j < Col; j++) {
				mdata[index, j] *= mul;
			}
			return this;
		}
		

		/// <summary>
		///  初等变换 第src行乘以mul加到第index行
		/// </summary>
		/// <param name="index"></param>
		/// <param name="src"></param>
		/// <param name="mul"></param>
		/// <returns></returns>
		Matrix MultipleAdd(int index, int src, double mul)
		{
			for (int j = 0; j < Col; j++) {
				mdata[index, j] += mdata[src, j] * mul;
			}

			return this;
		}
		
		#endregion
		
		//binary division 矩阵除
		public static Matrix operator/(Matrix lhs, Matrix rhs)
		{
			return lhs * rhs.Inverse();
		}

		//unary addition单目加
		public static Matrix operator+(Matrix m)
		{
			Matrix ret = new Matrix(m);
			return ret;
		}

		//unary subtraction 单目减
		public static Matrix operator-(Matrix m)
		{
			Matrix ret = new Matrix(m);
			for (int i = 0; i < ret.Row; i++)
				for (int j = 0; j < ret.Col; j++) {
				ret[i, j] = -ret[i, j];
			}

			return ret;
		}

		

		//number division 数除
		public static Matrix operator/(double d, Matrix m)
		{
			return d * m.Inverse();
		}
		//功能：返回列主元素的行号
		//参数：row为开始查找的行号
		//说明：在行号[row,Col)范围内查找第row列中绝对值最大的元素，返回所在行号
		int Pivot(int row)
		{
			int index = row;

			for (int i = row + 1; i < Row; i++) {
				if (mdata[i, row] > mdata[index, row])
					index = i;
			}

			return index;
		}

		//inversion 逆阵：使用矩阵的初等变换，列主元素消去法
		public Matrix Inverse()
		{
			if (Row != Col) {    //异常,非方阵
				System.Exception e = new Exception("求逆的矩阵不是方阵");
				throw e;
			}
			StreamWriter sw = new StreamWriter("..\\annex\\close_matrix.txt");
			Matrix tmp = new Matrix(this);
			Matrix ret = new Matrix(Row);    //单位阵
			ret.SetUnit();

			int maxIndex;
			double dMul;

			for (int i = 0; i < Row; i++) {
				maxIndex = tmp.Pivot(i);
				
				if (tmp.mdata[maxIndex, i] == 0) {
					System.Exception e = new Exception("求逆的矩阵的行列式的值等于0,");
					throw e;
				}

				if (maxIndex != i) {    //下三角阵中此列的最大值不在当前行，交换
					tmp.Exchange(i, maxIndex);
					ret.Exchange(i, maxIndex);

				}

				ret.Multiple(i, 1 / tmp[i, i]);
				tmp.Multiple(i, 1 / tmp[i, i]);

				for (int j = i + 1; j < Row; j++) {
					dMul = -tmp[j, i] / tmp[i, i];
					tmp.MultipleAdd(j, i, dMul);
					
				}
				sw.WriteLine("tmp=\r\n" + tmp);
				sw.WriteLine("ret=\r\n" + ret);
			}//end for


			sw.WriteLine("**=\r\n" + this * ret);

			for (int i = Row - 1; i > 0; i--) {
				for (int j = i - 1; j >= 0; j--) {
					dMul = -tmp[j, i] / tmp[i, i];
					tmp.MultipleAdd(j, i, dMul);
					ret.MultipleAdd(j, i, dMul);
				}
			}//end for


			sw.WriteLine("tmp=\r\n" + tmp);
			sw.WriteLine("ret=\r\n" + ret);
			sw.WriteLine("***=\r\n" + this * ret);
			sw.Close();
			
			return ret;

		}
		//end Inverse

		#region
		/*
        //inversion 逆阵：使用矩阵的初等变换，列主元素消去法
        public Matrix Inverse()
        {
            if(Row != Col)    //异常,非方阵
            {
                System.Exception e = new Exception("求逆的矩阵不是方阵");
                throw e;
            }
            ///////////////
            StreamWriter sw = new StreamWriter("..\\annex\\matrix_mul.txt");
            ////////////////////
            ///
            Matrix tmp = new Matrix(this);
            Matrix ret =new Matrix(Row);    //单位阵
            ret.SetUnit();

            int maxIndex;
            double dMul;

            for(int i=0;i<Row;i++)
            {

                maxIndex = tmp.Pivot(i);
    
                if(tmp.mdata[maxIndex,i]==0)
                {
                    System.Exception e = new Exception("求逆的矩阵的行列式的值等于0,");
                    throw e;
                }

                if(maxIndex != i)    //下三角阵中此列的最大值不在当前行，交换
                {
                    tmp.Exchange(i,maxIndex);
                    ret.Exchange(i,maxIndex);

                }

                ret.Multiple(i,1/tmp[i,i]);

                /////////////////////////
                //sw.WriteLine("nul \t"+tmp[i,i]+"\t"+ret[i,i]);
                ////////////////
                tmp.Multiple(i,1/tmp[i,i]);
                //sw.WriteLine("mmm \t"+tmp[i,i]+"\t"+ret[i,i]);
                sw.WriteLine("111111111 tmp=\r\n"+tmp);
                for(int j=i+1;j<Row;j++)
                {
                    dMul = -tmp[j,i];
                    tmp.MultipleAdd(j,i,dMul);
                    ret.MultipleAdd(j,i,dMul);
                }
                sw.WriteLine("222222222222=\r\n"+tmp);

            }//end for

            for(int i=Row-1;i>0;i--)
            {
                for(int j=i-1;j>=0;j--)
                {
                    dMul = -tmp[j,i];
                    tmp.MultipleAdd(j,i,dMul);
                    ret.MultipleAdd(j,i,dMul);
                }
            }//end for
        
            //////////////////////////


            sw.WriteLine("tmp = \r\n" + tmp.ToString());

            sw.Close();
            ///////////////////////////////////////
            ///
            return ret;

        }//end Inverse

		 */

		#endregion

		//determine if the matrix is square:方阵
		public bool IsSquare()
		{
			return Row == Col;
		}

		//determine if the matrix is symmetric对称阵
		public bool IsSymmetric()
		{

			if (Row != Col)
				return false;
			
			for (int i = 0; i < Row; i++)
				for (int j = i + 1; j < Col; j++)
					if (mdata[i, j] != mdata[j, i])
						return false;

			return true;
		}

		//一阶矩阵->实数
		public double ToDouble()
		{
			Trace.Assert(Row == 1 && Col == 1);

			return mdata[0, 0];
		}
		
		public override string ToString()
		{
			int maxlength = 0;
			string strMatric = "";
			strMatric += "[\n";
			for (int r = 0; r < Row; r++) {
				for (int c = 0; c < Col; c++) {
					string strtemp = mdata[r, c].ToString();
					int currentlength = TrueLength(strtemp);
					if (currentlength > maxlength) {
						maxlength = currentlength;
					}
				}
				
			}
			for (int r = 0; r < Row; r++) {
				
				for (int c = 0; c < Col; c++) {
					strMatric += "\t";
					string strtemp = mdata[r, c].ToString();
					
					strMatric += PadRightTrueLen(strtemp, 4 + maxlength, ' ');
					
				}
				strMatric += "\n";
				
			}
			strMatric += "]";
			return strMatric;
			
		}
		
		#region 格式化字符串长度 方便输出
		/// 根据asc码来判断字符串的长度，在0~127间字符长度加1，否则加2
		///

		/// 需要返回长度的字符串
		/// 
		public static int TrueLength(string str)
		{
			int lenTotal = 0;
			int n = str.Length;
			string strWord = "";  //清空字符串
			int asc;
			for (int i = 0; i < n; i++) {
				strWord = str.Substring(i, 1);
				asc = Convert.ToChar(strWord);
				if (asc < 0 || asc > 127) {      // 在0~127间字符长度加1，否则加2
					lenTotal = lenTotal + 2;
				} else {
					lenTotal = lenTotal + 1;
				}
			}
			return lenTotal;
		}
		

		
		/// 统一字符串的长度
		///

		/// 初始字符串
		/// 规定统一字符串的长度
		/// 追加的字符为' '
		/// 返回统一后的字符串
		public static string PadRightTrueLen(string strOriginal, int maxTrueLength, char chrPad)
		{
			string strNew = strOriginal;
			if (strOriginal == null || maxTrueLength <= 0) {
				strNew = "";
				return strNew;
			}
			int trueLen = TrueLength(strOriginal);
			if (trueLen > maxTrueLength) {                    // 如果字符串大于规定长度 将规定长度等于字符串长度
				for (int i = 0; i < trueLen - maxTrueLength; i++) {
					maxTrueLength += chrPad.ToString().Length;
				}
				
				
			} else {// 填充  小于规定长度 用‘ ’追加，直至等于规定长度
				for (int i = 0; i < maxTrueLength - trueLen; i++) {
					strNew += chrPad.ToString();
				}
			}
			return strNew;
		}
		#endregion
	}
	class MatrixException:Exception
	{
		public MatrixException(string str)
			: base(str)
		{
			
		}
		
	}
}
