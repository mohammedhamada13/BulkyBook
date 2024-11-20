using BulkyBook.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Entities.ViewModels
{
	public class ShoppingCartVM
	{
        public IEnumerable<ShoppingCart> CartsList { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
