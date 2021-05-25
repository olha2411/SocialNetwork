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
        //public List<Friendship> RelationList;
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
        public List<LoggedUserModel> ShowAllUsers(LoggedUserModel loggedUser)  //??
        {
            List<LoggedUserModel> Users; //= new List<LoggedUserModel>();
            Users = RegisteredUsers.ShowUsers(loggedUser.Id);
            /* foreach (LoggedUserModel user in Users)
             {
                 Console.WriteLine($"\t {user.Name}");
             }*/
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
            //RegisteredUsers.GetUserInvitations(RelationList, LoggedUserId);
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
            //RegisteredUsers.Accept(loggedUser, SenderId, RelationList);
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

       /* public void LogOut(LoggedUserModel loggedUser)
        {
            RegisteredUsers.LogOut(loggedUser);
        }*/

        public List<string> ShowUserFriend(int UserId)                              
        {
            //RegisteredUsers.ShowUserFriend(LoggedUser, RelationList);
            List<string> Friends = new List<string>();
            List<RelationModel> friends = Relation.GetUserFriends(UserId);
            foreach(RelationModel R in friends)
            {
                Friends.Add(RegisteredUsers.GetUserName(R.IdSender));
            }
            return Friends;
        }

        public void AddUserToGroup(int UserId, int GroupId, LoggedUserModel loggedUser)         //List<GroupRelationshipsModel> GroupRelationshi
        {
            bool Is = false;
            Is = GroupRelationship.IsUserParticipant(UserId, GroupId);
            if (Is == true)
            {
                GroupRelationship.SendGroupInvitation(UserId, GroupId, loggedUser.Id);
            }
            else
            {
                throw new Exception("You should be participant of this group to add new member");
            }
            RegisteredUsers.ShowUsers(UserId);
        }

        public List<GroupRelationshipsModel> GetGroupParticipants(int GroupId)
        {
            List<GroupRelationshipsModel> participants; //= new List<GroupRelationshipsModel>();
            if (group.IsGroup(GroupId) == true)
            {
                participants = GroupRelationship.GetGroupParticipants(GroupId);

            }
            else throw new Exception("Such group doesn't exist");
            return participants;
        }

        public void Accept(int GroupId, int UserId)
        {
            GroupRelationship.AcceptGroupInvitation(UserId, GroupId);
        }

        public void DeclineInvitation(int GroupId, int UserId)
        {
            GroupRelationship.DeclineGroupInvitation(GroupId, UserId);
        }

        public void DeleteGroup()
        {

        }

    }
}
