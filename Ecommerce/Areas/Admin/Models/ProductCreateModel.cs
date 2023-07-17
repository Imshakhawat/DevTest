using Autofac;
using Ecom.Application.Features.Training.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Areas.Admin.Models
{
    public class ProductCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required, Range(0, 5000, ErrorMessage = "Price should be between 0 & 5000")]
        public double Price { get; set; }
        private IProductService _productService;

        public ProductCreateModel()
        {

        }

        public ProductCreateModel(IProductService productService)
        {
            _productService = productService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _productService = scope.Resolve<IProductService>();
        }

        internal void CreateProduct()
        {
            if (!string.IsNullOrWhiteSpace(Name)
                && Price >= 0)
            {
                _productService.CreateProduct(Name, Price);
            }
        }
    }
}
