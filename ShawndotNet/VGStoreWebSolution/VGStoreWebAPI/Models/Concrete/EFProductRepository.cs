using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGStoreWebAPI.Models.Abstract;
using VGStoreWebAPI.Models.Entities;

namespace VGStoreWebAPI.Models.Concrete
{
  public class EFProductRepository : IProductRepository
  {
    private readonly VGStoreDbContext _context;

    public EFProductRepository(VGStoreDbContext context)
    {
      _context = context;
    }
    public IQueryable<Product> Products => _context.Products.AsQueryable();

    public Product AddProduct(Product product)
    {
      _context.Products.Add(product);
      int recEffected = _context.SaveChanges();
      if(recEffected == 1)
      {
        return product;
      }
      return product;
    }

    public bool DeleteProduct(long productId)
    {
      Product prod = _context.Products.Find(productId);
      if(prod != null)
      {
        _context.Remove(prod);
        int recEffected = _context.SaveChanges();
        if (recEffected == 1)
        {
          return true;
        }
      }
      return false;
    }

    public Product GetProductbyId(long ProductId) => _context.Products.Find(ProductId);

    public IEnumerable<Product> GetProducts() => _context.Products.ToList();

    public Product UpdateProduct(Product product)
    {
      _context.Entry<Product>(product).State = EntityState.Modified;
      int recEffected = _context.SaveChanges();
      if(recEffected ==1)
      {
        return product;
      }
      return product;

    }
  }
}
