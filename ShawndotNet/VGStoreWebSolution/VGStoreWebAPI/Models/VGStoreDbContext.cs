using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGStoreWebAPI.Models.Entities;

namespace VGStoreWebAPI.Models
{
  public class VGStoreDbContext : DbContext
  {
    public VGStoreDbContext(DbContextOptions<VGStoreDbContext> dbContextOptions) : base(dbContextOptions)
    { }

    public DbSet<Product> Products { get; set; }
  }
}
