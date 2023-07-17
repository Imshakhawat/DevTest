using Ecom.Application;
using Ecom.Application.Features.Training.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Persistance
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IProductRepository Products { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            IProductRepository productRepository) : base((DbContext)dbContext)
        {
            Products = productRepository;
        }


    }
}

