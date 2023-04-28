using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreEFData.Models
{
    public class Pet : IPet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PetTypeId { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Decimal Weight { get; set; }

    }
}
