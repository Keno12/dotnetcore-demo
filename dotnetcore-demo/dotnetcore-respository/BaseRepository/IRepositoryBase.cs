using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetcore_respository.BaseRepository
{
    public interface IRepositoryBase<T>
    {
        Task<bool> Insert(T entity, string insertSql);

        Task<bool> Update(T entity, string updateSql);

        Task<bool> Delete(Guid Id, string deleteSql);

        Task<List<T>> Select(string selectSql);

        Task<T> Detail(Guid Id, string detailSql);

        // 无参存储过程
        Task<List<T>> ExecQuerySP(string SPName);
    }
}
