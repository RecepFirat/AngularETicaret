using AngularETicaret.Core.DBModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularETicaret.Core.Interfaces
{
    public interface IProductRepository
    {/// <summary>
    /// set ID get data
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
        Task<Product> GetProductByIdAsync(int id);
        /// <summary>
        /// All Product list
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<Product>> GetProductAsync();//İçerisinde değişiklik yapamazsın sadece verileri tutabilecegimiz bir liste IReadOnlyList

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

    }
}
