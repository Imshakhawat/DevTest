﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Application.Features.Training.Services
{
    public interface IProductRegistrationService
    {
        public void Register(string CategoryId, Guid ProductId);
    }
}
