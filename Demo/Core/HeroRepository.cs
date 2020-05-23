using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Core
{
    internal sealed class HeroRepository : IHeroRepository
    {
        private readonly IList<Hero> _heroes;

        public HeroRepository()
        {
            _heroes = new List<Hero>
            {
                new Hero {Id = Guid.NewGuid(), Name = "Wolverine"},
                new Hero {Id = Guid.NewGuid(), Name = "Captain America"},
                new Hero {Id = Guid.NewGuid(), Name = "Superman"},
                new Hero {Id = Guid.NewGuid(), Name = "Batman"},
                new Hero {Id = Guid.NewGuid(), Name = "Incredible Hulk"}
            };
        }

        public Task<IEnumerable<Hero>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Hero>>(_heroes);
        }
    }
}