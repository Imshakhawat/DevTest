using Ecom.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Application.Features.Training.Services
{
    public interface IProductService
    {
        void CreateProduct(string name, double fees);
        void DeleteProduct(Guid ProductId);

        Product GetProduct(Guid ProductId);

        public IList<Product> GetProducts();

        Task<(IList<Product> records, int total,int totalDisplay)>
            GetPagedProductsAsync(int pageIndex, int pageSize, string searchText, String Orderby);

        void updateProduct(Guid id, string Name, double fees);


    }
}
