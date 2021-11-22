using Shop.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Client.ApiServices
{
    public interface IProductApiService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task<Product> CreateProduct(Product movie);
        Task<Product> UpdateProduct(Product movie);
        Task DeleteProduct(int id);
        //Task<UserInfoViewModel> GetUserInfo();
    }
}
