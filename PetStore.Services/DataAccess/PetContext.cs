using Microsoft.EntityFrameworkCore;
using PetStoreEFData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreEFData.DataAccess
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }

    }
}
