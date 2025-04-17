using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using presistance.Data;

namespace presistance.Reposatories
{
    public class GenaricRepo<Tentity, TKey> : IgenaricRepo<Tentity, TKey> where Tentity : BaseEntity<TKey>
    {
        private readonly storeContext _storeContext;
        public GenaricRepo(storeContext storeContext) {

            _storeContext = storeContext;
        }

        public storeContext StoreContext { get; }

        public async Task Addasync(Tentity entity)
        => await _storeContext.Set<Tentity>().AddAsync(entity);

        public void Update(Tentity entity)
        => _storeContext.Set<Tentity>().Update(entity);

        public void Delete(Tentity entity)
         => _storeContext.Set<Tentity>().Remove(entity);


        public async Task<IEnumerable<Tentity>> GetAllAsync(bool TrackChanges=false)
         =>TrackChanges? await _storeContext.Set<Tentity>().ToListAsync()
            :await _storeContext.Set<Tentity>().AsNoTracking().ToListAsync();

        public async Task<Tentity?> GetByIdAsync(TKey Id)
        => await _storeContext.Set<Tentity>().FindAsync(Id);



        #region specification

        public async Task<IEnumerable<Tentity>> GetAllWithSpecificationAsync(Specifications<Tentity> specifications)
            => await Applyspecifications(specifications).ToListAsync();


        public async Task<Tentity?> GetByIdlWithSpecificationAsync(Specifications<Tentity> specifications)
            => await Applyspecifications(specifications).FirstOrDefaultAsync();

            private IQueryable<Tentity> Applyspecifications(Specifications<Tentity> specifications)
            => SpecificationEvaluator.GetQuery(_storeContext.Set<Tentity>(), specifications);
        #endregion

    }
}
