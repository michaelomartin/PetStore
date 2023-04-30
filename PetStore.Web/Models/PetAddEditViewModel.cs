using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStoreEFData.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Web.Models
{
    public class PetAddEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Pet Name")]
        [StringLength(200, ErrorMessage = "Pet name can't be more than 200 characters.")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Type Of Pet")]
        public int PetTypeId { get; set; }

        [Required]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DisplayName("Weight (kgs)")]
        [Range(0.01, 200.00, ErrorMessage = "Weight must be between 0.01 and 200.00 kgs")]
        public Decimal Weight { get; set; }


    }
}
