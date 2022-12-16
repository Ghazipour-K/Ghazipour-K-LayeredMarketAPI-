using System.Web.Http;
using Unity;
using Unity.WebApi;
using Market.Repository;
using Market.Service;

namespace Market
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            UnityContainer container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IGenericRepository<ProductTable>, GenericRepository<ProductTable>>();
            container.RegisterType<IGenericRepository<DistributionScheduleTable>, GenericRepository<DistributionScheduleTable>>();
            container.RegisterType<IGenericRepository<ShoppingCardTable>, GenericRepository<ShoppingCardTable>>();

            container.RegisterType<IAdmin, Admin>();
            container.RegisterType<ICustomer, Customer>();
            container.RegisterType<IProduct, Product>();
            container.RegisterType<IShoppingCard, ShoppingCard>();
            container.RegisterType<IDistributionSchedule, DistributionSchedule>();

            //container.RegisterType<IAuthorizationServerProvider, AuthorizationServerProvider>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}