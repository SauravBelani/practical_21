using DAl.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace DAl
{
    public class Service
    {
        private readonly ApplicationDbContext context;

        public Service(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddEmployee(DALEmployee employee)
        {
            if(employee==null)
            {
                return false;
            }
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<DALEmployee>> GetAllEmployees()
        {
            var employees = await context.Employees.Include(x=>x.Department).Where(x=>x.Status==false).ToListAsync();
            return employees;
        }

        public async Task DeleteEmployee(int id)
        {
            var employee= await GetEmployee(id);
            employee.Status = true;
            context.Update(employee);
            await context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(DALEmployee employee)
        {
            context.Update(employee);
            await context.SaveChangesAsync();
        }

        public async Task<DALEmployee> GetEmployee(int? id)
        {
            if(id == null)
            {
                return null;
            }
            return await context.Employees.FindAsync(id);
        }

        public async Task<bool> IsEmployeeExist(int id)
        {
            var entity = await GetEmployee(id);
            return entity!=null;
        }

    }
}
