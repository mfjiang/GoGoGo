using System;
using GoGoGo.DataStorage;

namespace GoGoGo.Core
{
	public class ProductManager
	{
		#region private fileds
		private ProductRepo m_ProductRepo;
		private string m_ConnStr;
		#endregion

		public ProductManager(string connstr)
		{
			if (String.IsNullOrEmpty(connstr))
			{
				throw new ArgumentNullException("connstr");
			}

			m_ConnStr = connstr;
		}


	}
}
