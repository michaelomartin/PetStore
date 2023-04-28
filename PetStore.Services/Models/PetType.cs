using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreEFData.Models
{
    public class PetType : IPetType
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
