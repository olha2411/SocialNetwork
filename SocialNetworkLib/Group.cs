﻿using System;
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
        public int GetOwnerId(int GroupId)
        {
            int OwnerId = 0;
            foreach (GroupModel Id in groups)
            {
                if (Id.GroupId == GroupId)
                {
                    OwnerId = Id.OwnerId;
                }
            }
            return OwnerId;
        }
        public void AddGroup(int OwnerId, string Name, int IdGroup)
        {
            groups.Add(new GroupModel(IdGroup, OwnerId, Name));
        }
        public void DeleteGroup(int GroupId)                            //недороблено
        {
            groups.Remove(new GroupModel());
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
    }
}