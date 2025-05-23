﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public abstract class Specifications<T>where T:class
    {
        public Specifications(Expression<Func<T, bool>>? Critera)
        {
            Critera = Critera;

            }
        public Expression<Func<T,bool>>? Critera { get; private set; }

        public List<Expression<Func<T, object>>>IncludeExpressions { get; private set; }

        #region for filtration $ sorting


        #endregion

        #region for paginaton

        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPagination { get; set; }



        #endregion

        protected void AddInclude(Expression<Func<T, object>> expression)
            => IncludeExpressions.Add(expression);

        protected void ApplyPaginaton (int pageIndex, int pageSize)
        {
            IsPagination = true;
            Take = pageSize;
            Skip = (pageIndex-1)*pageSize;
        }

    }
}
