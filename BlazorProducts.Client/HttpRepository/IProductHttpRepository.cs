using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace BlazorProducts.Client.HttpRepository
{
    public interface IProductHttpRepository
    {
        Task<List<Product>> GetProducts();
    }
}