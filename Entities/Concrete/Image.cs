using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Image:IEntity
    {
        public int id { get; set; }
        public int productId { get; set; }
        public string url { get; set; }
        public bool isMain { get; set; }
        public DateTime dateAdded { get; set; }
        public string publicId { get; set; }
    }
}
