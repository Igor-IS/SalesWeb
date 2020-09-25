using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //declaração de um tipo com ? na frente refere que esse paramentro é opcional!
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;
            if (minDate.HasValue)
            {
                result = result.Where(date => date.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(date => date.Date <= maxDate.Value);
            }
            return await result.Include(obj => obj.Seller).Include(obj => obj.Seller.Department).OrderByDescending(obj => obj.Date).ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;
            if (minDate.HasValue)
            {
                result = result.Where(date => date.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(date => date.Date <= maxDate.Value);
            }
            return await result.Include(obj => obj.Seller).Include(obj => obj.Seller.Department).OrderByDescending(obj => obj.Date).GroupBy(obj => obj.Seller.Department).ToListAsync();
        }


    }
}
