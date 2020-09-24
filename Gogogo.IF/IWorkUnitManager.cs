using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using GoGoGo.Abstract.Entity;

namespace GoGoGo.Abstract
{
    public interface IWorkUnitManager
    {
        ulong Add(IWorkUnit unit);
        bool Update(IWorkUnit unit);
        bool Delete(ulong id);
        IAgileProject Get(ulong id);
        DataSet GetDataPage(string sqlQuery, string orderBy, int pageSize, int pageNo, string fields);
        List<IWorkUnit> LoadChilds(ulong projectID);
        List<IWorkUnit> LoadChilds(ulong projectID,ulong parentUnitID);
    }
}
