using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.DbModels
{
    [Table("Submission")]
    public class Submission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(36)]
        [Column("ClientSubmissionId")]
        public string ClientSubmissionId { get; set; }

        public DateTime DateTime { get; set; }

        [MaxLength(75)]
        public string FirstName { get; set; }

        [MaxLength(75)]
        public string LastName { get; set; }

        [MaxLength(150)]
        public string Address1 { get; set; }

        [MaxLength(150)]
        public string Address2 { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(2)]
        public string State { get; set; }

        [MaxLength(20)]
        public string PostalCode { get; set; }

        [MaxLength(3)]
        public string CountryCode { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(45)]
        public string Status { get; set; }

    }
}
