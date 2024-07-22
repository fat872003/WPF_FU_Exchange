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
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository() { }


        public async Task<Customer> GetCustomerByEmailAndPassAsync(string txtEmail, String txtPass)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Email == txtEmail && x.Password == txtPass);
            return result;
        }
        public Customer GetCustomerByEmailAndPass(string txtEmail, String txtPass) {
            return _dbSet.FirstOrDefault(x => x.Email == txtEmail && x.Password == txtPass);
        }

    }
}
