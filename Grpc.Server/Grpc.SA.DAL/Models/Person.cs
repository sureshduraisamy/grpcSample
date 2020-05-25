using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grpc.SA.DAL.Models
{
   public class Person
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string  FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string  LastName { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();

    }
}
