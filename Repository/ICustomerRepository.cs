namespace Market.Repository
{
    public interface ICustomerRepository: IGenericRepository<CustomerTable>
    {
        bool Login(string UserID, string Password);
    }
}
