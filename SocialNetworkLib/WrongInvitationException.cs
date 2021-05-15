using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class WrongInvitationException:Exception
    {
        public WrongInvitationException() { }
        public WrongInvitationException(string message) : base(message) { }
    }
}
