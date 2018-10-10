namespace NullUtilVK.Model
{
    public class AuthInstance
    {
        public AuthInstance()
        {

        }
        public AuthInstance(string Name, string EmailOrAccKey, string PassOrId, bool IsNormal)
        {
            this.Name = Name;
            this.EmailOrAccKey = EmailOrAccKey;
            this.PassOrId = PassOrId;
            this.IsNormal = IsNormal;
        }

        public string Name;
        public string EmailOrAccKey;
        public string PassOrId;
        public bool IsNormal;
    }
}
