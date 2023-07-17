using Autofac;
using Ecom.Application.Features.Training.Services;
using Ecom.Domain.Entity;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Areas.Admin.Models
{
    public class ProductUpdateModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, Range(0, 5000, ErrorMessage = "Price should be between 0 & 5000")]
        public double Price { get; set; }
        private IProductService _productService;

        public ProductUpdateModel()
        {

        }

        public ProductUpdateModel(IProductService productService)
        {
            _productService = productService;
          
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _productService = scope.Resolve<IProductService>();
        }

        internal void Load(Guid id)
        {
            Product product = _productService.GetProduct(id);
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
        }

        internal void UpdateProduct()
        {
            if (!string.IsNullOrWhiteSpace(Name)
                && Price >= 0)
            {
                
                _productService.updateProduct(Id, Name, Price);
            }
        }

    }
}
