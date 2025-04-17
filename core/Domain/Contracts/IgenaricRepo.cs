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
        Task<IEnumerable<Tentity>> GetAllAsync(bool TrackChanges=false);
        Task<Tentity?> GetByIdAsync(TKey Id);
        Task Addasync(Tentity entity);
        void Delete(Tentity entity);
        void Update(Tentity entity);

        #region specification

        Task<IEnumerable<Tentity>> GetAllWithSpecificationAsync(Specifications<Tentity> specifications);

        Task<Tentity?> GetByIdlWithSpecificationAsync(Specifications<Tentity> specifications);
        #endregion

    }
}
