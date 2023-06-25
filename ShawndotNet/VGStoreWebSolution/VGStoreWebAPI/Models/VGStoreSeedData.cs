using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGStoreWebAPI.Models.Entities;

namespace VGStoreWebAPI.Models
{
  public static class VGStoreSeedData
  {
    public static void  PopulateVGStore(VGStoreDbContext context)
    {
      //VGStoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<VGStoreDbContext>();

      //if(context.Database.GetPendingMigrations().Any())
      //{
      //  context.Database.Migrate();
      //}
        List<Product> productList = new List<Product>
        {
          new Product { ProductName = "Oblivion", Category = "Role Playing Game", Price = 23.45m, Description = "The Best ARPG Game you can find.." },
          new Product { ProductName = "Skyrim", Category = "Role Playing Game", Description = "Bethesda's finest game", Price = 87.40m },
          new Product { ProductName = "Call of Duty", Category = "First Person Shooter", Description = "Stories from WWII", Price = 123.00m },
          new Product { ProductName = "Assassin's Creed", Category = "Action", Description = "Help the Assasins figh the tempelars", Price = 97.10m },
          new Product { ProductName = "FIFA21", Category = "Sports", Description = "Play the new FUT and career mode", Price = 133.99m },
          new Product { ProductName = "Uncharted 4", Category = "Adventure", Description = "Play Uncharted 4 the Thief's ending", Price = 23.99m },
          new Product { ProductName = "Euro Truck Simulator", Category = "Simulation", Description = "Drive convoys through europe", Price = 87.15m },
          new Product { ProductName = "Forza Horizon", Category = "Racing", Description = "Race against people all around the world", Price = 45m }
        };
        context.Products.AddRange(productList);
        context.SaveChanges();
    }
  }
}
