using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class GroupRelationships
    {
        List<GroupRelationshipsModel> GroupRelationship;

        public GroupRelationships(List<GroupRelationshipsModel> GroupsRelation)
        {
            GroupRelationship = GroupsRelation;
        }
        public void AddNew(int GroupId, int UserId, string Role, int SenderId)
        {
            GroupRelationship.Add(new GroupRelationshipsModel(GroupId, UserId, Role, SenderId));

        }

        public List<GroupRelationshipsModel> GetUserGroup(int UserId)
        {
            List<GroupRelationshipsModel> UserGroups = new List<GroupRelationshipsModel>();
            foreach (GroupRelationshipsModel G in GroupRelationship)
            {
                if (G.UserId == UserId)
                {
                    UserGroups.Add(new GroupRelationshipsModel(G.GroupId, UserId, G.Role, G.SenderId));
                }
            }
            return UserGroups;
        }

        public List<GroupRelationshipsModel> GetGroupParticipants(int GroupId)
        {
            List<GroupRelationshipsModel> participants = new List<GroupRelationshipsModel>();
            foreach(GroupRelationshipsModel G in GroupRelationship)
            {
                if(G.GroupId == GroupId)
                {
                    participants.Add(new GroupRelationshipsModel(GroupId, G.UserId, G.Role, G.SenderId));
                }
            }
            return participants;
        }

        public bool IsUserParticipant(int UserId, int GroupId)
        {
            bool Is = false;
            foreach(GroupRelationshipsModel G in GroupRelationship)
            {
                if(G.UserId == UserId && G.GroupId == GroupId)
                {
                    Is = true;
                }
            }
            return Is;
        }
        public bool HasInvitation(int UserId, int GroupId)
        {
            bool Is = false;
            foreach (GroupRelationshipsModel G in GroupRelationship)
            {
                if (G.UserId == UserId && G.GroupId == GroupId && G.Role == "0")
                {
                    Is = true;
                }
            }
            return Is;
        }
        public void SendGroupInvitation(int UserId, int GroupId, int LoggedUserId)
        {
            GroupRelationship.Add(new GroupRelationshipsModel(GroupId, UserId, "0", LoggedUserId));
        }

        public void AcceptGroupInvitation(int UserId, int GroupId)
        {
            foreach(GroupRelationshipsModel G in GroupRelationship)
            {
                if(G.GroupId == GroupId && G.UserId == UserId)
                {
                    G.Role = "member";
                }
            }
        }
          
        public bool InvitationExist(int UserId, int GroupId)
        {
            bool exist = false;
            foreach(GroupRelationshipsModel G in GroupRelationship)
            {
                if(G.GroupId == GroupId && G.UserId == UserId && G.Role == "0")
                {
                    exist = true;
                }
            }
            return exist;
        }

        public Dictionary<int, int> GetUserGroupInvitations(int UserId)
        {
            Dictionary<int, int> invitations = new Dictionary<int, int>();            
            foreach (GroupRelationshipsModel G in GroupRelationship)
            {
                if (G.Role == "0" && G.UserId == UserId)
                {
                    invitations.Add(G.SenderId, G.GroupId);
                }
            }
            return invitations;
        }

        public void DeclineGroupInvitation(int GroupId, int UserId)
        {
            GroupRelationshipsModel user = new GroupRelationshipsModel();
            foreach(GroupRelationshipsModel G in GroupRelationship)
            {
                if(G.GroupId == GroupId && G.UserId == UserId)
                {
                    user = new GroupRelationshipsModel(GroupId, UserId, G.Role, G.SenderId);
                }
            }
            GroupRelationship.Remove(new GroupRelationshipsModel(user.GroupId, user.UserId, user.Role, user.SenderId));

        }

    }
}
