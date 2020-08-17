using ApiLucasVieiraVicente.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLucasVieiraVicente.Data.UoW.Interfaces
{
    public interface IUoW
    {
        IGameRepository GameRepository { get; }
        void Commit();
        void Dispose();
    }
}
