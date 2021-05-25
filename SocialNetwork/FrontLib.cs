using System;
using System.Collections.Generic;
using System.Text;
using SocialNetworkLib;

namespace SocialNetwork
{
   // public class FrontLib
    //{
       /* public static void ShowUsers(List<LoggedUser> RegisteredUsers, loggedUser loggedUser)
        {
            List<LoggedUser> Users = loggedUser.ShowUsers(loggedUser.Id);
            foreach (LoggedUser user in Users)
            {
                Console.WriteLine($"\t {user.Name}");
            }
        }
        public static LoggedUser LogIn(LoggedUser LoggedUser, List<LoggedUser> RegisteredUsers)
        {
            if (LoggedUser.Id == 0)
            {
                try
                {
                    Console.WriteLine("Enter your login:");
                    int IdUser = int.Parse(Console.ReadLine());
                    UnLoggedUser w = new UnLoggedUser(0, "Y");
                    LoggedUser = new LoggedUser { Id = (w.LogIn(RegisteredUsers, IdUser)).Id, Name = (w.LogIn(RegisteredUsers, IdUser)).Name };
                    Console.WriteLine($"Hello {LoggedUser.Name}!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else
            {
                Console.WriteLine("You are log in already! Choose another command");
            }
            return LoggedUser;
            
        }


        public static void ShowUserFriends(LoggedUser LoggedUser, List<Friendship> RelationList, List<LoggedUser> RegisteredUsers)
        {
            if (LoggedUser.Id != 0)
            {

                List<string> Friends = LoggedUser.ShowUserFriend(LoggedUser, RelationList, RegisteredUsers);
                foreach (string f in Friends)
                {
                    Console.WriteLine(f);
                }

            }
            else
            {
                Console.WriteLine("You are not logged in! Please, log in");
            }
        }
        public static void SendInvitation(LoggedUserModel LoggedUser, List<Friendship> RelationList, List<LoggedUser> RegisteredUsers)
        {
            if (LoggedUser.Id != 0)
            {
                try
                {
                    Console.WriteLine("Enter the name of user you want to send invitation:");
                    string name = Console.ReadLine();
                                      
                                            Console.WriteLine($"You have sent invitation to {Friend}. Wait for answear)");
                   
                   
                }
                catch (WrongInvitationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            else
            {
                Console.WriteLine("You are not logged in! Please, log in");
            }
        }
        public static void ShowUserInvitations(LoggedUser LoggedUser, List<LoggedUser> RegisteredUsers, List<Friendship> RelationList)
        {
            if (LoggedUser.Id != 0)
            {
                List<Friendship> UserInvitations = LoggedUser.GetUserInvitations(RelationList, LoggedUser.Id);
                try
                {
                    foreach (Friendship inv in UserInvitations)
                    {
                        foreach (LoggedUser user in RegisteredUsers)
                        {
                            if (inv.IdSender == user.Id)
                            {
                                Console.WriteLine($"\t {user.Name} send you {inv.RelationsStatus}");
                            }
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            else
            {
                Console.WriteLine("You are not logged in! Please, log in");
            }
        }
        public static void ProcessInvitation(List<LoggedUser> RegisteredUsers, LoggedUser LoggedUser, List<Friendship> RelationList)
        {
            if (LoggedUser.Id != 0)
            {
                bool alive = true;
                while (alive)
                {
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\t 1 - Accept invitation \n\t 2 - Decline invitation \n\t 3 - Go to Main Menu");
                    Console.WriteLine("Enter number of command:");
                    Console.ForegroundColor = color;
                    int command = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    switch (command)
                    {
                        case 1:
                            AcceptInvitation(RegisteredUsers, LoggedUser, RelationList);
                            break;
                        case 2:
                            DeclineInvitation(RegisteredUsers, LoggedUser, RelationList);
                            break;
                        case 3:
                            alive = false;
                            continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("You are not logged in! Please, log in");
            }
        }
        public static void AcceptInvitation(List<LoggedUser> RegisteredUsers, LoggedUser loggeduser, List<Friendship> RelationList)
        {
            try
            {
                Console.WriteLine("Your invitations");
                ShowUserInvitations(loggeduser, RegisteredUsers, RelationList);
                Console.WriteLine("Enter the name of user to accept his/her invitation:");
                string name = Console.ReadLine();
                int InvitationId = loggeduser.GetId(RegisteredUsers, name);               
                LoggedUser NewFriend = loggeduser.Accept(RegisteredUsers, loggeduser, InvitationId, RelationList);
                Console.WriteLine($"{NewFriend.Name} is your new friend");
                Console.WriteLine("");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }


        }
        public static void DeclineInvitation(List<LoggedUser> RegisteredUsers, LoggedUser loggeduser, List<Friendship> RelationList)
        {
            try
            {
                Console.WriteLine("Your invitations");
                ShowUserInvitations(loggeduser, RegisteredUsers, RelationList);
                Console.WriteLine("Enter the name of user to decline invitation:");
                string name = Console.ReadLine();
                int InvitationId = loggeduser.GetId(RegisteredUsers, name);                
                LoggedUser Friend = loggeduser.Decline(RegisteredUsers, InvitationId, RelationList, loggeduser);
                Console.WriteLine($"You declined {Friend.Name}'s invitation to be your friend");
                Console.WriteLine("");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }
        public static void Logout(LoggedUser LoggedUser)
        {
            if (LoggedUser.Id != 0)
            {
                LoggedUser.LogOut(LoggedUser);
                Console.WriteLine("You log out. For more available options you need log in");
            }
            else
            {
                Console.WriteLine("You are not logged in! Please, log in firstly");
            }
        }
    }*/
    
}
