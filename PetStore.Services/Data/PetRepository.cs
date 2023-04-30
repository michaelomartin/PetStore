using Microsoft.EntityFrameworkCore;
using PetStoreEFData.DataAccess;
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
        protected readonly PetContext _context;
        public PetRepository(PetContext context)
        {
            _context = context;
        }

        public IEnumerable<IPet> GetPets(int? petTypeId, int? startPage, int? endPage, int? pageSize, string? petName, string? sortOrder)
        {
            var pets = from p in _context.Pets select p;

            if (petTypeId.HasValue)
            {
                pets = pets.Where(s => s.PetType.Id == petTypeId);
            }

            if (!string.IsNullOrWhiteSpace(petName))
            {
                pets = pets.Where(s => s.Name.Contains(petName));
            }

            if (!string.IsNullOrWhiteSpace(sortOrder))
            {
                switch (sortOrder)
                {
                    case "Name":
                        pets = pets.OrderBy(p => p.Name);
                        break;
                    case "DateOfBirth":
                        pets = pets.OrderBy(p => p.DateOfBirth);
                        break;
                    case "Weight":
                        pets = pets.OrderBy(p => p.Weight);
                        break;
                }
            }

            return pets.ToList();
        }

        public IPet GetPet(int id)
        {
            var pet = _context.Pets.Include(o => o.PetType).FirstOrDefault(p => p.Id == id);

            return pet;
        }

        public IEnumerable<IPet> GetPetsByNameDOB(string name, DateTime dateOfBirth)
        {
            var pets = _context.Pets.Where(p => (p.Name == name) && (p.DateOfBirth == dateOfBirth)).ToList();

            return pets;
        }



    }
}
