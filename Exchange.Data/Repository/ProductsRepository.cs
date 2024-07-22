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
    public class ProductsRepository : GenericRepository<Product>
    {



        public ProductsRepository() { }



        public async Task<List<Product>> getAllAvailableMyProduct(int txtCustomerID)
        {
            return await _dbSet.Where(p => p.CustomerId == txtCustomerID&& p.Status==true).ToListAsync();
        }

        public async Task<List<Product>> getProductByName(String txtProductName, int txtCustomerID)
        {
            return await _dbSet.Where(p => p.Name.ToLower().Contains(txtProductName.ToLower()) && p.CustomerId == txtCustomerID).ToListAsync();
        }
        public async Task<List<Product>> getProductByTrueStatusAndName(String txtProductName, int txtCustomerID)
        {
            return await _dbSet.Where(p => p.Name.ToLower().Contains(txtProductName.ToLower()) && p.CustomerId == txtCustomerID && p.Status == true).ToListAsync();
        }
     
        public async Task<List<Product>> getMyAllProduct(int txtCustomerID)
        {
            return await _dbSet.Where(p => p.CustomerId == txtCustomerID ).ToListAsync();
        }

        public static implicit operator ProductsRepository(OrderTypeRepository v)
        {
            throw new NotImplementedException();
        }
    }
}
