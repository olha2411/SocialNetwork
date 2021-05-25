using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    /*public class UnLoggedUser : User
    {
        public UnLoggedUser(int Id, string Name) : base()
        {
            this.Id = Id;
            this.Name = Name;
        }
        public LoggedUser LogIn(List<LoggedUser> RegisteredUsers, int IdNewUser)
        {
            LoggedUser LoggedUser = new LoggedUser() { Id = 0, Name = "Name" };
            bool contain = false;
            foreach (User U in RegisteredUsers)
            {
                if (U.Id == IdNewUser)
                {
                    LoggedUser = new LoggedUser() { Id = IdNewUser, Name = U.Name };
                    contain = true;
                }
            }
            if (contain == false)
            {
                throw new ArgumentException("User is not registered");
            }
            return LoggedUser;
        }
        public override List<LoggedUser> ShowUsers(List<LoggedUser> RegisteredUsers, int LoggedUserId)
        {
            List<LoggedUser> Users = new List<LoggedUser>();

            foreach (LoggedUser U in RegisteredUsers)
            {
                Users.Add(new LoggedUser() { Id = U.Id, Name = U.Name });

            }

            return Users;
        }
    }*/
}
