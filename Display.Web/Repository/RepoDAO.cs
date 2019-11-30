using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Display.Web.Repository
{
    public class RepoDAO
    {
        SqlConnection _connection;
        public RepoDAO()
        {
            Init();
        }

        private void Init()
        {
            _connection = new SqlConnection(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["DbConnection"].ToString();
        }

        private void OpenConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            _connection.Open();
        }

        private void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public DataSet ExecuteDataSet(string sql)
        {
            var ds = new DataSet();
            var cmd = new SqlCommand(sql, _connection);
            cmd.CommandTimeout = 120;
            SqlDataAdapter da;
            try
            {
                OpenConnection();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                da = null;
                CloseConnection();
            }
            return ds;
        }

        public void ExecuteNonQuery(string sql)
        {
            var cmd = new SqlCommand(sql, _connection);
            cmd.CommandTimeout = 120;
            try
            {
                OpenConnection();
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable ExecuteDataTable(string sql)
        {
            using (var ds = ExecuteDataSet(sql))
            {
                return ds.Tables[0];
            }
        }

        public string FilterString(string strVal)
        {
            var str = FilterQuote(strVal);

            if (str.ToLower() != "null")
                str = "'" + str + "'";

            return str.TrimEnd().TrimStart();
        }

        public string FilterQuote(string strVal)
        {
            if (string.IsNullOrEmpty(strVal))
            {
                strVal = "";
            }
            var str = strVal.Trim();

            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace(";", "");
                str = str.Replace("--", "");
                str = str.Replace("'", "");

                str = str.Replace("/*", "");
                str = str.Replace("*/", "");

                str = str.Replace(" select ", "");
                str = str.Replace(" insert ", "");
                str = str.Replace(" update ", "");
                str = str.Replace(" delete ", "");

                str = str.Replace(" drop ", "");
                str = str.Replace(" truncate ", "");
                str = str.Replace(" create ", "");

                str = str.Replace(" begin ", "");
                str = str.Replace(" end ", "");
                str = str.Replace(" char(", "");

                str = str.Replace(" exec ", "");
                str = str.Replace(" xp_cmd ", "");


                str = str.Replace("<script", "");

            }
            else
            {
                str = "null";
            }
            return str;
        }
    }
}