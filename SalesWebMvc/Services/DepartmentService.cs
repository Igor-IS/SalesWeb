using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //para implementar as Task Async requer using System.Threading.Tasks;
        //foi necessario mudar de ToList para ToListAsync pois o ToList não é asyncrono
        //para usa o ToListAsync requer using Microsoft.EntityFrameworkCore;
        //sempre que for uma chamada async de declarala com um AWAIT!
        public async  Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(dep => dep.Name).ToListAsync();
        }

        /*
         * method syncrono que foi substtuido pelo FindAllAsync()
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(dep => dep.Name).ToList();
        }
        */
    }
}
