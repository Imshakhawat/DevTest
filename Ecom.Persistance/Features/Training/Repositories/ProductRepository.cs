using Ecom.Application.Features.Training.Repositories;
using Ecom.Domain.Entity;
using Ecommerce.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Persistance.Features.Training.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext context) : base((DbContext)context)
        {

        }
        public bool IsDuplicateName(string name, Guid? id)
        {
            int? existingProductCount = null;

            if(id.HasValue)
            {
                existingProductCount = GetCount(x => x.Name == name && x.Id == id.Value);
            }
            else
            {
                existingProductCount = GetCount(x=> x.Name == name);
            }

            return existingProductCount > 0;
        }


    }
}
