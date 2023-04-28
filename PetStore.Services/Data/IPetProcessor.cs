using PetStoreEFData.Models;
using System.Collections.Generic;

namespace PetStore.Services.Data
{
    public interface IPetProcessor
    {
        void Delete(int id);
        int Insert(string name, int petTypeId, DateTime dateOfBirth, Decimal weight);
        void Update(int id, string name, int petTypeId, DateTime dateOfBirth, Decimal weight);
    }
}