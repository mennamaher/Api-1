using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Contracts
{
    public interface IgenaricRepo<Tentity, TKey> where Tentity : BaseEntity<TKey>
    {
        Task<IEnumerable<Tentity>> GetAllAsync(bool TrackChanges);
        Task<Tentity?> GetByIdAsync(TKey Id);
        Task Addasync(Tentity entity);
        void Delete(Tentity entity);
        void Update(Tentity entity);


    }
}
