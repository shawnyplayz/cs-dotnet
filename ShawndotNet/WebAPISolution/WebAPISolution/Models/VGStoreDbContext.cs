using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPISolution.Models.Entities;

namespace WebAPIApp.Models
{
  public class VGStoreDbContext : DbContext
  {
    public VGStoreDbContext(DbContextOptions<VGStoreDbContext> dbContextOptions) : base (dbContextOptions)
    {
      
    }// To connect to Database

    public DbSet<Product> Products { get; set; }
  }
}
