using PetStoreEFData.Models;

namespace PetStore.Services.Data
{
    public interface IPetRepository
    {
        List<IPet> GetPets(int? petTypeId, int? startPage, int? endPage, int? pageSize, string? petName);
        IPet GetPet(int id);

        List<IPet> GetPetsByNameDOB(string name, DateTime dateOfBirth);
    }
}