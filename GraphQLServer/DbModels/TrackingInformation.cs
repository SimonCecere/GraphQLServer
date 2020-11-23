using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.DbModels
{
    //Tracking Information

    public class TrackingInformation
    {
        [Key]
        public int Id { get; set; }

        public DateTime ShippedDateTime { get; set; }

        [MaxLength(255)]
        public string TrackingNumber { get; set; }

        [ForeignKey("SubmissionId")]
        public Submission Submission { get; set; }
        public int SubmissionId { get; set; }
    }
}
