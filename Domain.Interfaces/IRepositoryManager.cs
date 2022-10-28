﻿using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryManager
    {
        IFarmsRepository Farms { get; }
        IPetsRepository Pets { get; }
        IFarmFriendsRepository FarmFriends { get; }
        IFeedingEventsRepository FeedingEvents { get; }
        IThirstQuenchingEventsRepository ThirstQuenchingEvents { get; }
        IUsersInfoRepository UsersInfo { get; }

        Task SaveChangeAsync();
    }
}
