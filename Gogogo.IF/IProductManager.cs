using System;
using System.Collections.Generic;
using System.Data;
using GoGoGo.Abstract.Entity;

namespace GoGoGo.Abstract
{
	public interface IProductManager
	{

		ulong AddProduct(IProduct product);
		ulong AddModule(IProductModule module);
		ulong AddFeature(IProductFeature feature);

		bool Update(IProduct product);
		bool UpdateModule(IProductModule module);
		bool UpdateFeature(IProductFeature feature);

		bool DeleteProduct(ulong id);
		bool DeleteModule(ulong id);
		bool DeleteFeature(ulong id);

		IProduct Get(ulong id);

		List<IProduct> FindByName(string name);
		List<IProduct> FindByName(string name,int productType);
		List<IProduct> FindByType(int productType);

		DataSet GetDataPage(string sqlQuery, string orderBy, int pageSize, int pageNo, string fields);
	}
}
