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
    public class OrderBusiness : IOderBusiness
    {
       private UnitOfWork _unitOfWork;

        public OrderBusiness() { 
        _unitOfWork = new UnitOfWork(); 
        }


        public async Task<IBusinessResult> SearchByName(string name, int cus)
        {
            try
            {
                #region Business rule
                #endregion

                var productName = await _unitOfWork.oderRepository.getAllMyOwnOderByName(name, cus);

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

        public async Task<IBusinessResult> checkUserOfferProduct(int userHaveid)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.oderRepository.getAOderDetailByUserHaveID(userHaveid);

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

        public async Task<IBusinessResult> checkUserTradedProduct(int userWantid)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.oderRepository.getAOderDetailByUserWantID(userWantid);

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

        public async Task<IBusinessResult> findAOderByIdWithDetail(int id)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.oderRepository.getAOderDetail(id);

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

        public async Task<IBusinessResult> removeAOrderInformation(Order order)
        {
            try
            {
                // Assuming the UpdateAsync method returns the number of affected rows
                var updateResult = await _unitOfWork.oderRepository.RemoveAsync(order);

                if (updateResult == true) // Check if any rows were affected
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, order);
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

        public async Task<IBusinessResult> saveAOrderInformation(Order order)
        {
            try
            {
                // Assuming the UpdateAsync method returns the number of affected rows
                var updateResult = await _unitOfWork.oderRepository.CreateAsync(order);

                if (updateResult > 0) // Check if any rows were affected
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, order);
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

        public async Task<IBusinessResult> showAllMyoder(int id)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.oderRepository.getAllMyOwnOder(id);

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

        public async Task<IBusinessResult> updateAOrderInformation(Order order)
        {
            try
            {
                // Assuming the UpdateAsync method returns the number of affected rows
                var updateResult = await _unitOfWork.oderRepository.UpdateAsync(order);

                if (updateResult > 0) // Check if any rows were affected
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, order);
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

        public async Task<IBusinessResult> UserOfferProductList(int cusID)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.oderRepository.getOderDetailListByUserHaveID(cusID);

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

        public Task<IBusinessResult> UserTradedProductList(int cusID)
        {
            throw new NotImplementedException();
        }
    }
}
