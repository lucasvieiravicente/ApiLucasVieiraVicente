using ApiLucasVieiraVicente.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLucasVieiraVicente.Data.Repository.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Game GetByName(string name);
        IEnumerable<Game> GetByGenre(GameGenre genre);
    }
}
