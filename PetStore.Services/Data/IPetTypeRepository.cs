using PetStoreEFData.Models;

namespace PetStore.Services.Data
{
    public interface IPetTypeRepository
    {
        IEnumerable<IPetType> GetPetTypes();
    }
}