using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Services.Abstractions;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper) {
            _productService=new Lazy<IProductService>(()=> new ProductService(unitOfWork, mapper));
                }
        public IProductService ProductService => _productService.Value;
    }

    public interface IMapper
    {
        T Map<T>(IEnumerable<productBrand> brand);
        T Map<T>(IEnumerable<Product> products);
        T Map<T>(IEnumerable<productType> types);
        T Map<T>(Product? products);
    }
}
