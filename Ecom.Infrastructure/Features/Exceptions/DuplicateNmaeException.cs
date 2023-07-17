using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Features.Exceptions
{
    public class DuplicateNmaeException : Exception
    {
        public DuplicateNmaeException( string message): base(message)
        {
            
        }
    }
}
