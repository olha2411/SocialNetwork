using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class LoggedUser
    {
        List<LoggedUserModel> RegisteredUsers;

        public LoggedUser(List<LoggedUserModel> registeredusers)
        {
            RegisteredUsers = registeredusers;
        }

        public LoggedUserModel LogIn( int IdNewUser)
        {
            LoggedUserModel loggedUser = new LoggedUserModel() { Id = 0, Name = "Name" };
            bool contain = false;
            foreach (User U in RegisteredUsers)
            {
                if (U.Id == IdNewUser)
                {
                    loggedUser = new LoggedUserModel() { Id = IdNewUser, Name = U.Name };
                    contain = true;
                }
            }
            if (contain == false)
            {
                throw new ArgumentException("User is not registered");
            }
            return loggedUser;
        }
        public List<LoggedUserModel> ShowUsers(int LoggedUserId)
        {
            List<LoggedUserModel> Users = new List<LoggedUserModel>();

            foreach (LoggedUserModel U in RegisteredUsers)
            {
                if (U.Id != LoggedUserId)
                {
                    Users.Add(new LoggedUserModel() { Id = U.Id, Name = U.Name });
                }
            }

            return Users;
        }


        public bool IsRegistered(int UserId)
        {
            bool exist = false;

            foreach (LoggedUserModel u in RegisteredUsers)
            {
                if (u.Id == UserId)
                {
                    exist = true;
                }
            }
            return exist;
        }
        public string GetUserName(int UserId)
        {
            string name = "";
            foreach (LoggedUserModel u in RegisteredUsers)
            {
                if (u.Id == UserId)
                {
                    name = u.Name;
                }
            }
            return name;
        }
        public int GetUserId(string UserName)
        {
            int UserId = 0;
            foreach (LoggedUserModel U in RegisteredUsers)
            {
                if (U.Name == UserName)
                {
                    UserId = U.Id;
                }
            }
            return UserId;
        }

    }








   /* public class LoggedUser 
    {
        List<LoggedUserModel> RegisteredUsers = new List<LoggedUserModel>();

        *//*public LoggedUser(List<LoggedUserModel> registeredUsers)
        {
            RegisteredUsers = registeredUsers;
        }*//*
        public LoggedUser()   { }

        public  List<LoggedUserModel> ShowUsers(int LoggedUserId)
        {
            List<LoggedUserModel> Users = new List<LoggedUserModel>();

            foreach (LoggedUserModel U in RegisteredUsers)
            {
                if (U.Id != LoggedUserId)
                {
                    Users.Add(new LoggedUserModel() { Id = U.Id, Name = U.Name });
                }
            }

            return Users;
        }


        public string AddFriend(List<Friendship> RelationList, int IdUser, int IdReciver)
        {
            //bool exist = false;
            string Friend = FindUserName(IdReciver);
            //foreach (LoggedUserModel user in RegisteredUsers)
            //{
               // if (user.Id == IdReciver)
               // {
                    Relations relations = new Relations(RelationList);
                    relations.GetRelationType(IdUser, IdReciver, Friend);
                   // exist = true;
                    RelationList.Add(new Friendship() { IdSender = IdUser, IdRecipient = IdReciver, RelationsStatus = "pending" });
                   // Friend = user.Name;
               // }
           // }
            *//*if (exist == false)
            {
                throw new ArgumentNullException("This user is not registered");
            }*//*
            return Friend;

        }
       *//* public string AddFriend(List<Friendship> RelationList, int IdUser, int IdReciver)
        {
            //bool exist = false;
            bool exist = IsRegistered(IdUser);

            if (exist == false)
            {
                throw new ArgumentNullException("This user is not registered");
            }
        }*//*

        public bool IsRegistered(int UserId)
        {
            bool exist = false;           
           
            foreach(LoggedUserModel u in RegisteredUsers)
            {
                if(u.Id == UserId)
                {
                    exist = true;
                }
            }
            return exist;
        }
        public string FindUserName(int UserId)
        {
            string name = "";
            foreach(LoggedUserModel u in RegisteredUsers){
                if(u.Id == UserId)
                {
                    name = u.Name;
                }
            }
            return name;
        }
        public List<Friendship> GetUserInvitations(List<Friendship> RelationList, int LoggedUserId)
        {

            List<Friendship> UserInvitations = new List<Friendship>();
            
                foreach (Friendship user in RelationList)
                {
                    if ((user.IdRecipient == LoggedUserId && user.GetStatusText() != "declined" && user.IsStatusFriends() == false))// user.RelationsStatus != "friend"
                    {
                        UserInvitations.Add(new Friendship { IdSender = user.IdSender, RelationsStatus = "invitation to be friends" });

                    }
                }
            

            if (UserInvitations.Count != 0)
            {
                return UserInvitations;
            }
            else
            {
                throw new ArgumentException("You don't have invitations");
            }
        }

        public LoggedUserModel Accept(LoggedUserModel loggedUser, int SenderId, List<Friendship> RelationList)
        {

            if (RegisteredUsers != null && RelationList != null)
            {
                LoggedUserModel NewFriend = new LoggedUserModel();
                bool InvitationExist = false;
                foreach (Friendship Inv in RelationList)
                {
                    if (SenderId == Inv.GetSenderId() && loggedUser.Id == Inv.GetRecipientId())
                    {
                        if (NewFriend != null)
                        {
                            NewFriend = new LoggedUserModel() { Id = Inv.IdSender };
                            Inv.RelationsStatus = "friend";
                            InvitationExist = true;
                        }
                    }
                }
                if (InvitationExist == false)
                {
                    throw new ArgumentException("This user haven't sent you invitation");
                }
                NewFriend = FindName(NewFriend);
                return NewFriend;
            }
            else
            {
                throw new ArgumentNullException();
            }

        }

        public LoggedUserModel Decline(int SenderId, List<Friendship> RelationList, LoggedUserModel loggedUser)
        {
            LoggedUserModel PossibleFriend = new LoggedUserModel();
            bool InvitationExist = false;
            foreach (Friendship Inv in RelationList)
            {

                if (SenderId == Inv.IdSender && loggedUser.Id == Inv.IdRecipient)
                {
                    PossibleFriend = new LoggedUserModel() { Id = Inv.IdSender };
                    Inv.RelationsStatus = "declined";
                    InvitationExist = true;
                }
            }
            if (InvitationExist == false)
            {
                throw new ArgumentException("This user haven't sent you invitation");
            }

            PossibleFriend = FindName(PossibleFriend);
            return PossibleFriend;


        }
        private LoggedUserModel FindName(LoggedUserModel NewFriend)
        {
            foreach (LoggedUserModel user in RegisteredUsers)
            {
                if (user.Id == NewFriend.Id)
                {
                    NewFriend = new LoggedUserModel { Id = user.Id, Name = user.Name };
                }
            }
            return NewFriend;
        }
       
    public LoggedUserModel LogOut(LoggedUserModel loggedUser)
        {
            loggedUser.Id = 0;
            loggedUser.Name = "NoName";
            return loggedUser;
        }

        public List<string> ShowUserFriend(LoggedUserModel LoggedUser, List<Friendship> RelationList)
        {
            List<string> Friends = new List<string>();
            Relations friends = new Relations(RelationList);
            List<Friendship> UserFriends = friends.GetFriends(LoggedUser.Id, RelationList);
            if (UserFriends.Count != 0)
            {
                foreach (Friendship f in UserFriends)
                {
                    foreach (LoggedUserModel U in RegisteredUsers)
                    {

                        if ((U.Id == f.IdSender | U.Id == f.IdRecipient) && f.GetStatusText() == "friend")
                        {
                            Friends.Add($"{U.Name} is your {f.RelationsStatus}");

                        }
                        if (U.Id == f.IdRecipient && f.GetStatusText() == "pending")
                        {
                            Friends.Add($"Invitation to {U.Name} is  {f.RelationsStatus}");
                        }
                    }
                }
            }
            else
            {
                throw new Exception("You don't have friends");
            }
            return Friends;
        }

        public int GetId( string UserName)
        {
            int UserId = 0;
            foreach (LoggedUserModel U in RegisteredUsers)
            {
                if (U.Name == UserName)
                {
                    UserId = U.Id;
                }
            }
            return UserId;
        }
    }*/
}
