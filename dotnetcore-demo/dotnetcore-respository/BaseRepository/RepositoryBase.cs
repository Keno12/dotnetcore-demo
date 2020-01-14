﻿using Dapper;
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
               int count= await conn.ExecuteAsync(deleteSql, new { Id = Id });
                if (count>0)
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
                //string querySql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM dbo.Users WHERE Id=@Id";
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

        public async Task Insert(T entity, string insertSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                await conn.ExecuteAsync(insertSql, entity);
            }
        }

        public async Task<List<T>> Select(string selectSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                //string selectSql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM dbo.Users";
                return await Task.Run(() => conn.Query<T>(selectSql).ToList());
            }
        }

        public async Task Update(T entity, string updateSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                await conn.ExecuteAsync(updateSql, entity);
            }
        }
    }
}
