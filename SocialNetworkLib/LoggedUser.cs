﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class LoggedUser:User
    {
        public override List<LoggedUser> ShowUsers(List<LoggedUser> RegisteredUsers, int LoggedUserId)
        {
            List<LoggedUser> Users = new List<LoggedUser>();

            foreach (LoggedUser U in RegisteredUsers)
            {
                if (U.Id != LoggedUserId)
                {
                    Users.Add(new LoggedUser() { Id = U.Id, Name = U.Name });
                }
            }

            return Users;
        }


        public string AddFriend(List<Friendship> RelationList, List<LoggedUser> RegisteredUsers, int IdUser, int IdReciver)
        {
            bool exist = false;
            string Friend = null;
            foreach (LoggedUser user in RegisteredUsers)
            {
                if (user.Id == IdReciver)
                {
                    foreach (Friendship friend in RelationList)
                    {
                        if (friend.IdRecipient == IdUser && friend.IdSender == IdReciver && friend.RelationsStatus == "pending")
                        {
                            throw new WrongInvitationException($"{user.Name} has sent you invitation. You can accept it");
                        }
                        else if (friend.IdRecipient == IdReciver && friend.IdSender == IdUser && friend.RelationsStatus == "pending")
                        {
                            throw new WrongInvitationException($"The invitation to {user.Name} is already sent");
                        }
                        else if (friend.IdRecipient == IdReciver && friend.RelationsStatus == "friend")
                        {
                            throw new WrongInvitationException($"{user.Name} is already your friend");
                        }
                    }
                    exist = true;
                    RelationList.Add(new Friendship() { IdSender = IdUser, IdRecipient = IdReciver, RelationsStatus = "pending" });
                    Friend = user.Name;
                }
            }

            if (exist == false)
            {
                throw new ArgumentNullException("This user is not registered");
            }
            return Friend;


        }

        public List<Friendship> GetUserFriends(List<Friendship> RelationList, int IdUser)
        {
            List<Friendship> UserFriends = new List<Friendship>();
            foreach (Friendship friend in RelationList)
            {
                if (friend.IdSender == IdUser | friend.IdRecipient == IdUser)
                {
                    UserFriends.Add(new Friendship() { IdSender = friend.IdSender, IdRecipient = friend.IdRecipient, RelationsStatus = friend.RelationsStatus });
                }
            }
            List<Friendship> friends = new List<Friendship>();
            foreach (Friendship f in UserFriends)
            {
                if (f.IdSender != IdUser)
                {
                    friends.Add(new Friendship() { IdSender = f.IdSender, RelationsStatus = f.RelationsStatus });
                }
                else
                {
                    friends.Add(new Friendship() { IdRecipient = f.IdRecipient, RelationsStatus = f.RelationsStatus });
                }
            }

            return friends;
        }

        public List<Friendship> GetUserInvitations(List<Friendship> RelationList, int IdLoggedUser)
        {
            List<Friendship> UserInvitations = new List<Friendship>();

            foreach (Friendship user in RelationList)
            {
                if ((user.IdRecipient == IdLoggedUser && user.RelationsStatus != "declined" && user.RelationsStatus != "friend"))
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

        public LoggedUser Accept(List<LoggedUser> RegisteredUsers, LoggedUser loggedUser, int SenderId, List<Friendship> RelationList)
        {
            LoggedUser NewFriend = new LoggedUser();
            bool InvitationExist = false;
            foreach (Friendship Inv in RelationList)
            {
                if (SenderId == Inv.IdSender)
                {
                    if (NewFriend != null)
                    {
                        NewFriend = new LoggedUser() { Id = Inv.IdSender };
                        Inv.RelationsStatus = "friend";
                        InvitationExist = true;
                    }
                }
                else if (InvitationExist == false)
                {
                    throw new ArgumentException("This user haven't sent you invitation");
                }
            }
            NewFriend = FindName(RegisteredUsers, NewFriend);
            return NewFriend;



        }

        public LoggedUser Decline(List<LoggedUser> RegisteredUsers, LoggedUser loggedUser, int SenderId, List<Friendship> RelationList)
        {
            LoggedUser PossibleFriend = new LoggedUser();
            bool InvitationExist = false;
            foreach (Friendship Inv in RelationList)
            {

                if (SenderId == Inv.IdSender)
                {
                    PossibleFriend = new LoggedUser() { Id = Inv.IdSender };
                    Inv.RelationsStatus = "declined";
                }
            }
            if (InvitationExist == false)
            {
                throw new ArgumentException("This user haven't sent you invitation");
            }
            else
            {
                PossibleFriend = FindName(RegisteredUsers, PossibleFriend);
                return PossibleFriend;
            }

        }
        private LoggedUser FindName(List<LoggedUser> RegisteredUsers, LoggedUser NewFriend)
        {
            foreach (LoggedUser user in RegisteredUsers)
            {
                if (user.Id == NewFriend.Id)
                {
                    NewFriend = new LoggedUser { Id = user.Id, Name = user.Name };
                }
            }
            return NewFriend;
        }
        public LoggedUser LogOut(LoggedUser loggedUser)
        {
            loggedUser.Id = 0;
            loggedUser.Name = "NoName";
            return loggedUser;
        }

    }
}