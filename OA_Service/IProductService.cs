using OA_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProduct();
        Product GetProductById(int Id);
        Product AddProduct(Product product);
    }
}
