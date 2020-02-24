﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ado.Mssql
{
    public abstract class Base
    {
        public static string conString { get; set; } // "Server=191.20.2.27;Uid=sa;PASSWORD=abc123;database=product;Max Pool Size=10;Connect Timeout=6000;";

        private string getConStr(string conStr)
        {
            return string.IsNullOrEmpty(conStr) ? conString : conStr;
        }

        protected T ExecuteScalar<T>(string cmdTxt, DynamicParameters parameter = null, string conStr = null)
        {
            using (SqlConnection conn = new SqlConnection(getConStr(conStr)))
            {
                var res = SqlMapper.ExecuteScalar<T>(conn, cmdTxt, parameter, null, 600);
                return res;
            }
        }
        protected T ExecuteScalarSP<T>(string cmdTxt, DynamicParameters parameter = null, string conStr = null)
        {
            using (SqlConnection conn = new SqlConnection(getConStr(conStr)))
            {
                var res = SqlMapper.ExecuteScalar<T>(conn, cmdTxt, parameter, null, 600, System.Data.CommandType.StoredProcedure);
                return res;
            }
        }

        protected int ExecuteNonQuery(string cmdTxt, DynamicParameters parameter = null, string conStr = null)
        {
            using (SqlConnection conn = new SqlConnection(getConStr(conStr)))
            {
                var res = SqlMapper.Execute(conn, cmdTxt, parameter, null, 600);
                return res;
            }
        }
        protected int ExecuteNonQuerySP(string cmdTxt, DynamicParameters parameter = null, string conStr = null)
        {
            using (SqlConnection conn = new SqlConnection(getConStr(conStr)))
            {
                var res = SqlMapper.Execute(conn, cmdTxt, parameter, null, 600, System.Data.CommandType.StoredProcedure);
                return res;
            }
        }

        protected IEnumerable<T> Query<T>(string cmdTxt, DynamicParameters parameter = null, string conStr = null)
        {
            using (SqlConnection conn = new SqlConnection(getConStr(conStr)))
            {
                var res = SqlMapper.Query<T>(conn, cmdTxt, parameter, null, true, 600);
                return res;
            }
        }

        protected IEnumerable<T> QuerySP<T>(string spName, DynamicParameters parameter = null, string conStr = null)
        {
            using (SqlConnection conn = new SqlConnection(getConStr(conStr)))
            {
                var res = SqlMapper.Query<T>(conn, spName, parameter, null, true, 600, System.Data.CommandType.StoredProcedure);
                return res;
            }
        }
        protected IEnumerable<T> QuerySP<T>(SqlTransaction transaction, string spName, DynamicParameters parameter = null)
        {
            if (transaction == null)
            {
                return QuerySP<T>(spName, parameter);
            }
            var res = transaction.Connection.Query<T>(spName, parameter, transaction, true, 600, System.Data.CommandType.StoredProcedure);
            return res;
        }

        // Transaction Rollback
        protected T ExecuteScalar<T>(SqlTransaction transaction, string cmdTxt, DynamicParameters parameter = null)
        {
            if (transaction == null)
            {
                return ExecuteScalar<T>(cmdTxt, parameter);
            }
            var res = SqlMapper.ExecuteScalar<T>(transaction.Connection, cmdTxt, parameter, transaction, 600);
            return res;
        }
        protected int ExecuteNonQuery(SqlTransaction transaction, string cmdTxt, DynamicParameters parameter = null)
        {
            if (transaction == null)
            {
                return ExecuteNonQuery(cmdTxt, parameter);
            }
            var res = SqlMapper.Execute(transaction.Connection, cmdTxt, parameter, transaction, 600);
            return res;
        }
        protected IEnumerable<T> Query<T>(SqlTransaction transaction, string cmdTxt, DynamicParameters parameter = null)
        {
            if (transaction == null)
            {
                return Query<T>(cmdTxt, parameter);
            }
            var res = SqlMapper.Query<T>(transaction.Connection, cmdTxt, parameter, transaction, true, 600);
            return res;
        }

        public static SqlConnection OpenConnection(string conStr = null)
        {
            SqlConnection conn = new SqlConnection(string.IsNullOrEmpty(conStr) ? conString : conStr);
            return conn;
        }
        public static SqlTransaction BeginTransaction()
        {
            var conn = OpenConnection();
            conn.Open();
            return conn.BeginTransaction();
        }
    }
}
