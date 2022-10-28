using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class RepositoryManager : IRepositoryManager
    {
        private IFarmsRepository _farmsRepository;
        private IPetsRepository _petsRepository;
        private IFarmFriendsRepository _farmFriendsRepository;
        private IFeedingEventsRepository _feedingEventsRepository;
        private IThirstQuenchingEventsRepository _thirstQuenchingEventsRepository;
        private IUsersInfoRepository _usersInfoRepository;
        private RepositoryContext _context;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
        }

        public IFarmsRepository Farms
        {
            get
            {
                if (_farmsRepository is null)
                    _farmsRepository = new FarmsRepository(_context);
                return _farmsRepository;
            }
        }

        public IPetsRepository Pets
        {
            get
            {
                if (_petsRepository is null)
                    _petsRepository = new PetsRepository(_context);
                return _petsRepository;
            }
        }

        public IFarmFriendsRepository FarmFriends
        {
            get
            {
                if (_farmFriendsRepository is null)
                    _farmFriendsRepository = new FarmFriendsRepository(_context);
                return _farmFriendsRepository;
            }
        }

        public IFeedingEventsRepository FeedingEvents
        {
            get
            {
                if (_feedingEventsRepository is null)
                    _feedingEventsRepository = new FeedingEventsRepository(_context);
                return _feedingEventsRepository;
            }
        }

        public IThirstQuenchingEventsRepository ThirstQuenchingEvents
        {
            get
            {
                if (_thirstQuenchingEventsRepository is null)
                    _thirstQuenchingEventsRepository = new ThirstQuenchingEventsRepository(_context);
                return _thirstQuenchingEventsRepository;
            }
        }

        public IUsersInfoRepository UsersInfo
        {
            get
            {
                if (_usersInfoRepository is null)
                    _usersInfoRepository = new UsersInfoRepository(_context);
                return _usersInfoRepository;
            }
        }

        public async Task SaveChangeAsync() => 
            await _context.SaveChangesAsync();
    }
}
