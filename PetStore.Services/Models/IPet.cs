namespace PetStoreEFData.Models
{
    public interface IPet
    {
        DateTime DateOfBirth { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        PetType PetType { get; set; }
        decimal Weight { get; set; }
    }
}