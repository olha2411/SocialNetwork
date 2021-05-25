using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class GroupRelationshipsModel
    {
        public int GroupId { get; }
        public int UserId { get; }
        public string Role { get; set; }
        public int SenderId { get; }
        public GroupRelationshipsModel(int groupId, int userId, string role, int senderId)
        {
            GroupId = groupId;
            UserId = userId;
            Role = role;
            SenderId = senderId;

        }
        public GroupRelationshipsModel() { }
    }
}
