using Ecom.Application;
using Ecom.Application.Features.Training.Services;
using Ecom.Domain.Entity;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ecom.Infrastructure.Features.Services
{
    public class ProductServices : IProductService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public ProductServices(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateProduct(string name, double price)
        {
            if (_unitOfWork.Products.IsDuplicateName(name, null))
                throw new DuplicateNameException("Product name is duplicate");

           Product product = new Product()
           {
               Name = name,
               Price = price
           };
           
            _unitOfWork.Products.Add(product);
         
            _unitOfWork.Save();
        }

        public void DeleteProduct(Guid ProductId)
        {
            _unitOfWork.Products.Remove(ProductId);
            
            _unitOfWork.Save();
        }

        public async Task<(IList<Product> records, int total, int totalDisplay)> GetPagedProductsAsync(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            return await Task.Run(() =>
            {
                var result = _unitOfWork.Products.GetDynamic(x => x.Name.Contains(searchText),
                orderBy, null, pageIndex, pageSize, true);

                return result;
            });
        }

        public Product GetProduct(Guid ProductId)
        {
            return _unitOfWork.Products.GetByID(ProductId);
        }

        public IList<Product> GetProducts()
        {
            return _unitOfWork.Products.GetAll();
        }

        public void updateProduct(Guid id, string Name, double Price)
        {
            if (_unitOfWork.Products.IsDuplicateName(Name, id))
                throw new DuplicateNameException("Product name is duplicate");

            Product product = _unitOfWork.Products.GetByID(id);
            product.Name = Name;
            product.Price = Price;

            _unitOfWork.Save();
        }

    }
}
