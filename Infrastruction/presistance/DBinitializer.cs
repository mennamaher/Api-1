using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using presistance.Data;

namespace presistance
{
    public class DBinitializer : IDBintializer
    {
        private readonly storeContext _storeContext;
        public DBinitializer(storeContext storeContext) {
            _storeContext = storeContext;
                }
        public async Task InitializeAsync()
        {

            try
            {
                #region updating DBe

                if (!_storeContext.Database.GetPendingMigrations().Any())
                {
                    await _storeContext.Database.MigrateAsync();
                }
                #endregion

                #region product types

                if (!_storeContext.types.Any())
                {
                    var TypesData = await File.ReadAllTextAsync(@"..\Infrastruction\presistance\Data\seeding\types.json");

                    var Types = JsonSerializer.Deserialize<List<productType>>(TypesData);

                    if (Types is not null && Types.Any())
                    {
                        await _storeContext.types.AddRangeAsync(Types);
                        await _storeContext.SaveChangesAsync();
                    }
                }

                #endregion

                #region product brands


                if (!_storeContext.types.Any())
                {
                    var BrandssData = await File.ReadAllTextAsync(@"..\Infrastruction\presistance\Data\seeding\brands.json");

                    var Brands = JsonSerializer.Deserialize<List<productBrand>>(BrandssData);

                    if (Brands is not null && Brands.Any())
                    {
                        await _storeContext.brands.AddRangeAsync(Brands);
                        await _storeContext.SaveChangesAsync();
                    }
                }

                #endregion

                #region product 


                if (!_storeContext.products.Any())
                {
                    var ProductsData = await File.ReadAllTextAsync(@"..\Infrastruction\presistance\Data\seeding\products.json");

                    var Product = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                    if (Product is not null && Product.Any())
                    {
                        await _storeContext.products.AddRangeAsync(Product);
                        await _storeContext.SaveChangesAsync();
                    }
                }


                #endregion

            }
            catch (Exception ) {
                throw;
            }


        }
    }
}
