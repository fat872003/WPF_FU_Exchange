using Exchange.Business.Base;
using Exchange.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Business
{
    public interface IProductBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> getAllMyProduct(int txtCustomerID);
        Task<IBusinessResult> CreateProduct(Product product);
        Task<IBusinessResult> FindProductsListByName(String txtProductName, int txtCustomerID);

        Task<IBusinessResult> FindAvaliableProductList(int txtCustomerID);

        Task<IBusinessResult> FindAvaliableProductListByname(String txtProductName, int txtCustomerID);
     
        Task<IBusinessResult> findProductById(int id);

        Task<IBusinessResult> UpdateAproduct(Product product);
        Task<IBusinessResult> RemoveAproduct(Product product);
    }
}
