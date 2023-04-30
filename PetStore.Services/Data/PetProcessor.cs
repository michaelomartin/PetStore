using PetStoreEFData.DataAccess;
using PetStoreEFData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Services.Data
{
    public class PetProcessor : IPetProcessor
    {
        protected readonly PetContext _context;
        public PetProcessor(PetContext context)
        {
            _context = context;
        }
        public int Insert(string name, int petTypeId, DateTime dateOfBirth, Decimal weight)
        {

            var petType = _context.PetTypes.FirstOrDefault(p => p.Id == petTypeId);

            var pet = new Pet { Name = name, PetType = petType, DateOfBirth = dateOfBirth, Weight = weight };

            _context.Pets.Add(pet);
            _context.SaveChanges();
          
            return pet.Id;
        }

        public void Update(int id, string name, int petTypeId, DateTime dateOfBirth, Decimal weight)
        {
            var pet = _context.Pets.FirstOrDefault(p => p.Id == id);
            var petType = _context.PetTypes.FirstOrDefault(p => p.Id == petTypeId);

            if (pet != null)
            {
                pet.Name = name;
                pet.PetType = petType;
                pet.DateOfBirth = dateOfBirth;
                pet.Weight = weight;

                _context.SaveChanges();
            }
         }

        public void Delete(int id)
        {
            var pet = _context.Pets.FirstOrDefault(p => p.Id == id);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                _context.SaveChanges();
            }
        }

    }
}
