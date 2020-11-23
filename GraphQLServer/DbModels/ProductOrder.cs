using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.DbModels
{

    [Table("ProductOrder")]
    public class ProductOrder
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SubmissionId")]
        public Submission Submission { get; set; }
        public int SubmissionId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public int QTY { get; set; }

    }
}
