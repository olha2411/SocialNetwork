using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public abstract class User
    {        
        public int Id { get; set; }

        public string Name { get; set; }
        

        public virtual List<LoggedUser> ShowUsers(List<LoggedUser> RegisteredUsers, int LoggedUserId)
        {
            List<LoggedUser> Users = new List<LoggedUser>();

            foreach (LoggedUser U in RegisteredUsers)
            {
                Users.Add(new LoggedUser() { Id = U.Id, Name = U.Name });

            }
            return Users;
        }
    }
}
