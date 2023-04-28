using PetStoreEFData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Services.Data
{
    public class PetRepository : IPetRepository
    {
        public List<IPet> GetPets(int? petTypeId, int? startPage, int? endPage, int? pageSize, string? petName)
        {
            return new List<IPet>();
        }

        public IPet GetPet(int id)
        {
            return new Pet();
        }

        public List<IPet> GetPetsByNameDOB(string name, DateTime dateOfBirth)
        {
            return new List<IPet>();
        }



    }
}
