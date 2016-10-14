using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace ServiceProvider
{
    public class DbProvider
    {
        protected string DbConnection;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DBDirectoryInfo"></param>
        /// <param name="InputFile"></param>
        public DbProvider(string DBDirectoryInfo, string InputFile)
        {
            var appDatapath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DBDirectoryInfo);
            string sourcefile = Path.Combine(appDatapath, InputFile);
            if (!File.Exists(sourcefile))
                CreateDB(DBDirectoryInfo, InputFile);

            DbConnection = $"Data Source={sourcefile}";


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionOPT"></param>
        public DbProvider(Dictionary<String, String> connectionOPT)
        {
            String str = string.Empty;

            foreach (KeyValuePair<String, String> row in connectionOPT)
            {
                str += $"{row.Key}={row.Value}";
            }
            str = str.Trim().Substring(0, str.Length - 1);
            DbConnection = str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection(DbConnection);
                cnn.Open();
                SQLiteCommand cmd = new SQLiteCommand(cnn);
                cmd.CommandText = sql;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                rdr.Close();
                cnn.Close();
            }
            catch
            {

            }
            return dt;
        }

        public int ExecuteNonQuery(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(DbConnection);
            cnn.Open();
            SQLiteCommand cmd = new SQLiteCommand(cnn);
            cmd.CommandText = sql;
            int rowsupdated = cmd.ExecuteNonQuery();
            return rowsupdated;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string ExecuteScalar(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(DbConnection);
            cnn.Open();
            SQLiteCommand cmd = new SQLiteCommand(cnn);
            cmd.CommandText = sql;
            object value = cmd.ExecuteScalar();
            cnn.Close();
            if (value != null)
            {
                return value.ToString();
            }
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="data"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool Update(string tablename, Dictionary<string, string> data, string where)
        {
            string val = string.Empty;
            bool returncode = true;
            if (data.Count >= 1)
            {
                foreach (KeyValuePair<string, string> vals in data)
                {
                    val += $"{vals.Key.ToString()} = '{vals.Value.ToString()}'";
                }
                val = val.Substring(0, val.Length - 1);
            }
            try
            {
                this.ExecuteNonQuery($"Update {tablename} set {val} where {where}");
            }
            catch (Exception ex)
            {
                returncode = false;
            }
            return returncode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool Delete(string tablename, string where)
        {
            bool returncode = true;

            try
            {
                this.ExecuteNonQuery($"delete from {tablename} where {where}");
            }
            catch (Exception ex)
            {
                return returncode = false;
            }
            return returncode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Insert(string tablename, Dictionary<string, string> data)
        {
            string col = string.Empty;
            string values = string.Empty;
            bool returncode = true;
            foreach (KeyValuePair<string, string> val in data)
            {
                col += $"{val.Key.ToString()}";
                values += $"{val.Value}";
            }
            col = col.Substring(0, col.Length - 1);
            values = values.Substring(0, values.Length - 1);
            try
            {
                this.ExecuteNonQuery($"Insert into {tablename}({col}) VALUES ({values})");
            }
            catch (Exception ex)
            {
                returncode = false;
            }
            return returncode;
        }
        /// <summary>
        /// Create DB if not exits
        /// </summary>
        /// <param name="path"></param>
        /// <param name="db"></param>
        public void CreateDB(string path, string db)
        {
            var appDatapath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), path);
            if (Directory.Exists(appDatapath))
            {
                SQLiteConnection.CreateFile(appDatapath + "\\" + db);
                
            }
        }
        /// <summary>
        /// Check tables if not exists
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public bool IsTableExists(string tablename)
        {
            int count = 0;
            if (DbConnection == default(string))
                return false;
            using(SQLiteConnection cnn = new SQLiteConnection(DbConnection))
            {
                try
                {
                    cnn.Open();
                    if(tablename == null || cnn.State != ConnectionState.Open)
                    {
                        return false;
                    }
                    string sql = $"Select count(*) from sqlite_master where type = 'table' and name = '{tablename}'";
                    count = int.Parse(ExecuteScalar(sql));
                }
                finally
                {
                    if ((cnn != null) && (cnn.State != ConnectionState.Open))
                        cnn.Clone();
                }
            }
            return count > 0;
        }
    }
}
