using AutoMapper;
using ECommerceApp.ApplicationCore.Contracts.Repository;
using ECommerceApp.ApplicationCore.Contracts.Service;
using ECommerceApp.ApplicationCore.Entities;
using ECommerceApp.ApplicationCore.Model.Request;
using ECommerceApp.ApplicationCore.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.Services
{
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync productRepositoryAsync;
        private readonly IMapper mapper;

        public ProductServiceAsync(IProductRepositoryAsync productRepositoryAsync, IMapper mapper)
        {
            this.productRepositoryAsync = productRepositoryAsync;
            this.mapper = mapper;
        }
        public Task<int> DeleteProductAsync(int id)
        {
            return productRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync()
        {
            var collection = await productRepositoryAsync.GetAllAsync();
            List<ProductResponseModel> products = mapper.Map<List<ProductResponseModel>>(collection);
            return products;
        }

        public async Task<ProductResponseModel> GetProductByIdAsync(int id)
        {
            var item = await productRepositoryAsync.GetByIdAsync(id);

            if (item != null)
            {
                return mapper.Map<ProductResponseModel>(item);
            }
            return null;
        }

        public Task<int> InsertProductAsync(ProductRequestModel model)
        {
            Product item = mapper.Map<Product>(model);
            return productRepositoryAsync.InsertAsync(item);
        }

        public Task<int> UpdateProductAsync(int id, ProductRequestModel model)
        {
            if (id == model.Id)
            {
                Product item = mapper.Map<Product>(model);

                return productRepositoryAsync.UpdateAsync(item);
            }
            return Task.Run(() => { return 0; });
        }
    }
}
