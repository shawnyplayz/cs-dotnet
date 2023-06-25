using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGStoreWebAPI.Models.Entities;

namespace VGStoreWebAPI.Models.Abstract
{
  public interface IProductRepository
  {
    IQueryable<Product> Products { get; }
    Product AddProduct(Product product);
    Product UpdateProduct(Product product);
    bool DeleteProduct(long productId);

    IEnumerable<Product> GetProducts();
    Product GetProductbyId(long ProductId);
  }
}
