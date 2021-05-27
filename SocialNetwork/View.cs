using System;
using System.Collections.Generic;
using System.Text;
using SocialNetworkLib;

namespace SocialNetwork
{
    public class View
    {
        public static void ShowUsers(General general, LoggedUserModel loggedUser)
        {
            List<LoggedUserModel> Users = general.ShowAllUsers(loggedUser);
            foreach (LoggedUserModel user in Users)
            {
                Console.WriteLine($"\t {user.Name}");
            }
        }
        public static LoggedUserModel LogIn(LoggedUserModel loggedUser, General general)
        {
            if (loggedUser.Id == 0)
            {
                try
                {
                    Console.WriteLine("Enter your login:");
                    int IdUser = int.Parse(Console.ReadLine());
                    loggedUser = general.LogIn(IdUser);
                    Console.WriteLine($"Hello {loggedUser.Name}!");
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
            return loggedUser;
        }
        public static void SendUserInvitation(General general, LoggedUserModel loggedUser)
        {
            if (loggedUser.Id != 0)
            {
                try
                {
                    Console.WriteLine("Enter the name of user you want to send invitation:");
                    string name = Console.ReadLine();
                    general.SendUserInvitation(loggedUser.Id, name);
                    Console.WriteLine($"You have sent invitation to {name}. Wait for answear)");


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

        public static void ShowUserFriends(General general, LoggedUserModel loggedUser)
        {
            if (loggedUser.Id != 0)
            {

                List<string> Friends = general.ShowUserFriend(loggedUser.Id);
                foreach (string f in Friends)
                {
                    Console.WriteLine($"{f} is your  friend");
                }

            }
            else
            {
                Console.WriteLine("You are not logged in! Please, log in");
            }
        }

        public static void ShowUserInvitations(General general, LoggedUserModel loggedUser)
        {
            if (loggedUser.Id != 0)
            {
                List<string> UserInvitations = general.GetUserInvitations(loggedUser.Id);
                try
                {
                    foreach (string inv in UserInvitations)
                    {
                        Console.WriteLine($"\t {inv} send you invitation to be friends");
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
        public static void ProcessInvitation(General general, LoggedUserModel loggedUser)
        {
            if (loggedUser.Id != 0)
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
                            AcceptInvitation(general, loggedUser);
                            break;
                        case 2:
                            DeclineInvitation(general, loggedUser);
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
        public static void AcceptInvitation(General general, LoggedUserModel loggedUser)
        {
            try
            {
                Console.WriteLine("Your invitations");
                ShowUserInvitations(general, loggedUser);
                Console.WriteLine("Enter the name of user to accept his/her invitation:");
                string name = Console.ReadLine();
                string Name = general.AcceptUserInvitation(loggedUser, name);
                Console.WriteLine($"{Name} is your new friend");
                Console.WriteLine("");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public static void DeclineInvitation(General general, LoggedUserModel loggedUser)
        {
            try
            {
                Console.WriteLine("Your invitations");
                ShowUserInvitations(general, loggedUser);
                Console.WriteLine("Enter the name of user to accept his/her invitation:");
                string name = Console.ReadLine();
                string Name = general.DeclineUserInvitation(loggedUser, name);
                Console.WriteLine($"You declined {Name}'s invitation to become friends");
                Console.WriteLine("");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public static void LogOut(General general, LoggedUserModel loggedUser)
        {
            loggedUser = general.LogOut(loggedUser);
        }

        public static void SendInvitationToGroup(General general, LoggedUserModel loggedUser)
        {
            if (loggedUser.Id != 0)
            {
                Console.WriteLine("Enter the name of group you want to add member to:");
                string GroupName = Console.ReadLine();
                Console.WriteLine("Enter the name of user to send  invitation:");
                string UserName = Console.ReadLine();
                general.AddUserToGroup(UserName, GroupName, loggedUser);
                Console.WriteLine($"You've sent invitation to {UserName} to join {GroupName} group");
            }
            else
            {
                Console.WriteLine("You are not logged in! Please, log in");
            }

        }


        public static void AcceptGroupInvitation(General general, LoggedUserModel loggedUser)
        {
            if (loggedUser.Id != 0)
            {
                Dictionary<string, string> sender = general.GetGroupInvitations(loggedUser.Id);
                if (sender.Count == 0)
                {
                    Console.WriteLine("You don't have invitations");
                }
                else
                {
                    foreach (KeyValuePair<string, string> keyValue in sender)
                    {
                        Console.WriteLine(keyValue.Key + " send invitation to join " + keyValue.Value);
                    }


                    Console.WriteLine("Enter the name of group you want join to:");
                    string GroupName = Console.ReadLine();
                    general.Accept(GroupName, loggedUser.Id);
                    Console.WriteLine($"You've joined {GroupName} group");
                }

            }
            else
            {
                Console.WriteLine("You are not logged in! Please, log in");
            }
        }

        public static void DeclineGroupInvitation(General general, LoggedUserModel loggedUser)
        {
            if (loggedUser.Id != 0)
            {
                Dictionary<string, string> sender = general.GetGroupInvitations(loggedUser.Id);
                if (sender.Count == 0)
                {
                    Console.WriteLine("You don't have invitations");
                }
                else
                {

                    foreach (KeyValuePair<string, string> keyValue in sender)
                    {
                        Console.WriteLine(keyValue.Key + "send invitation to join " + keyValue.Value);
                    }
                    Console.WriteLine("Enter the name of group you want join to:");
                    string GroupName = Console.ReadLine();
                    general.DeclineInvitation(GroupName, loggedUser.Id);
                    Console.WriteLine($"You've declined invitation to join {GroupName} group");
                }
            }
            else
            {
                Console.WriteLine("You are not logged in! Please, log in");
            }
        }

        public static void GetGroupParticipants(General general, LoggedUserModel loggedUser)
        {
            if (loggedUser.Id != 0)
            {
                Console.WriteLine("Enter the name of group you want to see participants:");
                string GroupName = Console.ReadLine();
                Console.WriteLine();
                List<string> participants = general.GetGroupParticipants(GroupName);
                foreach (string G in participants)
                {
                    Console.WriteLine(G);
                }
            }
            else
            {
                Console.WriteLine("You are not logged in! Please, log in");
            }
        }
        public static void GetAllGroups(General general, LoggedUserModel loggedUser)
        {
            if (loggedUser.Id != 0)
            {
                List<string> groups = general.GetExistingGroups();
                foreach (string item in groups)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("You are not logged in! Please, log in");
            }

        }
        public static void GetUserGroup(General general, LoggedUserModel loggedUser)
        {
            if (loggedUser.Id != 0)
            {

                List<string> groups = general.GetUserGroups(loggedUser.Id);
                Console.WriteLine("You are member of groups:");
                foreach (string item in groups)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("You are not logged in! Please, log in");
            }

        }

    }
}

