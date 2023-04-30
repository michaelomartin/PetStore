using Microsoft.AspNetCore.Mvc.Rendering;
using PetStoreEFData.Models;

namespace PetStore.Web.Models
{
    public class ListViewModel
    {
        public IEnumerable<IPet> Pets { get; set; }

        public IEnumerable<SelectListItem> PetTypes { get; set; }

        public int? StartPage { get; set; }

        public int? EndPage { get; set; }

        public string? PetName { get; set; }

        public int? PetTypeId { get; set; }

    }
}
