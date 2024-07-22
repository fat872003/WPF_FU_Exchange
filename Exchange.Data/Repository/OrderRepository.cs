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
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository() { }
        public async Task<List<Order>> getAllMyOwnOder(int custromerId)
        {

        
            return null;

        }

        public async Task<List<Order>> getAllMyOwnOderByName(String name, int custromerId)
        {

        //    return await _dbSet.Where(x => (x.OrderDetail.ProductUserWant.Product.CustomerId == custromerId || x.OrderDetail.ProductUserHave.Product.CustomerId == custromerId) && (x.OrderDetail.ProductUserWant.Product.Name.ToLower().Contains(name.ToLower()) || x.OrderDetail.ProductUserHave.Product.Name.ToLower().Contains(name.ToLower())))
           //   .Include(x => x.OrderDetail)
         //     .ThenInclude(od => od.ProductUserWant)
          //    .ThenInclude(puw => puw.Product)
          //    .Include(x => x.OrderDetail)
             // .ThenInclude(od => od.ProductUserHave)
           //   .ThenInclude(puh => puh.Product)
           //   .ToListAsync();
            return null;
        }
        public async Task<Order> getAOderDetail(int orderID)
        {
            return await _dbSet.Where(o=>o.OrderId==orderID).Include(p=>p.OrderType).FirstOrDefaultAsync();

        }
        public async Task<Order> getAOderDetailByUserHaveID(int userHaveID)
        {

        //    return await _dbSet
    //       .Where(x => x.OrderDetail.ProductUserHaveId == userHaveID)
           //.Include(x => x.OrderDetail)
        //       .ThenInclude(od => od.ProductUserHave).ThenInclude(p => p.Product)
        //   .FirstOrDefaultAsync();
            return null;

        }
        public async Task<Order> getAOderDetailByUserWantID(int userWantID)
        {

          //  return await _dbSet
        //   .Where(x => x.OrderDetail.ProductUserWantId == userWantID)
          // .Include(x => x.OrderDetail)
        //       .ThenInclude(od => od.ProductUserWant)
       //    .FirstOrDefaultAsync();
            return null;

        }

        public async Task<List<Order>> getOderDetailListByUserHaveID(int customerID)
        {

           // return await _dbSet
         //  .Where(x => x.CustomerId == customerID && x.OrderDetail.ProductUserHave.Product.CustomerId == customerID)
         ////  .Include(x => x.OrderDetail)
        //       .ThenInclude(od => od.ProductUserHave).ThenInclude(p => p.Product)
         //  .ToListAsync();
            return null;

        }

        public async Task<List<Order>> getOderDetailListByUserWantID(int customerID)
        {

          //  return await _dbSet
         //  .Where(x => x.CustomerId == customerID && x.OrderDetail.ProductUserHave.Product.CustomerId != customerID)
        //   .Include(x => x.OrderDetail)
         //      .ThenInclude(od => od.ProductUserWant)
         //  .ToListAsync();
            return null;

        }


    }
}
