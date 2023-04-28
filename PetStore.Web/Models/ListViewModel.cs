using PetStoreEFData.Models;

namespace PetStore.Web.Models
{
    public class ListViewModel
    {
        public List<IPet> Pets { get; set; }

        public List<IPetType> PetTypes { get; set; }

        public int? StartPage { get; set; }

        public int? EndPage { get; set; }

        public string? PetName { get; set; }


    }
}
