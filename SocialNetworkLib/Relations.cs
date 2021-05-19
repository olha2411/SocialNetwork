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
            List<Friendship> RelationUsers = new List<Friendship>();
            foreach (Friendship friend in RelationsList)
            {
                if (friend.IdSender == UserId | friend.IdRecipient == UserId)
                {
                    RelationUsers.Add(new Friendship() { IdSender = friend.IdSender, IdRecipient = friend.IdRecipient, RelationsStatus = friend.RelationsStatus });
                }
            }
            return RelationUsers;
        }

        public List<Friendship> GetFriends(int UserId, List<Friendship> RelationList)
        {
            if (RelationList != null)
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
            else throw new ArgumentNullException();

            
        }
       

        public void GetRelationType(int SenderId, int ReceiverId, string Name)
        {
            foreach (Friendship friend in RelationsList)
            {

                if (friend.IdRecipient == SenderId && friend.IdSender == ReceiverId && friend.GetStatusText() == "pending")
                {
                    throw new WrongInvitationException($"{Name} has sent you invitation. You can accept it");
                }
                else if (friend.IdSender == SenderId && friend.IdRecipient == ReceiverId && friend.GetStatusText() == "friend")
                {
                    throw new WrongInvitationException($"You can't send invitation. {Name} is already your friend");
                }
                else if (friend.IdRecipient == ReceiverId && friend.IdSender == SenderId && friend.GetStatusText() == "pending")
                {
                    throw new WrongInvitationException($"You can't send invitation again. The invitation to {Name} is already sent");
                }
            }
        }
    }
}
