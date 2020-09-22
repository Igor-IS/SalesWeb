using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} requerid")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} size must be between 2 and 30")]
        [Display(Name = "Department Name:")]
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
