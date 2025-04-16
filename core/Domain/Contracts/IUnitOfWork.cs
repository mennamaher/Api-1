using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChangesAsync();
        IgenaricRepo<Tentity, TKey> GetRepo<Tentity, TKey>() where Tentity : BaseEntity<TKey>;
    }
}
