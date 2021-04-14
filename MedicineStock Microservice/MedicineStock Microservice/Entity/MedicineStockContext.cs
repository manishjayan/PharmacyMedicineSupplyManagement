using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicineStock_Microservice.Entity
{
    public class MedicineStockContext:DbContext
    {
       
            public MedicineStockContext(DbContextOptions<MedicineStockContext> option) : base(option)
            {

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Seed();
            }

            public DbSet<MedicineStock> MedicineStock { get; set; }
        
    }
}
