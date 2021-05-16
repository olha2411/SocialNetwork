using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class Relations
    {
        public List<Friendship> RelationsList = new List<Friendship>();
        public Relations(List<Friendship> friendships)
        {
            RelationsList = friendships;
        }
        public List<Friendship> HaveRelation(int UserId)
        {
            List<Friendship> Friends = new List<Friendship>();
            foreach (Friendship friend in RelationsList)
            {
                if (friend.IdSender == UserId | friend.IdRecipient == UserId)
                {
                    Friends.Add(new Friendship() { IdSender = friend.IdSender, IdRecipient = friend.IdRecipient, RelationsStatus = friend.RelationsStatus });
                }
            }
            return Friends;
        }

        public List<Friendship> GetFriends(int UserId)
        {
            List<Friendship> UserFriends = HaveRelation(UserId);
            List<Friendship> friends = new List<Friendship>();
            foreach (Friendship f in UserFriends)
            {
                if (f.IdSender != UserId)
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

        public void IsRelation(int SenderId, int ReceiverId, string Name)
        {
            foreach (Friendship friend in RelationsList)
            {

                if (friend.IdRecipient == SenderId && friend.IdSender == ReceiverId && friend.RelationsStatus == "pending")
                {
                    throw new WrongInvitationException($"{Name} has sent you invitation. You can accept it");
                }
                else if (friend.IdSender == SenderId && friend.IdRecipient == ReceiverId && friend.RelationsStatus == "friend")
                {
                    throw new WrongInvitationException($"{Name} is already your friend");
                }
                else if (friend.IdRecipient == ReceiverId && friend.IdSender == SenderId && friend.RelationsStatus == "pending")
                {
                    throw new WrongInvitationException($"The invitation to {Name} is already sent");
                }
            }
        }


    }
}
