using BungBungShop.Data.Infrastructure;
using BungBungShop.Data.Repositories;
using BungBungShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungBungShop.Service
{
    public interface IProductService
    {
        Product Add(Product product);

        Product Delete(Product product);

        void Update(Product product);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyword);

        void Save();
    }

    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public Product Delete(Product product)
        {
            return _productRepository.Delete(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _productRepository.GetMulti(n => n.Name.Contains(keyword) || n.Description.Contains(keyword));
            }
            else
            {
                return _productRepository.GetAll();
            }
        }

        public void Save()
        {
            _unitOfWork.Comit();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
