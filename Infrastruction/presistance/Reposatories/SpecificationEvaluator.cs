using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace presistance.Reposatories
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<T> GetQuery<T>
            (
            IQueryable<T>inputQuery,
            Specifications<T> specifications
            ) where T : class
        {
            var Query = inputQuery;
            if(specifications.Critera is not null)Query=Query.Where(specifications.Critera);

            foreach(var item in specifications.IncludeExpressions)
            {
                Query = Query.Include(item);
            }
        }
    }
}
