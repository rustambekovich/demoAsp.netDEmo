using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoAsp.netDemo.Domain.Entities
{
    public class Auditable : Base
    {
        public DateTime CareatAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
