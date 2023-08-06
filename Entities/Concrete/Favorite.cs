using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Favorite:IEntity
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public int userId { get; set; }
    }
}
