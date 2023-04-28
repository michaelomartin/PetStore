using PetStoreEFData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Services.Data
{
    public class PetTypeRepository : IPetTypeRepository
    {
        public List<IPetType> GetPetTypes()
        {
            return new List<IPetType>();
        }
    }
}
