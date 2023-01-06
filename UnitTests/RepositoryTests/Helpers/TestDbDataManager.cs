using Domain.Core.Models;
using Infrastructure.Data;
using Infrastructure.Services.Helpers;
using System;
using System.Collections.Generic;

namespace UnitTests.RepositoryTests.Helpers
{
    public class TestDbDataManager
    {
        private static bool isInitialized = false;

        private RepositoryContext _context;
        private DateTimeConverter _dateTimeConverter;

        public TestDbDataManager(RepositoryContext context, DateTimeConverter dateTimeConverter)
        {
            _context = context;
            _dateTimeConverter = dateTimeConverter;
        }

        public void Load()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Email = "email@gmail.com",
                    UserName = "email@gmail.com"
                },
                new User()
                {
                    Email = "email2@gmail.com",
                    UserName = "email2@gmail.com"
                }
            };

            _context.Users.AddRange(users);
            _context.SaveChanges();


            _context.UsersInfo.AddRange(
                new UserInfo()
                {
                    UserId = users[0].Id
                },
                new UserInfo()
                {
                    UserId = users[1].Id
                }
            );
            _context.SaveChanges();


            var farms = new List<Farm>()
            {
                new Farm()
                {
                    Name = "Farm1",
                    UserId = users[0].Id
                },
                new Farm()
                {
                    Name = "Farm2",
                    UserId = users[1].Id
                }
            };
            _context.Farms.AddRange(farms);
            _context.SaveChanges();


            var farmFriends = new List<FarmFriend>()
            {
                new FarmFriend(){
                    FarmId = farms[0].Id,
                    UserId = users[1].Id
                }
            };
            _context.FarmFriends.AddRange(farmFriends);
            _context.SaveChanges();


            var bodies = new List<PetBody>()
            {
                new PetBody()
                {
                    PictureName = "body1.png"
                }
            };
            _context.PetBodies.AddRange(bodies);
            _context.SaveChanges();


            var eyes = new List<PetEyes>()
            {
                new PetEyes()
                {
                    PictureName = "eyes1.png"
                }
            };
            _context.PetEyes.AddRange(eyes);
            _context.SaveChanges();


            var mouths = new List<PetMouth>()
            {
                new PetMouth()
                {
                    PictureName = "mouth1.png"
                }
            };
            _context.PetMouths.AddRange(mouths);
            _context.SaveChanges();


            var noses = new List<PetNose>()
            {
                new PetNose()
                {
                    PictureName = "nose1.png"
                }
            };
            _context.PetNoses.AddRange(noses);
            _context.SaveChanges();


            var pets = new List<Pet>()
            {
                new Pet()
                {
                    Name = "Pet1",
                    HungerValue = 60,
                    ThirstValue = 60,
                    FarmId = farms[0].Id,
                    BirthDate = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 19:00:01")),
                    DeathDate = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-18 19:00:01")),
                    LastPetDetailsUpdatingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 21:00:01")),
                    HappinessDaysCount = 0,
                    BodyId = bodies[0].Id,
                    EyesId = eyes[0].Id,
                    MouthId = mouths[0].Id,
                    NoseId = noses[0].Id
                },
                new Pet()
                {
                    Name = "Pet2",
                    HungerValue = 40,
                    ThirstValue = 40,
                    FarmId = farms[0].Id,
                    BirthDate = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 19:00:01")),
                    DeathDate = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-19 19:00:01")),
                    LastPetDetailsUpdatingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 21:00:01")),
                    HappinessDaysCount = 0,
                    BodyId = bodies[0].Id,
                    EyesId = eyes[0].Id,
                    MouthId = mouths[0].Id,
                    NoseId = noses[0].Id
                },
                new Pet()
                {
                    Name = "Pet3",
                    HungerValue = 20,
                    ThirstValue = 20,
                    FarmId = farms[0].Id,
                    BirthDate = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 19:00:01")),
                    DeathDate = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-19 19:00:01")),
                    LastPetDetailsUpdatingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 21:00:01")),
                    HappinessDaysCount = 0,
                    BodyId = bodies[0].Id,
                    EyesId = eyes[0].Id,
                    MouthId = mouths[0].Id,
                    NoseId = noses[0].Id
                },
                new Pet()
                {
                    Name = "Pet4",
                    HungerValue = 80,
                    ThirstValue = 80,
                    FarmId = farms[0].Id,
                    BirthDate = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-10 19:00:01")),
                    DeathDate = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 21:00:01")),
                    LastPetDetailsUpdatingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 21:00:01")),
                    HappinessDaysCount = 0,
                    BodyId = bodies[0].Id,
                    EyesId = eyes[0].Id,
                    MouthId = mouths[0].Id,
                    NoseId = noses[0].Id
                },
                new Pet()
                {
                    Name = "Pet5",
                    HungerValue = 80,
                    ThirstValue = 80,
                    FarmId = farms[1].Id,
                    BirthDate = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-10 19:00:01")),
                    DeathDate = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 21:00:01")),
                    LastPetDetailsUpdatingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 21:00:01")),
                    HappinessDaysCount = 0,
                    BodyId = bodies[0].Id,
                    EyesId = eyes[0].Id,
                    MouthId = mouths[0].Id,
                    NoseId = noses[0].Id
                }
            };
            _context.Pets.AddRange(pets);
            _context.SaveChanges();


            var feedingEvents = new List<FeedingEvent>()
            {
                new FeedingEvent()
                {
                    PetId = pets[0].Id,
                    FeedingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 19:00:01"))
                },
                new FeedingEvent()
                {
                    PetId = pets[0].Id,
                    FeedingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 20:00:01"))
                },
                new FeedingEvent()
                {
                    PetId = pets[0].Id,
                    FeedingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 20:50:01"))
                },
                new FeedingEvent()
                {
                    PetId = pets[0].Id,
                    FeedingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 21:00:01"))
                },
                new FeedingEvent()
                {
                    PetId = pets[1].Id,
                    FeedingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 19:00:01"))
                },
                new FeedingEvent()
                {
                    PetId = pets[1].Id,
                    FeedingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 20:30:01"))
                },
                new FeedingEvent()
                {
                    PetId = pets[1].Id,
                    FeedingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 21:00:01"))
                },
            };
            _context.FeedingEvents.AddRange(feedingEvents);
            _context.SaveChanges();

            var thirstQuenchingEvents = new List<ThirstQuenchingEvent>()
            {
                new ThirstQuenchingEvent()
                {
                    PetId = pets[0].Id,
                    ThirstQuenchingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 19:00:01"))
                },
                new ThirstQuenchingEvent()
                {
                    PetId = pets[0].Id,
                    ThirstQuenchingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 20:00:01"))
                },
                new ThirstQuenchingEvent()
                {
                    PetId = pets[0].Id,
                    ThirstQuenchingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 20:50:01"))
                },
                new ThirstQuenchingEvent()
                {
                    PetId = pets[0].Id,
                    ThirstQuenchingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 21:00:01"))
                },
                new ThirstQuenchingEvent()
                {
                    PetId = pets[1].Id,
                    ThirstQuenchingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 19:00:01"))
                },
                new ThirstQuenchingEvent()
                {
                    PetId = pets[1].Id,
                    ThirstQuenchingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 20:30:01"))
                },
                new ThirstQuenchingEvent()
                {
                    PetId = pets[1].Id,
                    ThirstQuenchingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-01 21:00:01"))
                },
            };
            _context.ThirstQuenchingEvents.AddRange(thirstQuenchingEvents);
            _context.SaveChanges();
        }

        public void RemoveAll()
        {
            _context.FeedingEvents.RemoveRange(_context.FeedingEvents);
            _context.ThirstQuenchingEvents.RemoveRange(_context.ThirstQuenchingEvents);
            _context.Pets.RemoveRange(_context.Pets);
            _context.PetBodies.RemoveRange(_context.PetBodies);
            _context.PetEyes.RemoveRange(_context.PetEyes);
            _context.PetMouths.RemoveRange(_context.PetMouths);
            _context.PetNoses.RemoveRange(_context.PetNoses);
            _context.FarmFriends.RemoveRange(_context.FarmFriends);
            _context.Farms.RemoveRange(_context.Farms);
            _context.UsersInfo.RemoveRange(_context.UsersInfo);
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();
        }

        public void Initialize()
        {
            if (isInitialized) return;
            RemoveAll();
            Load();
            isInitialized = true;
        }
    }
}
