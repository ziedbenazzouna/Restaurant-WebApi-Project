using OA_DataAccess;
using OA_Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Service
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _repository.GetAll();
        }

        public Product GetProductById(int Id)
        {
            return _repository.GetById(Id);
        }
    }
}
