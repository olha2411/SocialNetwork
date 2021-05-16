using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class LoggedUser : User
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
                    Relations relations = new Relations(RelationList);
                    relations.IsRelation(IdUser, IdReciver, user.Name);
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
            Relations relations = new Relations(RelationList);
            List<Friendship> UserFriends = relations.GetFriends(IdUser);

            return UserFriends;
        }

        public List<Friendship> GetUserInvitations(List<Friendship> RelationList, int IdLoggedUser)
        {
            List<Friendship> UserInvitations = new List<Friendship>();

            foreach (Friendship user in RelationList)
            {
                if ((user.IdRecipient == IdLoggedUser && user.RelationsStatus != "declined" && user.IsStatusFriends() == false))// user.RelationsStatus != "friend"
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
                if (SenderId == Inv.IdSender && loggedUser.Id == Inv.IdRecipient)
                {
                    if (NewFriend != null)
                    {
                        NewFriend = new LoggedUser() { Id = Inv.IdSender };
                        Inv.RelationsStatus = "friend";
                        InvitationExist = true;
                    }
                }
            }
            if (InvitationExist == false)
            {
                throw new ArgumentException("This user haven't sent you invitation");
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

                if (SenderId == Inv.IdSender && loggedUser.Id == Inv.IdRecipient)
                {
                    PossibleFriend = new LoggedUser() { Id = Inv.IdSender };
                    Inv.RelationsStatus = "declined";
                    InvitationExist = true;
                }
            }
            if (InvitationExist == false)
            {
                throw new ArgumentException("This user haven't sent you invitation");
            }

            PossibleFriend = FindName(RegisteredUsers, PossibleFriend);
            return PossibleFriend;


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
