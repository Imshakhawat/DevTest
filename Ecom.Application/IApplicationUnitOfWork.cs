using Ecom.Application.Features.Training.Repositories;
using Ecom.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IProductRepository Products { get; }

    }
}
