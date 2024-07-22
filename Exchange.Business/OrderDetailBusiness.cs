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
    public class OrderDetailBusiness : IOrderDetailBusiness
    {

        private UnitOfWork _unitOfWork;

        public OrderDetailBusiness()
        {

            _unitOfWork = new UnitOfWork();
        }

        public async Task<IBusinessResult> getAllMyOrderDetail(int cusID)
        {
            try
            {
                #region Business rule
                #endregion

                var productName = await _unitOfWork.oderDetailRepository.getAllMyOrderDetail(cusID);

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
        public async Task<IBusinessResult> findOrderInformationById(int orderDetailID)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.oderDetailRepository.GetByIdAsync(orderDetailID);

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

        public async Task<IBusinessResult> getInforOrderUserHaveProduct(int Oderid)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.oderDetailRepository.getOrderDetailUserHaveByID(Oderid);

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

        public async Task<IBusinessResult> getInforOrderUserWantProduct(int Oderid)
        {
            try
            {
                #region Business rule
                #endregion

                var products = await _unitOfWork.oderDetailRepository.getOrderDetailUserWantByID(Oderid);

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

        public async Task<IBusinessResult> removeOrderInformation(OrderDetail orderDetail)
        {
            try
            {
                // Assuming the UpdateAsync method returns the number of affected rows
                var updateResult = await _unitOfWork.oderDetailRepository.RemoveAsync(orderDetail);

                if (updateResult == true) // Check if any rows were affected
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, orderDetail);
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

        public async Task<IBusinessResult> saveOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                // Gọi phương thức CreateAsync từ ProductsRepository để thêm sản phẩm vào cơ sở dữ liệu
                int result = await _unitOfWork.oderDetailRepository.CreateAsync(orderDetail);

                // Kiểm tra kết quả trả về từ phương thức CreateAsync
                if (result > 0)
                {
                    // Nếu thành công, trả về kết quả thành công
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, orderDetail);
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

        public async Task<IBusinessResult> getAllMyWishList(int cusID)
        {
            try
            {
                #region Business rule
                #endregion

                var productName = await _unitOfWork.oderDetailRepository.getAllMyWishList(cusID);

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

        public async Task<IBusinessResult> updateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                // Assuming the UpdateAsync method returns the number of affected rows
                var updateResult = await _unitOfWork.oderDetailRepository.UpdateAsync(orderDetail);

                if (updateResult > 0) // Check if any rows were affected
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, orderDetail);
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

        public async Task<IBusinessResult> getAllMyOrder(int cusID)
        {
            try
            {
                #region Business rule
                #endregion

                var orderDetails= await _unitOfWork.oderDetailRepository.getAllMyOrder(cusID);

                if (orderDetails == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, orderDetails);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<IBusinessResult> getAllMyOrderByDesAndNote(int cusID,string name)
        {
            try
            {
                #region Business rule
                #endregion

                var orderDetails = await _unitOfWork.oderDetailRepository.getAllMyOrderByDesAndNote(cusID,name);

                if (orderDetails == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, orderDetails);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<IBusinessResult> getAllMyOrderDetailByMessOrAdress(int cusID,string name)
        {
            try
            {
                #region Business rule
                #endregion

                var orderDetails = await _unitOfWork.oderDetailRepository.getAllMyOrderDetailByMessOrAddress(cusID,name);

                if (orderDetails == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, orderDetails);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> getAllMyWishListByMessAndAdress(int cusID, string name)
        {
            try
            {
                #region Business rule
                #endregion

                var productName = await _unitOfWork.oderDetailRepository.getAllMyWishListlByMessOrAddress(cusID,name);

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
    }
}
