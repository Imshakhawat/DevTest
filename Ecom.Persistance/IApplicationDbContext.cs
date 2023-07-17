using Ecom.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Persistance
{
    public interface IApplicationDbContext
    {
        DbSet<Product> products {  get; set; }
    }
}
