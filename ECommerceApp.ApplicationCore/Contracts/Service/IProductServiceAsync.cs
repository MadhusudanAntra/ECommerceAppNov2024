using ECommerceApp.ApplicationCore.Model.Request;
using ECommerceApp.ApplicationCore.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.ApplicationCore.Contracts.Service
{
    public interface IProductServiceAsync
    {
        Task<int> InsertProductAsync(ProductRequestModel model);
        Task<int> UpdateProductAsync(int id,  ProductRequestModel model);
        Task<int> DeleteProductAsync(int id);
        Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync();
        Task<ProductResponseModel> GetProductByIdAsync(int id);
    }
}
