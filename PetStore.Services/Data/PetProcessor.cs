using PetStoreEFData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Services.Data
{
    public class PetProcessor : IPetProcessor
    {
        public int Insert(string name, int petTypeId, DateTime dateOfBirth, Decimal weight)
        {
            
                       
            return 1;
        }

        public void Update(int id, string name, int petTypeId, DateTime dateOfBirth, Decimal weight)
        {

        }

        public void Delete(int id)
        {

        }

    }
}
