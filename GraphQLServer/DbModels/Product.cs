using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.DbModels
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45)]
        public string Description { get; set;}

        [MaxLength(10)]
        public string SKU { get; set; }

        [MaxLength(10)]
        public string MethodOfShipment { get; set; }

        public int Inventory { get; set; }

        public int Buffer { get; set; }

    }
}
