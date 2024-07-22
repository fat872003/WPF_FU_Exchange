using Exchange.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Data
{
    public class UnitOfWork
    {

        private ProductsRepository _productsRepository;
        private CustomerRepository _customerRepository;
        private OrderRepository _oderRepository;
        private UserHaveRepository _userHaveRepository;
        private OderDetailRepository _oderDetailRepository;
        private UserWantRepository _userWantRepository;
        private OrderTypeRepository _orderTypeRepository; 
        public UnitOfWork()
        {
        }


        public OrderTypeRepository orderTypeRepository
        {
            get => _orderTypeRepository ??= new Repository.OrderTypeRepository();
            init
            {
                _productsRepository = value;
            }
        }

        public ProductsRepository ProductsRepository
        {
            get => _productsRepository ??= new Repository.ProductsRepository();
            init
            {
                _productsRepository = value;
            }
        }

        public CustomerRepository customerRepository
        {
            get => _customerRepository ??= new Repository.CustomerRepository();
            init
            {
                _customerRepository = value;
            }
        }
        public OrderRepository oderRepository
        {
            get => _oderRepository ??= new Repository.OrderRepository();
            init
            {
                _oderRepository = value;

            }
        }

        public UserHaveRepository userHaveRepository
        {
            get => _userHaveRepository ??= new Repository.UserHaveRepository();
            init
            {
                _userHaveRepository = value;

            }
        }


        public UserWantRepository userWantRepository
        {
            get => _userWantRepository ??= new Repository.UserWantRepository();
            init
            {
                _userWantRepository = value;

            }
        }

        public OderDetailRepository oderDetailRepository
        {
            get => _oderDetailRepository ??= new Repository.OderDetailRepository();
            init
            {
                _oderDetailRepository = value;

            }
        }


    }
}
