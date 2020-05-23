using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Core
{
    public interface IHeroRepository
    {
        Task<IEnumerable<Hero>> GetAllAsync();
    }
}