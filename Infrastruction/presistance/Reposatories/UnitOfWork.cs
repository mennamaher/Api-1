using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using presistance.Data;

namespace presistance.Reposatories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly storeContext _storeContext;
        private readonly ConcurrentDictionary<string, object> _Repositories;

        public UnitOfWork(storeContext storeContext)
        {
            _storeContext = storeContext;
            _Repositories = new();
        }
        public IgenaricRepo<Tentity, TKey> GetRepo<Tentity, TKey>() where Tentity : BaseEntity<TKey>
        {
            var TypeName = typeof(Tentity).Name;
            if (_Repositories.ContainsKey(TypeName)) return (IgenaricRepo<Tentity, TKey>)_Repositories[TypeName];
            var Repository = new GenaricRepo<Tentity, TKey>(_storeContext);
            _Repositories.GetOrAdd(TypeName, Repository);
            return Repository;
        }

        public async Task<int> SaveChangesAsync()
        => await _storeContext.SaveChangesAsync();
    }
}
