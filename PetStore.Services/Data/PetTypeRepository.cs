using PetStoreEFData.DataAccess;
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
        protected readonly PetContext _context;
        public PetTypeRepository(PetContext context)
        {
            _context = context;
        }
        public IEnumerable<IPetType> GetPetTypes()
        {
            var petTypes = _context.PetTypes.ToList();

            return petTypes;
        }
    }
}
