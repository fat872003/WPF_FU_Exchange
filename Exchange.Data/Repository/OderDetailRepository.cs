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
    public class OderDetailRepository : GenericRepository<OrderDetail>
    {
        public OderDetailRepository() { }
        public async Task<OrderDetail> getOrderDetailUserHaveByID(int orderDetailID)
        {

            return await _dbSet.Where(x => x.OrderDetailId == orderDetailID).Include(uw => uw.ProductUserHave).ThenInclude(p => p.Product).FirstOrDefaultAsync();


        }
        public async Task<OrderDetail> getOrderDetailUserWantByID(int orderDetailID)
        {

            return await _dbSet.Where(x => x.OrderDetailId == orderDetailID).Include(uw => uw.ProductUserWant).ThenInclude(p => p.Product).FirstOrDefaultAsync();


        }
        public async Task<List<OrderDetail>> getAllMyOrderDetail(int cusID) {

            return await _dbSet.Where(c => c.ProductUserHave.Product.CustomerId == cusID|| c.ProductUserWant.Product.CustomerId == cusID && c.Status == true)
                .Include(u=>u.ProductUserHave).ThenInclude(p=>p.Product).ToListAsync();
        }
        public async Task<List<OrderDetail>> getAllMyOrderDetailByMessOrAddress(int cusID,string name)
        {

            return await _dbSet.Where(c => (c.ProductUserHave.Product.CustomerId == cusID || c.ProductUserWant.Product.CustomerId == cusID && c.Status == true)
                && (c.Message .ToLower().Contains(name.ToLower()) || c.Address.ToLower().Contains(name.ToLower())
                ))
                .Include(u => u.ProductUserHave).ThenInclude(p => p.Product).ToListAsync();
        }
        public async Task<List<OrderDetail>> getAllMyWishList(int cusID)
        {

            return await _dbSet.Where(c => c.ProductUserHave.Product.CustomerId == cusID&&c.OrderId==null&&c.Status==true)
                .Include(u => u.ProductUserHave).ThenInclude(p => p.Product).ToListAsync();
        }
        public async Task<List<OrderDetail>> getAllMyWishListlByMessOrAddress(int cusID,string name)
        {

            return await _dbSet.Where(c => c.ProductUserHave.Product.CustomerId == cusID && c.OrderId == null && c.Status == true
             && (c.Message.ToLower().Contains(name.ToLower()) || c.Address.ToLower().Contains(name.ToLower())
            ))
                .Include(u => u.ProductUserHave).ThenInclude(p => p.Product).ToListAsync();
        }

        public async Task<List<OrderDetail>> getAllMyOrder(int cusID)
        {
            return await _dbSet
             .Where(od => (od.ProductUserHave.Product.CustomerId == cusID || od.ProductUserWant.Product.CustomerId == cusID)
                 && od.OrderId != null)
            .Include(od => od.Order.OrderType)
                .Include(od => od.ProductUserHave.Product)
            .Include(od => od.ProductUserWant.Product)
                    .ToListAsync();


        }
        
        public async Task<List<OrderDetail>> getAllMyOrderByDesAndNote(int cusID,string name)
        {
            return await _dbSet
              .Where(od => (od.ProductUserHave.Product.CustomerId == cusID || od.ProductUserWant.Product.CustomerId == cusID)
                  && od.OrderId != null&&(od.Order.Description.ToLower().Contains(name.ToLower()) || od.Order.Note.ToLower().Contains(name.ToLower())))
             .Include(od => od.Order.OrderType)
                 .Include(od => od.ProductUserHave.Product)
             .Include(od => od.ProductUserWant.Product)
                     .ToListAsync();

        }
    }
}
