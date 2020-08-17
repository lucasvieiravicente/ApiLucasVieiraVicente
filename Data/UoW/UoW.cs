using ApiLucasVieiraVicente.Data.Context;
using ApiLucasVieiraVicente.Data.Repository;
using ApiLucasVieiraVicente.Data.Repository.Interfaces;
using ApiLucasVieiraVicente.Data.UoW.Interfaces;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLucasVieiraVicente.Data.UoW
{
    public class UoW : IUoW
    {
        private GameContext _context;
        private GameRepository _gameRepository = null;

        public UoW()
        {
            _context = new GameContext(new DbContextOptions<GameContext>());
        }

        public IGameRepository GameRepository
        {
            get
            {
                if(_gameRepository == null)
                {
                    _gameRepository = new GameRepository(_context);
                }

                return _gameRepository;
            }
        }

        public void Commit()
        {
            var saved = _context.SaveChanges() > 0;

            if (saved)
                Dispose();           
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
