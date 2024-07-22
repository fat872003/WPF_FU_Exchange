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
    public class UserWantRepository : GenericRepository<UserWant>
    {
        public UserWantRepository() { }
        public async Task<UserWant> getAProductByUserWantID(int userWantID)
        {
            return await _dbSet
            .Where(p => p.ProductUserWantId == userWantID)
            .Include(p => p.Product.Customer)
             .FirstOrDefaultAsync();


        }
        public async Task<List<UserWant>> SearchByNameAsync(string name, int cus)
        {
            return await _dbSet
            .Where(p => p.Product.Name.ToLower().Contains(name.ToLower()) && p.Product.CustomerId != cus)
             .ToListAsync();
        }
        public async Task<List<UserWant>> getProductListByUserWantID(int userID)
        {
            return await _dbSet
           .Where(x => x.Product.CustomerId != userID)
            .Include(p => p.Product).ThenInclude(c => c.Customer)
             .ToListAsync();
        }

        public async Task<List<UserWant>> getAllListByProductID(int productID)
        {
            return await _dbSet
           .Where(x => x.ProductId == productID)
             .ToListAsync();
        }

        public async Task<List<UserWant>> getProductListByUserWantIDByDesAndNote(int userID,string Des)
        {
            return await _dbSet
           .Where(x => x.Product.CustomerId != userID &&( x.Description.ToLower().Contains(Des.ToLower())|| x.Note.ToLower().Contains(Des.ToLower())))
            .Include(p => p.Product).ThenInclude(c => c.Customer)
             .ToListAsync();
        }

    }
}
