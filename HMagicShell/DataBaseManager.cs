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
        private static string m_DatabasePath = "\\Database\\webshell.db";
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
            string str = ApplicationData.Current.LocalFolder.Path + m_DatabasePath;
            SqliteConnection sqliteConnection = null;
            SqliteCommand commandQueryAllWebShell = null;
            try
            {
                sqliteConnection = new SqliteConnection(string.Format("Filename={0}", str));
                await sqliteConnection.OpenAsync();

                string strQueryAllWebShellData = "select * from WebShell";

                commandQueryAllWebShell = new SqliteCommand(strQueryAllWebShellData, sqliteConnection);
                var reader = commandQueryAllWebShell.ExecuteReader();
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
            //判断文件夹在不在
            var items = await ApplicationData.Current.LocalFolder.GetFolderAsync("Database");
            if(items == null)
            {
                //如果不在就创建一个
                await ApplicationData.Current.LocalFolder.CreateFolderAsync("Database");
            }

            SqliteConnection sqliteConnection = null;
            SqliteCommand sqliteCommand = null;
            string strDatabasePath = ApplicationData.Current.LocalFolder.Path + m_DatabasePath;
            try
            {
                sqliteConnection = new SqliteConnection(strDatabasePath);
                await sqliteConnection.OpenAsync().ConfigureAwait(true);

                //表初始化
                string strWebShellDataInit = "create table if not exists WebShell(GUID CHAR(38) PRIMARY KEY, URL VARCHAR(2048), PASSWORD VARCHAR(2048), TYPE INTEGER, REMARK VARCHAR(4096),ENCODING INTEGER)";
                sqliteCommand = new SqliteCommand(strWebShellDataInit, sqliteConnection);
                sqliteCommand.ExecuteReader();
                sqliteCommand.Dispose();

                //插入数据
                string strInsert = string.Format("insert into WebShell(GUID,URL,PASSWORD,TYPE,REMARK,ENCODING) VALUES (\'{0}\',\'{1}\',\'{2}\',{3},\'{4}\')",
                    info.Guid.ToString(), info.Url, info.Password, info.Type, info.Remark, info.Encoding.CodePage);
                sqliteCommand = new SqliteCommand(strInsert, sqliteConnection);
                sqliteCommand.ExecuteReader();

            }
            catch (Exception)
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
