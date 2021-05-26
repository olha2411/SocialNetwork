using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class Relation
    {
        List<RelationModel> relations;

        public Relation(List<RelationModel> Relations)
        {
            relations = Relations;
        }


        public List<RelationModel> GetUserFriends(int UserId)
        {
            List<RelationModel> Friends = new List<RelationModel>();
            foreach(RelationModel relation in relations)
            {
              
                    if(relation.IdSender == UserId && relation.RelationsStatus == "friend")
                    {
                        Friends.Add(new RelationModel { IdSender = relation.IdRecipient, RelationsStatus = "friend" });
                    }
                    else if(relation.IdRecipient == UserId && relation.RelationsStatus == "friend")
                    {
                        Friends.Add(new RelationModel { IdSender = relation.IdSender, RelationsStatus = "friend" });
                    }
                    
               
            }
            return Friends;
        }

        public List<int> GetUserInvitations(int UserId)
        {
            List<int> Invitations = new List<int>();
            foreach(RelationModel R in relations)
            {
                if(R.IdRecipient == UserId && R.RelationsStatus == "pending")
                {
                    Invitations.Add(R.IdSender);
                }
            }
            return Invitations;
        }

        public void AddFriend(int ReceiverId, int UserId)
        {
            relations.Add(new RelationModel() { IdSender = UserId, IdRecipient = ReceiverId, RelationsStatus = "pending" });
        }

        public int AcceptInvitation(string SenderName, int UserId, LoggedUser users)
        {
            int SenderId = users.GetUserId(SenderName);
            foreach(RelationModel R in relations)
            {
                if(R.IdSender == SenderId && R.IdRecipient == UserId && R.RelationsStatus != "friend")
                {
                    R.RelationsStatus = "friend";
                }
            }
            return SenderId;
        }

        public int DeclineInvitation(string SenderName, int UserId, LoggedUser users)
        {
            int SenderId = users.GetUserId(SenderName);
            foreach (RelationModel R in relations)
            {
                if (R.IdSender == SenderId && R.IdRecipient == UserId && R.RelationsStatus != "friend")
                {
                    R.RelationsStatus = "decline";
                }
            }
            return SenderId;
        }

        public void GetRelationType(int SenderId, int ReceiverId, string Name)
        {
            foreach (RelationModel friend in relations)
            {

                if (friend.IdRecipient == SenderId && friend.IdSender == ReceiverId && friend.RelationsStatus == "pending")
                {
                    throw new WrongInvitationException($"{Name} has sent you invitation. You can accept it");
                }
                else if (friend.IdSender == SenderId && friend.IdRecipient == ReceiverId && friend.RelationsStatus == "friend")
                {
                    throw new WrongInvitationException($"You can't send invitation. {Name} is already your friend");
                }
                else if (friend.IdRecipient == ReceiverId && friend.IdSender == SenderId && friend.RelationsStatus == "pending")
                {
                    throw new WrongInvitationException($"You can't send invitation again. The invitation to {Name} is already sent");
                }
            }
        }
    }
}
