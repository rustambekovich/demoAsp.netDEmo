using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace demoAsp.netDemo.Domain.Exceptions
{
    public class NotFoundException
    {
        public HttpStatusCode StatusCode { get;} = HttpStatusCode.NotFound;
        public string TitilMessege { get; protected set; } = string.Empty;
    }
}
