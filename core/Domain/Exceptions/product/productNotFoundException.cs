using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.product
{
    public class productNotFoundException:NotFoundException
    {
        public productNotFoundException(int id):
            base($"product with Id{id} not found")
        { }
    }
}
