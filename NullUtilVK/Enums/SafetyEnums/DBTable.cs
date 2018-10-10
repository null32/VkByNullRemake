using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK.Enums.SafetyEnums
{
    public class DBTable
    {
        private DBTable() { }

        private static readonly List<DBTable> RegisteredValues = new List<DBTable>();

        public string Name;
        public TableColumn[] Columns;
        public string InitCommand
        {
            get
            {
                string temp = string.Empty;
                temp += "CREATE TABLE IF NOT EXISTS ";
                temp += Name;
                temp += " (";
                foreach (var column in Columns)
                {
                    temp += " ";
                    temp += column.Name;
                    temp += " ";
                    temp += column.Type.Value;
                    if (column.IsKey)
                    {
                        temp += " ";
                        temp += "PRIMARY KEY";
                    }
                    if (column.NotNull)
                    {
                        temp += " ";
                        temp += "NOT NULL";
                    }
                    if (column.AdditionalArgs != null)
                    {
                        temp += column.AdditionalArgs;
                    }
                    temp += ",";
                }
                temp = temp.Remove(temp.Length - 1);
                temp += " );";
                return temp;
            }
        }

        public static DBTable RegisterValue(string Name, TableColumn[] Columns)
        {
            DBTable temp = new DBTable()
            { 
                Name = Name,
                Columns = Columns
            };
            RegisteredValues.Add(temp);
            return temp;
        }
        public static List<DBTable> GetRegisteredValues()
        {
            return RegisteredValues;
        }

        public static DBTable Audio = DBTable.RegisterValue("audio", new TableColumn[]
            {
                new TableColumn("_id", TableDataType.Integer, IsKey:true, AdditionalArgs:" AUTOINCREMENT"),
                new TableColumn("audio_id", TableDataType.Integer, NotNull:true),
                new TableColumn("owner_id", TableDataType.Integer, NotNull:true),
                new TableColumn("artist", TableDataType.Text),
                new TableColumn("title", TableDataType.Text),
                new TableColumn("duration", TableDataType.Integer, NotNull:true),
                new TableColumn("lyrics_id", TableDataType.Integer)
        
            });
        public static DBTable AudioRate = DBTable.RegisterValue("audio_rate", new TableColumn[]
            {
                new TableColumn("_id", TableDataType.Integer, IsKey:true, AdditionalArgs:" AUTOINCREMENT"),
                new TableColumn("audio_id", TableDataType.Integer, NotNull:true),
                new TableColumn("owner_id", TableDataType.Integer, NotNull:true),
                new TableColumn("bitrate", TableDataType.Integer, NotNull:true)
            });
    }
    
    public class TableColumn
    {
        public TableColumn(string Name, TableDataType Type, bool IsKey = false, bool NotNull = false, string AdditionalArgs = null)
        {
            this.Name = Name;
            this.Type = Type;
            this.AdditionalArgs = AdditionalArgs;
            this.IsKey = IsKey;
            this.NotNull = NotNull;
        }
        public string Name;
        public TableDataType Type;
        public string AdditionalArgs;
        public bool IsKey = false;
        public bool NotNull = false;
    }

    public class TableDataType
    {
        public string Value;
        private TableDataType() { }
        private static TableDataType RegisterPossibleValue(string Value)
        {
            return new TableDataType() { Value = Value };
        }
        public static TableDataType Integer = RegisterPossibleValue("INTEGER");
        public static TableDataType Text = RegisterPossibleValue("TEXT");
        public static TableDataType Blob = RegisterPossibleValue("BLOB");
        public static TableDataType Real = RegisterPossibleValue("REAL");
        public static TableDataType Numeric = RegisterPossibleValue("NUMERIC");
    }
}
