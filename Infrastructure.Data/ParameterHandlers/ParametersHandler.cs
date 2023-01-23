using Domain.Core.Models;
using Domain.Interfaces.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ParameterHandlers
{
    public static class ParametersHandler
    {
        public static IQueryable<Pet> PetParametersHandler(this IQueryable<Pet> pets, PetParameters parameters) {
            if (parameters.MinHungerLevel.HasValue)
                pets = pets.Where(e => e.HungerValue >= parameters.MinHungerLevel.Value);

            if (parameters.MaxHungerLevel.HasValue)
                pets = pets.Where(e => e.HungerValue <= parameters.MaxHungerLevel.Value);

            if (parameters.MinThirstLevel.HasValue)
                pets = pets.Where(e => e.ThirstValue >= parameters.MinThirstLevel.Value);

            if (parameters.MaxThirstLevel.HasValue)
                pets = pets.Where(e => e.ThirstValue <= parameters.MaxThirstLevel.Value);

            if (parameters.SortedBy is not null)
            {
                switch (parameters.SortedBy.ToLower())
                {
                    case "age":
                        pets = pets.OrderBy(e => e.BirthDate);
                        break;
                    case "hunger":
                        pets = pets.OrderBy(e => e.HungerValue);
                        break;
                    case "thirst":
                        pets = pets.OrderBy(e => e.ThirstValue);
                        break;
                }
            }

            return pets
                .PaginationParametersHandler(parameters);
        }

        public static IQueryable<TEntity> PaginationParametersHandler<TEntity>(this IQueryable<TEntity> entities, PaginationParameters parameters)
        {
            int entitiesCount = entities.Count();
            int pageSize = parameters.PageSize;
            int zeroCountOffset = (entitiesCount == 0 ? 1 : 0);
            if (parameters.PageNumber < 1 || parameters.PageNumber > (entitiesCount + pageSize - 1 + zeroCountOffset) / pageSize)
            {
                throw new ArgumentOutOfRangeException("Page number is out of range");
            }

            return entities
                .Skip((parameters.PageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
