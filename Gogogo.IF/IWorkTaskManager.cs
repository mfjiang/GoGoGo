using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using GoGoGo.Abstract.Entity;

namespace GoGoGo.Abstract
{
	public interface IWorkTaskManager
	{
		ulong Add(IWorkUnit unit);
		bool Update(IWorkUnit unit);
		bool Delete(ulong id);
		bool MoveToUser(ulong id, ulong userID);
		IWorkTask Get(ulong id);
		DataSet GetDataPage(string sqlQuery, string orderBy, int pageSize, int pageNo, string fields);
		List<IWorkTask> LoadProjectTasks(ulong projectID);
		List<IWorkTask> LoadWorkUnitTasks(ulong projectID, ulong unitID);
		List<IWorkTask> LoadUserTasks(ulong projectID, ulong userID);
		List<IWorkTask> LoadUserTasks(ulong userID);
	}
}
