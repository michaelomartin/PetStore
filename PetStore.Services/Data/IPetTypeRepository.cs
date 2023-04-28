using PetStoreEFData.Models;

namespace PetStore.Services.Data
{
    public interface IPetTypeRepository
    {
        List<IPetType> GetPetTypes();
    }
}