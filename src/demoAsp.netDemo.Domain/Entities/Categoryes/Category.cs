using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoAsp.netDemo.Domain.Entities.Categoryes
{
    public class Category : Auditable
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImgaPath { get; set; } = string.Empty;
    }
}
