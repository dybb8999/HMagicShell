using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HMagicShell
{
    class DataBaseManager
    {
        private static string m_DatabaseFile = "webshell.db";
        private static string m_DatabasePath = "Database";
        /*
         * 获取所有Webshell信息
         * 如果没有对应的表，会创建一个
         * Webshell基本信息：
         * GUID：每个webshell拥有一个，不重复
         * URL：地址
         * Password：密码
         * Type：指定是什么类型：php5，php7，aspx等
         * Encoding：内容的编码，UTF8 UTF16 GBK等
         * Remark：用户写的备注
         */
        public static async Task<List<CWebShellInfo>> QueryAllWebShell()
        {
            List<CWebShellInfo> infoList = new List<CWebShellInfo>();
            string str = ApplicationData.Current.LocalFolder.Path + "\\" + m_DatabasePath + "\\" + m_DatabaseFile;
            SqliteConnection sqliteConnection = null;
            SqliteCommand commandQueryAllWebShell = null;
            SqliteDataReader reader = null;
            try
            {
                sqliteConnection = new SqliteConnection(string.Format("Filename={0}", str));
                await sqliteConnection.OpenAsync();

                string strQueryAllWebShellData = "select * from WebShell";

                commandQueryAllWebShell = new SqliteCommand(strQueryAllWebShellData, sqliteConnection);
                reader = commandQueryAllWebShell.ExecuteReader();
                while(reader.Read())
                {
                    string strUrl = reader["URL"].ToString();
                    string strPassword = reader["PASSWORD"].ToString();
                    string strType = reader["TYPE"].ToString();
                    string strRemark = reader["REMARK"].ToString();
                    string strEncoding = reader["ENCODING"].ToString();
                    string strGuid = reader["GUID"].ToString();
                    Int64 i64CreateTime = Convert.ToInt64(reader["CREATETIME"]);
                    infoList.Add(new CWebShellInfo(strUrl, strPassword, strRemark, new Guid(strGuid), (WebShellType)Enum.Parse(typeof(WebShellType), strType,true), strEncoding, i64CreateTime));   
                }
            }
            catch (Exception e)
            {
                if((uint)e.HResult != 0x80004005)
                {
                    throw;
                }
            }
            finally
            {
                sqliteConnection?.Dispose();
                commandQueryAllWebShell?.Dispose();
            }

            return infoList;
        }

        public static async Task AddWebShellAsync(CWebShellInfo info)
        {
            try
            {
                //判断文件夹在不在
                var items = await ApplicationData.Current.LocalFolder.GetFolderAsync("Database");
            }
            catch (Exception e)
            {
                if((uint)e.HResult == 0x80070002)
                {
                    await ApplicationData.Current.LocalFolder.CreateFolderAsync("Database");
                }
                else
                {
                    throw;
                }
            }
            

            SqliteConnection sqliteConnection = null;
            SqliteCommand sqliteCommand = null;
            string strDatabasePath = ApplicationData.Current.LocalFolder.Path + "\\" + m_DatabasePath + "\\" + m_DatabaseFile;
            
            try
            {
                sqliteConnection = new SqliteConnection(string.Format("Filename={0}", strDatabasePath));
                sqliteConnection.Open();

                //表初始化
                string strWebShellDataInit = "create table if not exists WebShell(GUID CHAR(38) PRIMARY KEY, URL VARCHAR(2048), PASSWORD VARCHAR(2048), TYPE VARCHAR(32), REMARK VARCHAR(4096),ENCODING VARCHAR(32),CREATETIME INTEGER)";
                sqliteCommand = new SqliteCommand(strWebShellDataInit, sqliteConnection);
                sqliteCommand.ExecuteReader();
                sqliteCommand.Dispose();

                //插入数据
                string strInsert = string.Format("insert into WebShell(GUID,URL,PASSWORD,TYPE,REMARK,ENCODING,CREATETIME) VALUES (\'{0}\',\'{1}\',\'{2}\',\'{3}\',\'{4}\',\'{5}\',{6})",
                    info.Guid.ToString(), info.Url, info.Password, info.Type.ToString(), info.Remark, info.Encoding, DateTime.Now.ToFileTimeUtc());
                sqliteCommand = new SqliteCommand(strInsert, sqliteConnection);
                sqliteCommand.ExecuteReader();

            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                sqliteConnection?.Dispose();
                sqliteCommand?.Dispose();
            }
        }
    }
}
