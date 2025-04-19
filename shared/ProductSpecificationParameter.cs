using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared
{
    public class ProductSpecificationParameter
    {
        private const int MaxPageSize = 10;
        private const int DefaultPageSize = 10;

        public int? typeId { get; set; }
        public int? brandId { get; set; }
        public int pageIndex { get; set; } = 1;
        private int _pageSize;
        public int pageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }



    }
}
