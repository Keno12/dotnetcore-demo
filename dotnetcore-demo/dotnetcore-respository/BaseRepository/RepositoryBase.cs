using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_respository.BaseRepository
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    {
        public async Task<bool> Delete(Guid Id, string deleteSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                int count = await conn.ExecuteAsync(deleteSql, new { Id = Id });
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<T> Detail(Guid Id, string detailSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {   
                return await conn.QueryFirstOrDefaultAsync<T>(detailSql, new { Id = Id });
            }
        }

        // 无参存储过程
        public async Task<List<T>> ExecQuerySP(string SPName)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return await Task.Run(() => conn.Query<T>(SPName, null, null, true, null, CommandType.StoredProcedure).ToList());
            }
        }

        public async Task<bool> Insert(T entity, string insertSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                int count = await conn.ExecuteAsync(insertSql, entity);
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<List<T>> Select(string selectSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return await Task.Run(() => conn.Query<T>(selectSql).ToList());
            }
        }

        public async Task<bool> Update(T entity, string updateSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                int count = await conn.ExecuteAsync(updateSql, entity);
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
