using PetStoreEFData.Models;

namespace PetStore.Services.Data
{
    public interface IPetRepository
    {
        IEnumerable<IPet> GetPets(int? petTypeId, int? startPage, int? endPage, int? pageSize, string? petName, string? sortOrder);
        IPet GetPet(int id);

        IEnumerable<IPet> GetPetsByNameDOB(string name, DateTime dateOfBirth);
    }
}