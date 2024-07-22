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
    public class UserHaveBusiness : IUserHaveBusiness
    {
        private UnitOfWork _unitOfWork;
        public UserHaveBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }




        public async Task<IBusinessResult> findMyHaveProductById(int userHaveID)
        {

            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.userHaveRepository.GetByIdAsync(userHaveID);

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

        public async Task<IBusinessResult> GetAllProductHomePage(int customerID)
        {
            try
            {
                #region Business rule
                #endregion

                var productUserHave = await _unitOfWork.userHaveRepository.GetAllUserHaveProductsAsync(customerID);

                if (productUserHave == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, productUserHave);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> getinforUserHave(int userHaveID)
        {
            try
            {


                var products = await _unitOfWork.userHaveRepository.getAProductByUserHaveID(userHaveID);

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

        public async Task<IBusinessResult> getMyHaveProduct(int customerID)
        {
            try
            {


                var products = await _unitOfWork.userHaveRepository.getAProductByUserID(customerID);

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

        public async Task<IBusinessResult> getMyHaveProductList(int customerID)
        {
            try
            {


                var products = await _unitOfWork.userHaveRepository.getListUserHavetByUserID(customerID);

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

        public async Task<IBusinessResult> removeMyHaveProduct(UserHave userHave)
        {
            try
            {
                // Assuming the UpdateAsync method returns the number of affected rows
                var updateResult = await _unitOfWork.userHaveRepository.RemoveAsync(userHave);

                if (updateResult == true) // Check if any rows were affected
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, userHave);
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

        public async Task<IBusinessResult> saveMyHaveProduct(UserHave userHave)
        {
            try
            {
                // Assuming the UpdateAsync method returns the number of affected rows
                var updateResult = await _unitOfWork.userHaveRepository.CreateAsync(userHave);

                if (updateResult > 0) // Check if any rows were affected
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, userHave);
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

                var productName = await _unitOfWork.userHaveRepository.SearchByNameAsync(name, cus);

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



        public async Task<IBusinessResult> SearchByNameMyUserHaveList(string name, int cus)
        {
            try
            {
                #region Business rule
                #endregion

                var productName = await _unitOfWork.userHaveRepository.SearchMyListByNameAsync(name, cus);

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

        public async Task<IBusinessResult> SearchByDesAndNoteMyUserHaveList(string name, int cus)
        {
            try
            {
                #region Business rule
                #endregion

                var productName = await _unitOfWork.userHaveRepository.SearchMyListByDesAndNote(name, cus);

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
        public async Task<IBusinessResult> UpdateMyHaveProduct(UserHave userHave)
        {
            try
            {
                // Assuming the UpdateAsync method returns the number of affected rows
                var updateResult = await _unitOfWork.userHaveRepository.UpdateAsync(userHave);

                if (updateResult > 0) // Check if any rows were affected
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, userHave);
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

        public async Task<IBusinessResult> findallHaveProductByProductId(int productID)
        {
            try
            {
                var productUserHave = await _unitOfWork.userHaveRepository.GetAllUserHaveProductsAsyncbyProductID(productID);

                if (productUserHave == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, productUserHave);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}
