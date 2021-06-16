using System;
using SocialNetworkLib;
using System.Collections.Generic;

namespace SocialNetwork
{
    class Program :View
    {
        static void Main(string[] args)
        {
            
            List<LoggedUserModel> RegisteredUsers = new List<LoggedUserModel>()
            {
            new LoggedUserModel() { Id = 1, Name = "Tom King" },
            new LoggedUserModel() { Id = 2, Name = "Bill Wilson" },
            new LoggedUserModel() { Id = 3, Name = "George Adamson" },
            new LoggedUserModel() { Id = 4, Name = "Ann Harris" },
            new LoggedUserModel() { Id = 5, Name = "Ken" },
            new LoggedUserModel() { Id = 6, Name = "Emily Walker" },
            new LoggedUserModel() { Id = 7, Name = "Lily Davies" },
            new LoggedUserModel() { Id = 8, Name = "Harry Johnson" },
            new LoggedUserModel() { Id = 9, Name = "Amelia Brown" },
            };

            List<RelationModel> RelationList = new List<RelationModel>()
            {
                new RelationModel(){ IdSender = 2, IdRecipient = 3, RelationsStatus = "friend"},
                new RelationModel(){ IdSender = 1, IdRecipient = 3, RelationsStatus = "friend"},
                new RelationModel(){ IdSender = 2, IdRecipient = 4, RelationsStatus = "friend"},
                new RelationModel(){ IdSender = 4, IdRecipient = 1, RelationsStatus = "friend"},
                new RelationModel(){ IdSender = 3, IdRecipient = 5, RelationsStatus = "pending"},
                new RelationModel(){ IdSender = 7, IdRecipient = 1, RelationsStatus = "pending"},
                new RelationModel(){ IdSender = 2, IdRecipient = 6, RelationsStatus = "friend"},
                new RelationModel(){ IdSender = 7, IdRecipient = 2, RelationsStatus = "pending"},
                new RelationModel(){ IdSender = 2, IdRecipient = 1, RelationsStatus = "pending"},
                new RelationModel(){ IdSender = 7, IdRecipient = 5, RelationsStatus = "friend"},
                new RelationModel(){ IdSender = 9, IdRecipient = 8, RelationsStatus = "pending"},
                new RelationModel(){ IdSender = 4, IdRecipient = 9, RelationsStatus = "friend"},
            };

            List<GroupModel> Groups = new List<GroupModel>()
            {
                new GroupModel(11,1,"MusicFans"),
                new GroupModel(22,7,"ArtFans"),
                new GroupModel(33,2,"GamesFans"),
                new GroupModel(44,5,"NatureFans"),

            };

            List<GroupRelationshipsModel> groupRelationships = new List<GroupRelationshipsModel>()
            {
                new GroupRelationshipsModel(11, 7, "member", 1),
                new GroupRelationshipsModel(33, 4, "owner", 0),
                new GroupRelationshipsModel(11, 9, "member", 7),
                new GroupRelationshipsModel(22, 7, "owner", 0),
                new GroupRelationshipsModel(22, 6, "member", 7),
                new GroupRelationshipsModel(11, 1, "owner", 0),
                new GroupRelationshipsModel(33, 8, "member", 4),
                new GroupRelationshipsModel(44, 5, "owner", 0),
                new GroupRelationshipsModel(44, 3, "member", 5),
                new GroupRelationshipsModel(44, 1, "0", 5),
            };

            LoggedUser registeredUsers = new LoggedUser(RegisteredUsers);
            GroupRelationships GroupRelationship = new GroupRelationships(groupRelationships);
            Group Group = new Group(Groups);
            Relation relations = new Relation(RelationList);


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n Welcome to a SocialNetwork! \n\n Choose a command to start:");
            LoggedUserModel loggedUser = new LoggedUserModel() { Id = 0, Name = "Name" };

            General general = new General(GroupRelationship, Group, loggedUser, registeredUsers, relations);
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t MENU");
                Console.WriteLine(" 1 - Show registered users \n 2 - Log in \n 3 - Show my friends \n 4 - Add friend(send invitation)");
                Console.WriteLine(" 5 - Show my invitations \n 6 - Process invitations \n 7 - Send Invitation to User to join Group");
                Console.WriteLine(" 8 - Accept Group Invitation  \n 9 - Decline Group Invitation");
                Console.WriteLine(" 10 - GetGroupParticipants \n 11 - Show Existing Groups \n 12 - Show my groups");
                Console.WriteLine(" 13 - Log out  \n 14 - Stop working in social network");
                Console.WriteLine("");
                Console.WriteLine("Enter number of command:");
                Console.ForegroundColor = color;
                try
                {
                    int command = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    if(command > 14 | command < 1)
                    {
                        Console.WriteLine("There is no such command");
                    }
                    switch (command)
                    {
                        case 1:
                            ShowUsers(general, loggedUser);
                            break;
                        case 2:
                            loggedUser = LogIn(loggedUser, general);
                            break;
                        case 3:
                            ShowUserFriends(general, loggedUser);
                            break;
                        case 4:
                            SendUserInvitation(general, loggedUser);
                            break;
                        case 5:
                            ShowUserInvitations(general, loggedUser);
                            break;
                        case 6:
                            ProcessInvitation(general, loggedUser);
                            break;
                        case 7:
                            SendInvitationToGroup(general, loggedUser);
                            break;
                        case 8:
                            AcceptGroupInvitation(general, loggedUser);  
                            break;
                        case 9:
                            DeclineGroupInvitation(general, loggedUser);
                            break;
                        case 10:
                            GetGroupParticipants(general, loggedUser);
                            break;
                        case 13:
                             LogOut(general, loggedUser);  
                            break;
                        case 11:
                           GetAllGroups(general, loggedUser);
                            break;
                        case 12:
                            GetUserGroup(general, loggedUser);
                            break;
                        case 14:
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
            
        }

      
        
    }

   
}
