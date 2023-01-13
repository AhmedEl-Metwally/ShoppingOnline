using Shopping_online.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping_online.Servies
{
    public interface IProductServices
    {
        Task<Product> GetProductByIdAsync(int id);

        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand >> GetProductBrandsAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

    }
}
