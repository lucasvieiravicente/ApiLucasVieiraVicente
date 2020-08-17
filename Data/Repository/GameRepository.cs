using ApiLucasVieiraVicente.Data.Context;
using ApiLucasVieiraVicente.Data.Repository.Interfaces;
using ApiLucasVieiraVicente.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLucasVieiraVicente.Data.Repository
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(GameContext context) : base(context)
        {
        }

        public Game GetByName(string name) => base.DbSet.Where(w => w.Name.ToUpper() == name.ToUpper()).FirstOrDefault();

        public IEnumerable<Game> GetByGenre(GameGenre genre) => base.DbSet.Where(w => w.GameGenre == genre);
    }
}
