using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class GroupModel
    {        

        public int GroupId { get;  }
        public int OwnerId { get; }
        public string GroupName { get; }
        public GroupModel(int groupId, int ownerId, string groupName)
        {
            GroupId = groupId;
            OwnerId = ownerId;
            GroupName = groupName;
        }
        public GroupModel() { }
    }


    
}
