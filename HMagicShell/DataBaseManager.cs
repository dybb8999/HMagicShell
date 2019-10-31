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
        /*
         * 获取所有Webshell信息
         * 如果没有对应的表，会创建一个
         * Webshell基本信息：
         * GUID：每个webshell拥有一个，不重复
         * URL：地址
         * Password：密码
         * Type：指定是什么类型：php5，php7，aspx等
         * Remark：用户写的备注
         * 
         */
        public static void QueryAllWebShell()
        {
            string str = ApplicationData.Current.LocalFolder.Path + "\\webshell.db";
            using (SqliteConnection sqliteConnection = new SqliteConnection(string.Format("Filename={0}", str)))
            {

                sqliteConnection.Open();

                //表初始化
                string strWebShellDataInit = "create table if not exists WebShell(GUID CHAR(38) PRIMARY KEY, URL VARCHAR(2048), PASSWORD VARCHAR(2048), TYPE INTEGER, REMARK VARCHAR(4096))";
                using (SqliteCommand sqliteInitCommand = new SqliteCommand(strWebShellDataInit, sqliteConnection))
                {
                    sqliteInitCommand.ExecuteReader();
                }

                string strQueryAllWebShellData = "select * from WebShell";
                using (SqliteCommand commandQueryAllWebShell = new SqliteCommand(strQueryAllWebShellData, sqliteConnection))
                {
                    var reader = commandQueryAllWebShell.ExecuteReader();
                }
            }
        }

        public static void AddWebShell()
        {

        }
    }
}
