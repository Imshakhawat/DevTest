using Ecom.Domain.Entity;
using Ecom.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Application.Features.Training.Repositories
{
    public interface IProductRepository : IRepository<Product,Guid>
    {
        bool IsDuplicateName(string name, Guid? id);
    }
}
