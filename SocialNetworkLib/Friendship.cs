using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class Friendship
    {
        public int IdSender { get; set; }
        public int IdRecipient { get; set; }
        public string RelationsStatus { get; set; }

        public string GetStatusText()
        {
            return RelationsStatus;
        }
        public bool IsStatusFriends()
        {
            if (RelationsStatus == "friend")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
