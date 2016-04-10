using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SQLite;
using System.IO;


namespace MyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DataService.svc or DataService.svc.cs at the Solution Explorer and start debugging.
    public class DataService : IDataService
    {
        SQLiteConnection sql = new SQLiteConnection("DataSource = mydb.sqlite;Version=3");
        string adminLogin = "admin";
        string adminPassword = "admin";

        public string login(string name, string password, string compName)
        {
            setConnection();
            SQLiteCommand sc = new SQLiteCommand("SELECT COUNT(*) FROM USER WHERE name = '" + name + "' AND password = '" + password + "';", sql);
            if (Convert.ToInt32(sc.ExecuteScalar()) > 0)
            {
                sc = new SQLiteCommand("SELECT COUNT(*) FROM COMPUTER WHERE name = '" + compName + "';", sql);
                if (Convert.ToInt32(sc.ExecuteScalar()) == 0)
                {
                    sc = new SQLiteCommand("INSERT INTO COMPUTER VALUES(NULL, '" + compName + "');", sql);
                    sc.ExecuteNonQuery();
                }
                sc = new SQLiteCommand(String.Format("SELECT COUNT(*) FROM USER WHERE name = '{0}' AND password = '{1}' AND admin = 1;"), sql);
                if (Convert.ToInt32(sc.ExecuteScalar()) > 0)
                    return "admin";
                else
                    return "user";
            }
            else
                return "denied";
        }

        public void setConnection()
        {
            if (!File.Exists("mydb.sqlite"))
                SQLiteConnection.CreateFile("mydb.sqlite");//файл хранится в папке с IIS Express
            sql.Open();
            SQLiteCommand sc = new SQLiteCommand("CREATE TABLE IF NOT EXISTS COMPUTER(id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT);", sql);
            sc.ExecuteNonQuery();
            sc = new SQLiteCommand("CREATE TABLE IF NOT EXISTS USER(id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, password TEXT, admin INTEGER);", sql);
            sc.ExecuteNonQuery();
            sc = new SQLiteCommand("INSERT INTO USER VALUES(NULL, '" + adminLogin + "', '" + adminPassword + "', '" + 1 + "');", sql);
            sc = new SQLiteCommand("CREATE TABLE IF NOT EXISTS FILE(id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, path TEXT, time INTEGER, type TEXT, computerID INTEGER, userID INTEGER, " +
                "CONSTRAINT fk_computer " +
                "FOREIGN KEY (computerID) " +
                "REFERENCES COMPUTER(id), " +
                "CONSTRAINT fk_user " +
                "FOREIGN KEY (userID) " +
                "REFERENCES USER(id))" +
                ";", sql);
            sc.ExecuteNonQuery();
            sc = new SQLiteCommand("CREATE TABLE IF NOT EXISTS TRAFFIC(id INTEGER PRIMARY KEY AUTOINCREMENT, URL TEXT, time INTEGER, computerID INTEGER, userID INTEGER, " +
                "CONSTRAINT fk_computer " +
                "FOREIGN KEY (computerID) " +
                "REFERENCES COMPUTER(id), " +
                "CONSTRAINT fk_user " +
                "FOREIGN KEY (userID) " +
                "REFERENCES USER(id))" +
                ";", sql);
            sc.ExecuteNonQuery();
            sql.Close();
        }

        public void saveFileDataToDB(string name, string path, int time, string type, int compID, int userID)
        {
            setConnection();
            SQLiteCommand sc = new SQLiteCommand(String.Format("INSERT INTO FILE VALUES( NULL, '{0}', '{1}', {2}, '{3}', {4}, {5});", name, path, time, type, compID, userID), sql);
            sql.Open();
            sc.ExecuteNonQuery();
            sql.Close();
        }

        public void saveTrafficDataToDB(string URL, int time, int compID, int userID)
        {
            setConnection();
            //SQLiteCommand sc = new SQLiteCommand("INSERT INTO FILE VALUES( NULL, '{0}','{1}',{2},'{3}',{4},{5});",name,path,type, sql);
            SQLiteCommand sc = new SQLiteCommand("INSERT INTO TRAFFIC VALUES( NULL, '" + URL + "'," + time + "," + compID + "," + userID + ");", sql);
            sql.Open();
            sc.ExecuteNonQuery();
            sql.Close();
        }
    }
}
