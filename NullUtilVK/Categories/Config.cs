using Newtonsoft.Json.Linq;
using NullUtilVK.Enums.SafetyEnums;
using NullUtilVK.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK.Categories
{
    public class Config : IDisposable
    {
        public Config(Action<MessageStatus, string> Log)
        {
            this.Log = Log;
            if (File.Exists(Constants.ConfigFilePath))
                Configs = JObject.Parse(File.ReadAllText(Constants.ConfigFilePath));
        }

        #region Dependecies
        Action<MessageStatus, string> Log;
        #endregion

        #region Config
        public void Create(List<ConfigDefault> PossibleValues, List<string> SubCategories)
        {
            if (!File.Exists(Constants.ConfigFilePath))
            {
                JObject json = new JObject();
                foreach (var item in SubCategories)
                {
                    json.Add(item, new JObject());
                    foreach (var item1 in PossibleValues.Where(i => i.SubCategory == item))
                    {
                        (json.Property(item).Value as JObject).Add(item1.Key, JToken.FromObject(item1.DefaultValue));
                    }
                }
                foreach (var item in PossibleValues.Where(c => c.SubCategory == null))
                {
                    json.Add(item.Key, JToken.FromObject(item.DefaultValue));
                }
                StreamWriter streamWr = new StreamWriter(Constants.ConfigFilePath);
                Configs = json;
                streamWr.Write(json.ToString());
                streamWr.Flush();

                streamWr.Close();
                return;
            }

            JObject json1 = new JObject();
            bool needsOverwrite = false;
            try
            {
                json1 = JObject.Parse(File.ReadAllText(Constants.ConfigFilePath));
                foreach (var item in SubCategories)
                {
                    foreach (var item1 in PossibleValues.Where(c => c.SubCategory == item))
                    {
                        if ((json1.Property(item).Value as JObject).Property(item1.Key) == null)
                        {
                            (json1.Property(item).Value as JObject).Add(item1.Key, JToken.FromObject(item1.DefaultValue));
                            needsOverwrite = true;
                        }
                    }
                }

                foreach (var item in PossibleValues.Where(c => c.SubCategory == null))
                {
                    if (json1.Property(item.Key) == null)
                    {
                        json1.Property(item.Key).Value = JToken.FromObject(item.DefaultValue);
                        needsOverwrite = true;
                    }
                }
            }
            catch (Newtonsoft.Json.JsonReaderException)
            {
                File.Delete(Constants.ConfigFilePath);
                Create(PossibleValues, SubCategories);
            }
            if (needsOverwrite)
            {
                StreamWriter sw = new StreamWriter(Constants.ConfigFilePath);
                Configs = json1;
                sw.WriteAsync(json1.ToString());
                sw.Dispose();
            }
             
        }

        public object GetValue(ConfigDefault Item)
        {
            var targJson = Configs;
            if (Item.SubCategory != null)
                targJson = (JObject)targJson.Property(Item.SubCategory).Value;
            if (Item.Key != ConfigDefault.LangFilePath.Key && Item.Key != ConfigDefault.AuthList.Key)
            {
                if (!typeof(System.Collections.IEnumerable).IsAssignableFrom(Item.ValueType) || Item.ValueType == typeof(string))
                    Log(MessageStatus.Info, String.Format(LogStrings.Info.General.GetConfigValue, Item.Key, targJson.Property(Item.Key).Value.ToObject(Item.ValueType)));
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in targJson.Property(Item.Key).Value.ToObject(Item.ValueType) as System.Collections.IEnumerable)
                    {
                        sb.Append(Environment.NewLine);
                        sb.Append(item.ToString());
                    }
                    Log(MessageStatus.Info, String.Format(LogStrings.Info.General.GetConfigValue, Item.Key, sb.ToString()));
                }
            }
            return targJson.Property(Item.Key).Value.ToObject(Item.ValueType);
        }

        public void SetValue(ConfigDefault Item, object Value)
        {
            Log(MessageStatus.Info, string.Format(LogStrings.Info.General.SetConfigValue, Item.Key, Value));
            if (Item.SubCategory != null)
                (Configs.Property(Item.SubCategory).Value as JObject).Property(Item.Key).Value = JToken.FromObject(Value);
            else
                Configs.Property(Item.Key).Value = JToken.FromObject(Value);
        }

        public void WriteConfigToFile()
        {
            var sw = new StreamWriter(Constants.ConfigFilePath);
            sw.Write(Configs.ToString());
            //sw.Flush();
            sw.Close();
        }

        public void ReadConfigFromFile()
        {
            Configs = JObject.Parse(Constants.ConfigFilePath);
        }
        #endregion

        #region Lang
        public string GetLangValue(Localization Key)
        {
            string langFilePath = (string)GetValue(ConfigDefault.LangFilePath);
            try
            {
                JObject json = JObject.Parse(File.ReadAllText(langFilePath));
                return json.Property(Key.Key).Value.ToString();
            }
            catch (Newtonsoft.Json.JsonReaderException)
            {
                Log(MessageStatus.Error, "Lang: Custom lang file is missing field: " + Key.Key + ", using default value");
                return Key.Value;
            }
            catch (System.NullReferenceException)
            {
                Log(MessageStatus.Error, "Lang: Custom lang file is missing field: " + Key.Key + ", using default value");
                return Key.Value;
            }
        }

        public async void CreateDefaultLangFile()
        {
            if (File.Exists(Constants.DefaultLangFile))
            {
                Log(MessageStatus.Info, "Lang file exists");
                return;
            }
            JObject json = new JObject();
            json.Add("COMMENT", "THIS JUST A LANG FILE SAMPLE THAT CAN BE USED FOR CREATING CUSTOM LANG FILES");
            foreach (var item in Localization.GetPossibleValues())
            {
                json.Add(item.Key, item.Value);
            }
            if (!Directory.Exists(Environment.CurrentDirectory + Constants.LangDirSuffix))
                Directory.CreateDirectory(Environment.CurrentDirectory + Constants.LangDirSuffix);
            if (File.Exists(Constants.DefaultLangFile))
                File.Delete(Constants.DefaultLangFile);
            StreamWriter streamWr = new StreamWriter(Constants.DefaultLangFile);
            await streamWr.WriteAsync(json.ToString());
            streamWr.Flush();
            streamWr.Close();
            Log(MessageStatus.Info, "Lang file created");
        }

        public bool IsLangFileOk(string path)
        {
            try
            {
                JObject json = JObject.Parse(File.ReadAllText(path));
                string mda = json.Property(ConfigDefault.Lang.Key).Value.ToString();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Auth instances
        public void AddAuthInst(AuthInstance Auth)
        {
            if (GetAuthInsts().FirstOrDefault(c => c.Name == Auth.Name) != null)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.Auth.InstExists + Auth.Name);
                return;
            }
            (Configs.Property("AuthList").Value as JArray).Add(new JObject(
                new JProperty("Name", Auth.Name),
                new JProperty("EmailOrAccKey", Auth.EmailOrAccKey),
                new JProperty("PassOrId", Auth.PassOrId),
                new JProperty("IsNormal", Auth.IsNormal)
                ));
            this.Log(MessageStatus.Info, LogStrings.Info.Auth.InstAdded + Auth.Name);
        }

        public void DeleteAuthInst(AuthInstance Auth)
        {
            if (GetAuthInsts().FirstOrDefault(c => c.Name == Auth.Name) == null)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.Auth.InstNotExists + Auth.Name);
                return;
            }
            JToken itemToRemove = JToken.FromObject("");
            foreach (var item in (Configs.Property("AuthList").Value as JArray))
            {
                if ((string)item["Name"] == Auth.Name)
                    itemToRemove = item;
            }
            (Configs.Property("AuthList").Value as JArray).Remove(itemToRemove);
            this.Log(MessageStatus.Info, LogStrings.Info.Auth.InstDeleted + Auth.Name);
        }

        public void UpdateAuthInst(AuthInstance Auth)
        {
            if (GetAuthInsts().FirstOrDefault(c => c.Name == Auth.Name) == null)
            {
                this.Log(MessageStatus.Error, LogStrings.Error.Auth.InstNotExists + Auth.Name);
                return;
            }
            foreach (var item in (Configs.Property("AuthList").Value as JArray))
            {
                if ((string)item["Name"] == Auth.Name)
                {
                    item["EmailOrAccKey"] = Auth.EmailOrAccKey;
                    item["PassOrId"] = Auth.PassOrId;
                    item["IsNormal"] = Auth.IsNormal;
                }
            }
            this.Log(MessageStatus.Info, LogStrings.Info.Auth.InstUpdated + Auth.Name);
        }

        public List<AuthInstance> GetAuthInsts()
        {
            List<AuthInstance> Authes = new List<AuthInstance>();
            return GetValue(ConfigDefault.AuthList) as List<AuthInstance>;
        }
        #endregion


        public async Task Save(IDictionary<string, object> Values, Stream Path)
        {
            var json = propsToJObject(Values);
            StreamWriter sw = new StreamWriter(Path);
            await sw.WriteAsync(json.ToString());
            await sw.FlushAsync();
            sw.Close();
            sw.Dispose();
        }

        public Castable Load(string Path)
        {
            return new Castable(JObject.Parse(File.ReadAllText(Path)));
        }

        private JObject propsToJObject(IDictionary<string, object> Values)
        {
            var Result = new JObject();
            try
            {
                foreach (var pair in Values)
                {
                    if (typeof(IDictionary<string, object>).IsAssignableFrom(pair.Value.GetType()))
                    {
                        Result.Add(pair.Key, propsToJObject(pair.Value as IDictionary<string, object>));
                    }
                    else if (typeof(IList<IDictionary<string, object>>).IsAssignableFrom(pair.Value.GetType()))
                    {
                        var Array = new JArray();
                        foreach (var dict in pair.Value as IList<IDictionary<string, object>>)
                        {
                            Array.Add(propsToJObject(dict));
                        }
                        Result.Add(pair.Key, Array);
                    }
                    else
                        if (typeof(bool) == pair.Value.GetType())
                            if ((bool)pair.Value)
                                Result.Add(pair.Key, JToken.FromObject(1));
                            else
                                Result.Add(pair.Key, JToken.FromObject(0));
                        else
                            Result.Add(pair.Key, JToken.FromObject(pair.Value));
                }
            }
            catch (Exception e)
            {
                Log(MessageStatus.Error, e.ToString());
            }

            return Result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            WriteConfigToFile();

            if (disposing)
            {
                
            }
        }

        private JObject Configs;
    }
}
