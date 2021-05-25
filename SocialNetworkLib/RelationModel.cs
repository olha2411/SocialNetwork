using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class RelationModel
    {
        public int IdSender { get; set; }
        public int IdRecipient { get; set; }
        public string RelationsStatus { get; set; }
    }
}
