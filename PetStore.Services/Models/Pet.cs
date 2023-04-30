using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreEFData.Models
{
    public class Pet : IPet
    {
        [Required] 
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public PetType PetType { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Decimal Weight { get; set; }

    }
}
