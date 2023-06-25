using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPISolution.Models.Entities
{
    public class Product
    {
    [Key]
    public long ProductId { get; set; }
    [Required, StringLength(maximumLength: 150, MinimumLength = 4)]
    public string ProductName { get; set; }
    [Required, StringLength(maximumLength: 150, MinimumLength = 4)]
    public string Description { get; set; }
    [Required, Column(TypeName = "decimal(8,2)") ]
    public decimal Price { get; set; }
    [Required, StringLength(maximumLength: 150, MinimumLength = 4)]
    public string Category { get; set; }
  }
}
