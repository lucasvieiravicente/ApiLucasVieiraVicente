using ApiLucasVieiraVicente.Data.Context;
using ApiLucasVieiraVicente.Data.Repository.Interfaces;
using ApiLucasVieiraVicente.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLucasVieiraVicente.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        internal GameContext Context;
        internal DbSet<T> DbSet;

        public BaseRepository(GameContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public T GetById(Guid id) => DbSet.Where(w => w.Id == id).FirstOrDefault();

        public IEnumerable<T> GetAll() => DbSet.Where(w => !w.IsDeleted);

        public void Add(T entity) => DbSet.Add(entity);

        public void Update(T entity) => DbSet.Update(entity);

        public void Remove(T entity) => DbSet.Remove(entity);

        public void Remove(Guid id) => Remove(GetById(id));        
    }
}
