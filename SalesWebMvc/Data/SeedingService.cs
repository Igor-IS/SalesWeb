using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecords.Any())
            {
                return; // DB has been seeded
            }

            Department dep1 = new Department(1, "Computers");
            Department dep2 = new Department(2, "Eletronic");
            Department dep3 = new Department(3, "Fashion");
            Department dep4 = new Department(4, "Personal");


            Seller seller1 = new Seller(1, "Igor Silva", "igorsevenn@gmail.com", new DateTime(1993, 04, 22), 3500, dep1);
            Seller seller2 = new Seller(2, "Italo Silva", "italosevenn@gmail.com", new DateTime(1997, 12, 31), 4000, dep3);
            Seller seller3 = new Seller(3, "Iago Silva", "iagosevenn@gmail.com", new DateTime(2002, 08, 02), 3800, dep2);
            Seller seller4 = new Seller(4, "Rose Morais", "arnaldolimateam@gmail.com", new DateTime(1974, 04, 19), 5000, dep4);
            Seller seller5 = new Seller(5, "Arnaldo Lima", "arnaldolimapersonal@gmail.com", new DateTime(1984, 06, 12), 10000, dep4);
            Seller seller6 = new Seller(6, "Vanessa Morais", "vanessamorais@gmail.com", new DateTime(1986, 05, 10), 8000, dep3);

            SalesRecord record1 = new SalesRecord(1, new DateTime(2020, 07, 10), 1250.0, SaleStatus.Billed, seller1);
            SalesRecord record2 = new SalesRecord(2, new DateTime(2020, 06, 01), 3000.0, SaleStatus.Pending, seller6);
            SalesRecord record3 = new SalesRecord(3, new DateTime(2020, 05, 25), 1945.0, SaleStatus.Billed, seller4);
            SalesRecord record4 = new SalesRecord(4, new DateTime(2020, 01, 20), 1000.0, SaleStatus.Billed, seller3);
            SalesRecord record5 = new SalesRecord(5, new DateTime(2020, 07, 10), 5050.0, SaleStatus.Billed, seller1);
            SalesRecord record6 = new SalesRecord(6, new DateTime(2020, 06, 01), 300.0, SaleStatus.Pending, seller6);
            SalesRecord record7 = new SalesRecord(7, new DateTime(2020, 05, 25), 145.0, SaleStatus.Billed, seller4);
            SalesRecord record8 = new SalesRecord(8, new DateTime(2020, 01, 20), 1680.0, SaleStatus.Billed, seller3);
            SalesRecord record9 = new SalesRecord(9, new DateTime(2020, 07, 10), 1250.0, SaleStatus.Canceled, seller2);
            SalesRecord record10 = new SalesRecord(10, new DateTime(2020, 06, 01), 370.0, SaleStatus.Pending, seller6);
            SalesRecord record11 = new SalesRecord(11, new DateTime(2020, 07, 25), 1945.0, SaleStatus.Billed, seller4);
            SalesRecord record12 = new SalesRecord(12, new DateTime(2020, 11, 20), 12050.0, SaleStatus.Billed, seller3);

            _context.Department.AddRange(dep1, dep2, dep3, dep4);

            _context.Seller.AddRange(seller1, seller2, seller3, seller4, seller5, seller6);

            _context.SalesRecords.AddRange(record1, record2, record3, record4, record5, record6, record7, record8, record9, record10, record11, record12);

            _context.SaveChanges();
        }
    }
}
