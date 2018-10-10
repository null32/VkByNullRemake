using NullUtilVK.Enums.SafetyEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK.Categories
{
    public class User
    {
        private VkNet.VkApi VkApi;
        private Action<MessageStatus, string> Log;

        public User(VkNet.VkApi VkApi, Action<MessageStatus, string> Log)
        {
            this.VkApi = VkApi;
            this.Log = Log;
        }

        public VkNet.Model.User Get(long? UserId = null)
        {
            if (UserId == null)
                UserId = VkApi.UserId;

            var User = VkApi.Users.Get((long)UserId, VkNet.Enums.Filters.ProfileFields.All);
            Log(MessageStatus.Response, string.Format(LogStrings.Info.User.Get, UserId, User.FirstName + " " + User.LastName));
            return User;
        }
    }
}
