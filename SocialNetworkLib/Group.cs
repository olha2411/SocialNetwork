using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLib
{
    public class Group
    {
        List<GroupModel> groups;

        public Group(List<GroupModel> Groups)
        {
            groups = Groups;
        }
       
        public void AddGroup(int OwnerId, string Name, int IdGroup)
        {
            groups.Add(new GroupModel(IdGroup, OwnerId, Name));
        }
        
        public int GetOwner(int GroupId, int LoggedUserId)
        {
            LoggedUserModel Owner  = new LoggedUserModel();
            foreach (GroupModel G in groups)
            {
                if (G.GroupId == GroupId && G.OwnerId == LoggedUserId)
                {
                    Owner = new LoggedUserModel() { Id = G.OwnerId };
                }
            }
            return Owner.Id;
        }

        public bool IsGroup(int GroupId)
        {
            bool exist = false;
            foreach(GroupModel G in groups)
            {
                if(G.GroupId == GroupId)
                {
                    exist = true;
                }
            }
            return exist;
        }

        public int GetGroupId(string GroupName)
        {
            int Id = 0;
            foreach(GroupModel G in groups)
            {
                if(G.GroupName == GroupName)
                {
                    Id = G.GroupId;
                }
            }
            return Id;
        }

        public string GetGroupName(int GroupId)
        {
            string Name = "";
            foreach (GroupModel G in groups)
            {
                if (G.GroupId == GroupId)
                {
                    Name = G.GroupName;
                }
            }
            return Name;
        }

        public List<string> GetAllGroups()
        {
            List<string> group = new List<string>();
            foreach(GroupModel G in groups)
            {
                group.Add(G.GroupName);
            }
            return group;
        }
        
    }
}
