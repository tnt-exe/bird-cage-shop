using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ICageComponentRepository CageComponentRepo { get; }
        public ICageImageRepository CageImageRepo { get; }
        public ICageRepository CageRepo { get; }
        public ICategoryRepository CategoryRepo { get; }
        public IComponentRepository ComponentRepo { get; }
        public IOrderDetailRepository OrderDetailRepo { get; }
        public IOrderRepository OrderRepo { get; }
        public IUserRepository UserRepo { get; }
    }
}
