using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.Basket;
using Services.Abstractions;
using shared;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IBasketService> _basketService;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper, IBasketRepo basketRepo) {
            _productService=new Lazy<IProductService>(()=> new ProductService(unitOfWork, mapper));
            _basketService = new Lazy<IBasketService>(() => new BasketService(basketRepo, mapper));

        }
        public IProductService ProductService => _productService.Value;

        public IBasketService BasketService => _basketService.Value;
    }

    public interface IMapper
    {
        T Map<T>(IEnumerable<productBrand> brand);
        T Map<T>(IEnumerable<Product> products);
        T Map<T>(IEnumerable<productType> types);
        T Map<T>(Product? products);
        T Map<T>(CustomerBasket basket);
        object Map<T>(BasketDto basket);
        T Map<T>(object basketDto);
        object Map<T>(object shippingAdress);
    }
}
