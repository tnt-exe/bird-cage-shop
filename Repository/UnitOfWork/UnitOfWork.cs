using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly IUserRepository _userRepo;
        private readonly ICageRepository _cageRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IComponentRepository _componentRepo;
        private readonly ICageImageRepository _cageImageRepo;
        private readonly IOrderDetailRepository _orderDetailRepo;
        private readonly ICageComponentRepository _cageComponentRepo;

        public UnitOfWork(
            IUserRepository userRepo, 
            ICageRepository cageRepo, 
            IOrderRepository orderRepo, 
            ICategoryRepository categoryRepo, 
            IComponentRepository componentRepo, 
            ICageImageRepository cageImageRepo, 
            IOrderDetailRepository orderDetailRepo, 
            ICageComponentRepository cageComponentRepo
            )
        {
            _userRepo = userRepo;
            _cageRepo = cageRepo;
            _orderRepo = orderRepo;
            _categoryRepo = categoryRepo;
            _componentRepo = componentRepo;
            _cageImageRepo = cageImageRepo;
            _orderDetailRepo = orderDetailRepo;
            _cageComponentRepo = cageComponentRepo;
        }

        public ICageComponentRepository CageComponentRepo => _cageComponentRepo;

        public ICageImageRepository CageImageRepo => _cageImageRepo;

        public ICageRepository CageRepo => _cageRepo;

        public ICategoryRepository CategoryRepo => _categoryRepo;

        public IComponentRepository ComponentRepo => _componentRepo;

        public IOrderDetailRepository OrderDetailRepo => _orderDetailRepo;

        public IOrderRepository OrderRepo => _orderRepo;

        public IUserRepository UserRepo => _userRepo;
    }
}
