using System;
using SocialNetworkLib;
using System.Collections.Generic;

namespace SocialNetwork
{
    class Program:FrontLib
    {
        static void Main(string[] args)
        {

            List<LoggedUser> RegisteredUsers = new List<LoggedUser>()
            {
            new LoggedUser() { Id = 1, Name = "Tom King" },
            new LoggedUser() { Id = 2, Name = "Bill Wilson" },
            new LoggedUser() { Id = 3, Name = "George Adamson" },
            new LoggedUser() { Id = 4, Name = "Ann Harris" },
            new LoggedUser() { Id = 5, Name = "Ken" },
            new LoggedUser() { Id = 6, Name = "Emily Walker" },
            new LoggedUser() { Id = 7, Name = "Lily Davies" },
            new LoggedUser() { Id = 8, Name = "Harry Johnson" },
            new LoggedUser() { Id = 9, Name = "Amelia Brown" },
            };

            List<Friendship> RelationList = new List<Friendship>()
            {
                new Friendship(){ IdSender = 2, IdRecipient = 3, RelationsStatus = "friend"},
                new Friendship(){ IdSender = 1, IdRecipient = 3, RelationsStatus = "friend"},
                new Friendship(){ IdSender = 2, IdRecipient = 4, RelationsStatus = "friend"},
                new Friendship(){ IdSender = 4, IdRecipient = 1, RelationsStatus = "friend"},
                new Friendship(){ IdSender = 3, IdRecipient = 5, RelationsStatus = "pending"},
                new Friendship(){ IdSender = 7, IdRecipient = 1, RelationsStatus = "pending"},
                new Friendship(){ IdSender = 2, IdRecipient = 6, RelationsStatus = "friend"},
                new Friendship(){ IdSender = 7, IdRecipient = 2, RelationsStatus = "pending"},
                new Friendship(){ IdSender = 2, IdRecipient = 1, RelationsStatus = "pending"},
                new Friendship(){ IdSender = 7, IdRecipient = 5, RelationsStatus = "friend"},
                new Friendship(){ IdSender = 9, IdRecipient = 8, RelationsStatus = "pending"},
                new Friendship(){ IdSender = 4, IdRecipient = 9, RelationsStatus = "friend"},
            };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Welcome to a SocialNetwork! \n Choose a command to start");
            LoggedUser LoggedUser = new LoggedUser() { Id = 0, Name = "Name" };

            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("\t 1 - Show registered users \n\t 2 - Log in \n\t 3 - Show my friends \n\t 4 - Add friend(send invitation)");
                Console.WriteLine("\t 5 - Show my invitations \n\t 6 - Process invitations \n\t 7 - Log out");
                Console.WriteLine("\t 8 - Stop working in social network");
                Console.WriteLine("");
                Console.WriteLine("Enter number of command:");
                Console.ForegroundColor = color;
                try
                {
                    int command = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    switch (command)
                    {
                        case 1:
                            ShowUsers(RegisteredUsers, LoggedUser);
                            break;
                        case 2:
                            LoggedUser = LogIn(LoggedUser, RegisteredUsers);
                            break;
                        case 3:
                            ShowUserFriends(LoggedUser, RelationList, RegisteredUsers);
                            break;
                        case 4:
                            SendInvitation(LoggedUser, RelationList, RegisteredUsers);
                            break;
                        case 5:
                            ShowUserInvitations(LoggedUser, RegisteredUsers, RelationList);
                            break;
                        case 6:
                            ProcessInvitation(RegisteredUsers, LoggedUser, RelationList);
                            break;
                        case 7:
                            Logout(LoggedUser);
                            break;
                        case 8:
                            alive = false;
                            continue;

                    }
                }
                catch (Exception ex)
                {

                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }


            string g = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            Console.WriteLine(g);
        }       


    }

   
}
