using Exchange.Business.Base;
using Exchange.Common;
using Exchange.Data;
using Exchange.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Business
{
    public class UserWantBusiness : IUserWantBusiness
    {
        private UnitOfWork _unitOfWork;
        public UserWantBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<IBusinessResult> addNewUSerWant(UserWant userWant)
        {
            try
            {
                // Gọi phương thức CreateAsync từ ProductsRepository để thêm sản phẩm vào cơ sở dữ liệu
                int result = await _unitOfWork.userWantRepository.CreateAsync(userWant);

                // Kiểm tra kết quả trả về từ phương thức CreateAsync
                if (result > 0)
                {
                    // Nếu thành công, trả về kết quả thành công
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, userWant);
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

        public async Task<IBusinessResult> getinforUserWant(int userWantID)
        {
            try
            {


                var products = await _unitOfWork.userWantRepository.getAProductByUserWantID(userWantID);

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

        public async Task<IBusinessResult> findMyWantProductById(int userWantID)
        {

            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.userWantRepository.GetByIdAsync(userWantID);

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
        public async Task<IBusinessResult> getinforUserWantList(int userWantID)
        {
            try
            {


                var products = await _unitOfWork.userWantRepository.getProductListByUserWantID(userWantID);

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

        public async Task<IBusinessResult> getinforUserWantListByDes(int userWantID,string des )
        {
            try
            {


                var products = await _unitOfWork.userWantRepository.getProductListByUserWantIDByDesAndNote(userWantID,des);

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


        public async Task<IBusinessResult> UpdateUserWant(UserWant userWant)
        {
            try
            {
                // Assuming the UpdateAsync method returns the number of affected rows
                var updateResult = await _unitOfWork.userWantRepository.UpdateAsync(userWant);

                if (updateResult > 0) // Check if any rows were affected
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, userWant);
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
        public async Task<IBusinessResult> removeMyWantProduct(UserWant userWant)
        {
            try
            {
                // Assuming the UpdateAsync method returns the number of affected rows
                var updateResult = await _unitOfWork.userWantRepository.RemoveAsync(userWant);

                if (updateResult == true) // Check if any rows were affected
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, userWant);
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
        public async Task<IBusinessResult> SearchByName(string name, int cus)
        {
            try
            {
                #region Business rule
                #endregion

                var productName = await _unitOfWork.userWantRepository.SearchByNameAsync(name, cus);

                if (productName == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, productName);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> getAllUserWantListByProductID(int productID)
        {

            try
            {


                var products = await _unitOfWork.userWantRepository.getAllListByProductID(productID);

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
    }
}
