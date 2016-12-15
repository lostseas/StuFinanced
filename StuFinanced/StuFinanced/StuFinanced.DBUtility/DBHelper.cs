using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace StuFinanced.DBUtility
{
    /// <summary>
    /// 数据库连接类
    /// </summary>
    public class DBHelper
    {
        #region ============================私有方法===========================
        /// <summary>
        /// 预处理SqlCommand操作，数据库连接、事务、操作
        /// </summary>
        /// <param name="cmd">要处理的SqlCommand操作</param>
        /// <param name="trans">一个有效的事务或是NULL值</param>
        /// <param name="conn">一个有效的数据库连接对象</param>
        /// <param name="cmdType">CommandType</param>
        /// <param name="cmdText">T-SQL命令文本</param>
        /// <param name="parameters">和命令相关的SqlParameter参数数组，没有为NULL</param>
        private static void PrepareCmd(SqlCommand cmd, SqlTransaction trans, SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] parameters)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);

            }
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
        }
        #endregion==========================私有方法End======================

        #region ============================数据库连接=========================
        /// <summary>
        /// 数据库连接字符串（web.config配置）
        /// </summary>
        private static string strConn = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        /// <summary>
        /// 打开数据库连接对象
        /// </summary>
        /// <returns></returns>
        private static SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            return conn;
        }
        /// <summary>
        /// 关闭数据库连接对象
        /// </summary>
        /// <param name="conn"></param>
        private static void CloseConnection(SqlConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {


            }
        }
        #endregion=======================数据库连接End=====================

        #region =====================执行简单的SQL语句=====================
        #region ExecuteNonQuery方法 返回受影响的行数

        /// <summary>
        /// 执行一条带可变参数的SQL语句,返回受影响的行数
        /// </summary>
        /// <remarks> 
        /// 示例:  
        ///  int result = ExecuteNonQuery(strSQL); 
        ///  int result = ExecuteNonQuery(strSQL，new SqlParameter{1}，new SqlParameter{2}，...,new SqlParameter{n}); 
        /// </remarks> 
        /// <param name="StringSQL">SQL语句</param>
        /// <param name="parameters">长度可变（params）参数列表，最短可以为0</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string strSql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                return ExecuteNonQuery(conn, strSql, parameters);
            }
        }
        /// <summary>
        /// 执行一条带可变参数的SQL语句,返回受影响的行数（带SqlConnection）
        /// </summary>
        /// <remarks> 
        /// 示例:  
        ///  int result = ExecuteNonQuery(SqlConnection, strSQL); 
        ///  int result = ExecuteNonQuery(SqlConnection, strSQL，new SqlParameter{1}，new SqlParameter{2}，...,new SqlParameter{n}); 
        /// </remarks> 
        /// <param name="conn">数据库连接SqlConnection</param>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="parameters">长度可变（params）的SqlParameter参数列表，最短可以为0</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlConnection conn, string strSql, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                PrepareCmd(cmd, null, conn, CommandType.Text, strSql, parameters);
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion ExecuteNonQuery方法End
        #region ExecuteScalar方法 返回查询结果集的第一行第一列
        /// <summary>
        /// 执行一条带可变参数的SQL语句,返回查询结果集的第一行第一列
        /// </summary>
        /// <remarks> 
        /// 示例:  
        ///  object result = ExecuteScalar(strSQL); 
        ///  object result = ExecuteScalar(strSQL，new SqlParameter{1}，new SqlParameter{2}，...,new SqlParameter{n}); 
        /// </remarks> 
        /// <param name="strSQL">SQL语句</param>
        /// <param name="parameters">长度可变（params）的SqlParameter参数列表，最短可以为0</param>
        /// <returns></returns>
        public static object ExecuteScalar(string strSQL, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                return ExecuteScalar(conn, strSQL, parameters);
            }
        }

        /// <summary>
        /// 执行一条带可变参数的SQL语句,返回查询结果集的第一行第一列(带SqlConnection)
        /// </summary>
        /// <remarks> 
        /// 示例:  
        ///  object result = ExecuteScalar(SqlConnection, strSQL); 
        ///  object result = ExecuteScalar(SqlConnection, strSQL，new SqlParameter{1}，new SqlParameter{2}，...,new SqlParameter{n});
        /// </remarks> 
        /// <param name="conn">数据库连接SqlConnection</param>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="parameters">长度可变（params）的SqlParameter参数列表，最短可以为0</param>
        /// <returns></returns>
        public static object ExecuteScalar(SqlConnection conn, string strSQL, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                PrepareCmd(cmd, null, conn, CommandType.Text, strSQL, parameters);
                object result = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return result;
            }
        }
        #endregion ExecuteScalar方法End

        #region ExecuteDataSet 少量数据读取,返回DataSet
        /// <summary>
        /// 执行一条带可变参数的SQL语句,返回DataSet
        /// </summary>
        /// <remarks> 
        /// 示例:  
        ///  object result = ExecuteDataSet(strSQL); 
        ///  object result = ExecuteDataSet(strSQL，new SqlParameter{1}，new SqlParameter{2}，...,new SqlParameter{n}); 
        /// </remarks> 
        /// <param name="strSQL">SQL语句</param>
        /// <param name="parameters">长度可变（params）的SqlParameter参数列表，最短可以为0</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string strSQL, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                return ExecuteDataSet(conn, strSQL, parameters);
            }
        }

        /// <summary>
        /// 执行一条带可变参数的SQL语句,返回DataSet(带SqlConnection)
        /// </summary>
        /// <remarks> 
        /// 示例:  
        ///  object result = ExecuteDataSet(SqlConnection, strSQL); 
        ///  object result = ExecuteDataSet(SqlConnection, strSQL，new SqlParameter{1}，new SqlParameter{2}，...,new SqlParameter{n}); 
        /// </remarks> 
        /// <param name="conn">数据库连接SqlConnection</param>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="parameters">长度可变（params）的SqlParameter参数列表，最短可以为0</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(SqlConnection conn, string strSQL, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                PrepareCmd(cmd, null, conn, CommandType.Text, strSQL, parameters);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
        #endregion ExecuteDataTable 少量数据读取End

        #region ExecuteReader 大量数据读取,返回SqlDataReader
        /// <summary>
        /// 执行一条带可变参数的SQL语句,返回SqlDataReader
        /// </summary>
        /// <remarks> 
        /// 示例:  
        ///  object result = ExecuteReader(SstrSQL); 
        ///  object result = ExecuteReader(strSQL，new SqlParameter{1}，new SqlParameter{2}，...,new SqlParameter{n}); 
        /// </remarks> 
        /// <param name="strSQL"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string strSQL, params SqlParameter[] parameters)
        {
            SqlConnection conn = OpenConnection();
            using (SqlCommand cmd = new SqlCommand())
            {
                PrepareCmd(cmd, null, conn, CommandType.Text, strSQL, parameters);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
        /// <summary>
        /// 执行一条带可变参数的SQL语句,返回SqlDataReader(带SqlConnection)
        /// </summary>
        /// <remarks> 
        /// 示例:  
        ///  object result = ExecuteReader(SqlConnection, strSQL); 
        ///  object result = ExecuteReader(SqlConnection, strSQL，new SqlParameter{1}，new SqlParameter{2}，...,new SqlParameter{n}); 
        /// </remarks> 
        /// <param name="strSQL"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(SqlConnection conn, string strSQL, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                PrepareCmd(cmd, null, conn, CommandType.Text, strSQL, parameters);
                SqlDataReader read = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return read;
            }
        }
        #endregion ExecuteReader 大量数据读取End

        #endregion =====================执行简单的SQL语句End=====================

        #region ======================执行多条SQL语句（事务）====================
        /// <summary>
        /// 执行多条SQL语句，使用数据库事物（Hashtable）
        /// </summary>
        /// <param name="listSQL">T-SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static bool ExecuteSqlTran(Hashtable listSQL)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        foreach (DictionaryEntry deSql in listSQL)
                        {
                            PrepareCmd(cmd, trans, conn, CommandType.Text, deSql.Key.ToString(), (SqlParameter[])deSql.Value);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 执行多条SQL语句，使用数据库事物（自定义的CommandInfo类）
        /// </summary>
        /// <param name="CommandInfoList">CommandInfo（自定义的类）列表，cmdInfo.CommandText, cmdInfo.Parameters</param>
        public static bool ExecuteSqlTran(List<CommandInfo> CommandInfoList)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        foreach (CommandInfo cmdInfo in CommandInfoList)
                        {
                            PrepareCmd(cmd, trans, conn, CommandType.Text, cmdInfo.CommandText, cmdInfo.Parameters);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();

                        return false;
                    }
                }
            }

            return true;
        }


        #endregion =================执行多条SQL语句（事务）End===================

        #region ==========================执行存储过程===========================
        /// <summary>
        /// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteProcReader(string procName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    PrepareCmd(cmd, null, conn, CommandType.StoredProcedure, procName, parameters);
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }

        }
        /// <summary>
        /// 执行存储过程，返回DataSet
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static DataSet ExecuteProcDataSet(string procName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    PrepareCmd(cmd, null, conn, CommandType.StoredProcedure, procName, parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        return ds;
                    }
                }
            }

        }
        /// <summary>
        /// 执行存储过程，返回受影响的行数
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static int ExecuteProcNonQuery(string procName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    PrepareCmd(cmd, null, conn, CommandType.StoredProcedure, procName, parameters);
                    return cmd.ExecuteNonQuery();
                }
            }

        }
        #endregion ======================执行存储过程End=========================

    }
}
