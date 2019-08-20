using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gogogo.IF
{
    public interface IAgileProjectManager
    {
        ulong Add(IAgileProject project);
        bool Update(IAgileProject project);
        bool Delete(ulong id);
        IAgileProject Get(ulong id);
        DataSet GetDataPage(string sqlQuery, string orderBy, int pageSize, int pageNo, string fields);
        ulong AddWorkUnit(ulong projectID, ulong? parentUnitID);
        bool RemoveWorkUnit(ulong projectID, ulong unitID);
        bool MoveWorkUnit(ulong projectID, ulong fromUnitID,ulong toUnitID);
        List<IAgileProject> FindByCreator(ulong creatorID);
        List<IAgileProject> FindByChifeManager(ulong chifeManagerID);
        List<IAgileProject> FindByExecutor(ulong executorID);
        double GetProgress(ulong projectID);
        int CountTask(ulong projectID);
        int CountTask(ulong projectID, ulong workUnitID);
        List<IUser> GetMembers(ulong projectID);
        List<IUser> GetMembers(ulong projectID, ulong workUnitID);
    }
}
