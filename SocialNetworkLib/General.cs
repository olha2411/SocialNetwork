using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class General
    {
        public GroupRelationships GroupRelationship;
        public Group group;
        public LoggedUserModel user;
        public LoggedUser RegisteredUsers;       
        public Relation Relation;

        public General(GroupRelationships groupRelationship, Group Group, LoggedUserModel User, LoggedUser registeredUsers, Relation relation)
        {
            GroupRelationship = groupRelationship;
            group = Group;
            user = User;
            RegisteredUsers = registeredUsers;
            Relation = relation;
        }
        //constructor
        public LoggedUserModel LogIn(int IdUser)
        {
            LoggedUserModel NewUser = RegisteredUsers.LogIn(IdUser);
            return NewUser;
        }
        public List<LoggedUserModel> ShowAllUsers(LoggedUserModel loggedUser)  
        {
            List<LoggedUserModel> Users; 
            Users = RegisteredUsers.ShowUsers(loggedUser.Id);
            
            return Users;
        }
        
        public void SendUserInvitation(int IdUser, string name)
        {
            int ReceiverId = RegisteredUsers.GetUserId(name);
            if (ReceiverId != IdUser)
            {
                bool exist = RegisteredUsers.IsRegistered(IdUser);
                if(exist == true)
                {
                    Relation.GetRelationType(IdUser, ReceiverId, name);
                    Relation.AddFriend(ReceiverId, IdUser);
                }
                else
                {
                    throw new Exception("User is not registered");
                }
            }
            else
            {
                throw new Exception("You can't send invitation to yourself");
            }
        }
        
        public List<string> GetUserInvitations(int LoggedUserId)
        {            
            List<string> InvitationSenders = new List<string>();
            List<int> senders = Relation.GetUserInvitations(LoggedUserId);
            foreach(int I in senders)
            {
                InvitationSenders.Add(RegisteredUsers.GetUserName(I));
            }
            return InvitationSenders;
        }
        

        public string AcceptUserInvitation(LoggedUserModel loggedUser, string SenderName)
        {
            string Name = "";
            int SenderId = Relation.AcceptInvitation(SenderName, loggedUser.Id, RegisteredUsers);
            Name = RegisteredUsers.GetUserName(SenderId);
            return Name;
        }
       

        public string DeclineUserInvitation(LoggedUserModel loggedUser, string SenderName)
        {
            string Name = "";
            int SenderId = Relation.DeclineInvitation(SenderName, loggedUser.Id, RegisteredUsers);
            Name = RegisteredUsers.GetUserName(SenderId);
            return Name; ;
        }
               

        public List<string> ShowUserFriend(int UserId)                              
        {            
            List<string> Friends = new List<string>();
            List<RelationModel> friends = Relation.GetUserFriends(UserId);
            foreach(RelationModel R in friends)
            {
                Friends.Add(RegisteredUsers.GetUserName(R.IdSender));
            }
            return Friends;
        }


        public LoggedUserModel LogOut(LoggedUserModel loggedUser)
        {
            loggedUser = RegisteredUsers.LogOut(loggedUser);
            return loggedUser;
        }


        public void AddUserToGroup(string UserName, string GroupName, LoggedUserModel loggedUser)         
        {
            int GroupId = group.GetGroupId(GroupName);
            int UserId = RegisteredUsers.GetUserId(UserName);
            bool IsParticipant;
            bool PossibleMember;
            IsParticipant = GroupRelationship.IsUserParticipant(loggedUser.Id, GroupId);
            if (IsParticipant == true)
            {
                PossibleMember = GroupRelationship.IsUserParticipant(UserId, GroupId);
                if(PossibleMember == true | (GroupRelationship.HasInvitation(UserId, GroupId) == true))
                {
                    throw new Exception("This user already is member or someone else have send invitation");
                }
                else
                {
                    GroupRelationship.SendGroupInvitation(UserId, GroupId, loggedUser.Id);
                }
              
            }
            else
            {
                throw new Exception("You should be participant of this group to add new member");
            }
           
        }


        public Dictionary<string, string> GetGroupInvitations(int UserId)
        {
            Dictionary<string, string> sender = new Dictionary<string, string>();
            Dictionary<int, int> invitations = GroupRelationship.GetUserGroupInvitations(UserId);
            foreach (KeyValuePair<int, int> i in invitations)
            {
                sender.Add(RegisteredUsers.GetUserName(i.Key), group.GetGroupName(i.Value));
            }
            return sender;
        }


        public List<string> GetGroupParticipants(string GroupName)
        {
            int GroupId = group.GetGroupId(GroupName);
            List<GroupRelationshipsModel> participants; 
            List<string> members = new List<string>();
            if (group.IsGroup(GroupId) == true)
            {
                participants = GroupRelationship.GetGroupParticipants(GroupId);
                foreach(GroupRelationshipsModel G in participants)
                {
                    members.Add(RegisteredUsers.GetUserName(G.UserId));
                }
            }
            else throw new Exception("Such group doesn't exist");
            return members;
        }


        public void Accept(string GroupName, int UserId)
        {
            int GroupId = group.GetGroupId(GroupName);
            bool exist = GroupRelationship.InvitationExist(UserId, GroupId);
            if (exist == true)
            {
                GroupRelationship.AcceptGroupInvitation(UserId, GroupId);
            }
            else throw new Exception("You don't have such invitation");
        }

        public void DeclineInvitation(string GroupName, int UserId)
        {
            int GroupId = group.GetGroupId(GroupName);
            bool exist = GroupRelationship.InvitationExist(UserId, GroupId);
            if (exist == true)
            {
                GroupRelationship.DeclineGroupInvitation(GroupId, UserId);
            }
            else throw new Exception("You don't have such invitation");
        }       
        public List<string> GetExistingGroups()
        {
            List<string> groups = new List<string>();
                groups = group.GetAllGroups();
            return groups;
        }
    }
}
