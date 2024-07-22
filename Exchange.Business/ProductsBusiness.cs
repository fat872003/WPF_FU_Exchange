using Exchange.Business.Base;
using Exchange.Common;
using Exchange.Data.Models;
using Exchange.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Business
{
    public class ProductsBusiness : IProductBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public ProductsBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> CreateProduct(Product product)
        {
            try
            {
                // Gọi phương thức CreateAsync từ ProductsRepository để thêm sản phẩm vào cơ sở dữ liệu
                int result = await _unitOfWork.ProductsRepository.CreateAsync(product);

                // Kiểm tra kết quả trả về từ phương thức CreateAsync
                if (result > 0)
                {
                    // Nếu thành công, trả về kết quả thành công
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, product);
                }
                else
                {
                    // Nếu không thành công, trả về kết quả thất bại
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và trả về kết quả thất bại với thông điệp lỗi
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> FindAvaliableProductList(int txtCustomerID)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.ProductsRepository.getAllAvailableMyProduct(txtCustomerID);

                if (products == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, products);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> FindAvaliableProductListByname(string txtProductName, int txtCustomerID)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.ProductsRepository.getProductByTrueStatusAndName(txtProductName, txtCustomerID);

                if (products == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, products);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> findProductById(int id)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.ProductsRepository.GetByIdAsync(id);

                if (products == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, products);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> FindProductsListByName(string txtProductName, int txtCustomerID)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.ProductsRepository.getProductByName(txtProductName, txtCustomerID);

                if (products == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, products);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.ProductsRepository.GetAllAsync();

                if (products == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, products);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> getAllMyProduct(int txtCustomerID)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.ProductsRepository.getMyAllProduct(txtCustomerID);

                if (products == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, products);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> RemoveAproduct(Product product)
        {
            try
            {
                // Assuming the UpdateAsync method returns the number of affected rows
                var updateResult = await _unitOfWork.ProductsRepository.RemoveAsync(product);

                if (updateResult == true) // Check if any rows were affected
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, product);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error result
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }



        public async Task<IBusinessResult> UpdateAproduct(Product product)
        {
            try
            {
                // Assuming the UpdateAsync method returns the number of affected rows
                var updateResult = await _unitOfWork.ProductsRepository.UpdateAsync(product);

                if (updateResult > 0) // Check if any rows were affected
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, product);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error result
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }



    }
}
