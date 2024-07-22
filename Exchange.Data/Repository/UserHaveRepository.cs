using Exchange.Data.Base;
using Exchange.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Data.Repository
{
    public class UserHaveRepository : GenericRepository<UserHave>
    {
        public UserHaveRepository() { }
        //=================================== Nam
        public async Task<List<UserHave>> GetAllUserHaveProductsAsync(int cus)
        {
            return await _dbSet.Where(p => p.Quantity>0&&p.Product.CustomerId!=cus&&p.Status==true)
                .Include(uh => uh.Product)
                .ThenInclude(p => p.Customer)
                .ToListAsync();
        }


        public async Task<List<UserHave>> SearchByNameAsync(string name, int cus)
        {
            return await _dbSet.Where(p => p.Quantity > 0 && p.Status == true && p.Product.CustomerId != cus && p.Product.Name.ToLower().Contains(name.ToLower()))
              .Include(uh => uh.Product)
              .ThenInclude(p => p.Customer)
              .ToListAsync();
        }


        //  
        public async Task<List<UserHave>> SearchMyListByNameAsync(string name, int cus)
        {
            return await _dbSet
            .Where(p => p.Product.Name.ToLower().Contains(name.ToLower()) && p.Product.CustomerId == cus&&p.Status==true).Include(p => p.Product)
             .ToListAsync();
        }
             public async Task<List<UserHave>> SearchMyListByDesAndNote(string name, int cus)
        {
            return await _dbSet.Where(p => p.Product.CustomerId == cus &&(p.Description.ToLower().Contains(name.ToLower())
            || p.Note.ToLower().Contains(name.ToLower()))).Include(p => p.Product).ToListAsync();
        }


        //================================================================

        public async Task<List<UserHave>> getListUserHavetByUserID(int txtCustomerID)
        {
            return await _dbSet.Where(p => p.Product.CustomerId == txtCustomerID).Include(p => p.Product).ToListAsync();
        }


        public async Task<UserHave> getAProductByUserID(int userHaveID)
        {
            return await _dbSet.Where(p=>p.ProductUserHaveId == userHaveID).Include(h=>h.Product).FirstOrDefaultAsync();
        }

        public async Task<UserHave> getAProductByUserHaveID(int userHaveID)
        {
            return await _dbSet
            .Where(p => p.ProductUserHaveId == userHaveID)
            .Include(p => p.Product.Customer)
             .FirstOrDefaultAsync();


        }

        public async Task<List<UserHave>> GetAllUserHaveProductsAsyncbyProductID(int productID)
        {
            return await _dbSet.Where(p => p.ProductId== productID)
                .ToListAsync();
        }

    }
}
