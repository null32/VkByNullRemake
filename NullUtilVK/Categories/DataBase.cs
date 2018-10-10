using NullUtilVK.Enums.SafetyEnums;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace NullUtilVK.Categories
{
    public class DataBase : IDisposable
    {
        public DataBase(Action<MessageStatus, string> Log, Func<Localization, string> GetLangValue)
        {
            SQLConnection = new SQLiteConnection("Data Source=" + Constants.DBFilePath + ";Version=3;");
            this.Log = Log;
            this.GetLangValue = GetLangValue;
        }

        #region Dependencies
        Action<MessageStatus, string> Log;
        Func<Localization, string> GetLangValue;
        #endregion

        public async void Create()
        {
            if (!System.IO.File.Exists(Constants.DBFilePath))
                SQLiteConnection.CreateFile(Constants.DBFilePath);
            SQLConnection.Open();
            SQLiteCommand Comm;
            foreach (var table in DBTable.GetRegisteredValues())
            {
                Comm = new SQLiteCommand(table.InitCommand, SQLConnection);
                await Comm.ExecuteNonQueryAsync();
            }

            Log(MessageStatus.Info, LogStrings.Info.DB.Created);
        }

        public async void Insert(DBTable Table, params object[] Values)
        {
            string Request = "INSERT OR REPLACE INTO ";
            Request += Table.Name;
            Request += " ( ";
            foreach (var column in Table.Columns)
            {
                Request += column.Name;
                Request += ", ";
            }
            Request = Request.Remove(Request.Length - 2);
            Request += " ) VALUES ((SELECT ";
            Request += Table.Columns[0].Name;
            Request += " FROM ";
            Request += Table.Name;
            Request += " WHERE ";
            Request += Table.Columns[1].Name;
            Request += " == '";
            Request += Values[0];
            Request += "' AND ";
            Request += Table.Columns[2].Name;
            Request += " == '";
            Request += Values[1];
            Request += "'), ";
            foreach (var value in Values)
            {
                Request += "'";
                if (value is string)
                {
                    string val = string.Join("&apos", (value as string).Split('\''));
                    Request += val;
                }
                else
                    Request += value;
                Request += "', ";
            }
            Request = Request.Remove(Request.Length - 2);
            Request += " );";
            this.Log(MessageStatus.Info, LogStrings.Info.DB.Command + Request);
            SQLiteCommand command = new SQLiteCommand(Request, SQLConnection);
            await command.ExecuteNonQueryAsync();
        }

        public List<object> Select(DBTable Table, int Count = 100, int Offset = 0)
        {
            string Request = "SELECT * FROM ";
            Request += Table.Name;
            Request += " LIMIT " + Count;
            Request += " OFFSET " + Offset;
            Request += ";";
            this.Log(MessageStatus.Info, LogStrings.Info.DB.Command + Request);
            SQLiteCommand Comm = new SQLiteCommand(Request, SQLConnection);
            SQLiteDataReader Reader = Comm.ExecuteReader();
            List<object> returnList = new List<object>();
            object[] Item;
            while (Reader.Read())
            {
                Item = new object[Table.Columns.Length];
                for (int i = 0; i < Table.Columns.Length; i++)
                {
                    Item[i] = Reader.GetValue(i);
                }
                returnList.Add(Item);
            }
            return returnList;
        }

        public List<object> Select(DBTable Table, string Predicate)
        {
            string Request = "SELECT * FROM ";
            Request += Table.Name;
            Request += " WHERE ";
            Request += Predicate;
            Request += ";";
            this.Log(MessageStatus.Info, LogStrings.Info.DB.Command + Request);
            SQLiteCommand Comm = new SQLiteCommand(Request, SQLConnection);
            SQLiteDataReader Reader = Comm.ExecuteReader();
            List<object> returnList = new List<object>();
            object[] Item;
            while (Reader.Read())
            {
                Item = new object[Table.Columns.Length];
                for (int i = 0; i < Table.Columns.Length; i++)
                {
                    Item[i] = Reader.GetValue(i);
                }
                returnList.Add(Item);
            }
            return returnList;
        }

        public int Size(DBTable Table)
        {
            string Request = "SELECT COUNT(";
            Request += Table.Columns[0].Name;
            Request += ") FROM ";
            Request += Table.Name;
            Request += ";";
            this.Log(MessageStatus.Info, LogStrings.Info.DB.Command + Request);
            SQLiteCommand Comm = new SQLiteCommand(Request, SQLConnection);
            SQLiteDataReader Reader = Comm.ExecuteReader();
            Reader.Read();
            return Reader.GetInt32(0);
        }

        public async void Remove(DBTable Table, int Index)
        {
            string Request = "DELETE FROM ";
            Request += Table.Name;
            Request += " WHERE ";
            Request += Table.Columns[0].Name;
            Request += " == ";
            Request += Index.ToString();
            Request += ";";
            this.Log(MessageStatus.Info, LogStrings.Info.DB.Command + Request);
            SQLiteCommand Comm = new SQLiteCommand(Request, SQLConnection);
            await Comm.ExecuteNonQueryAsync();
        }

        SQLiteConnection SQLConnection;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (SQLConnection != null)
                    SQLConnection.Dispose();
            }
        }
    }
}
