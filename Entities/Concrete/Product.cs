using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string productName { get; set; }
        public decimal price { get; set; }
        public string starttime { get; set; }
        public decimal endprice { get; set; }
        public string endtime { get; set; }
        public bool  status { get; set; }

    }
}
