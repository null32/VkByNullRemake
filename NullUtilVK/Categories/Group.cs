using NullUtilVK.Enums.SafetyEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK.Categories
{
    public class Group
    {
        private VkNet.VkApi VkApi;
        private Action<MessageStatus, string> Log;

        public Group(VkNet.VkApi VkApi, Action<MessageStatus, string> Log)
        {
            this.VkApi = VkApi;
            this.Log = Log;
        }

        public VkNet.Model.Group GetById(long GroupId)
        {
            var Group = VkApi.Groups.GetById(Convert.ToUInt32(GroupId), VkNet.Enums.Filters.GroupsFields.All);
            Log(MessageStatus.Response, string.Format(LogStrings.Info.Group.Get, GroupId, Group.Name));
            return Group;
        }
    }
}
