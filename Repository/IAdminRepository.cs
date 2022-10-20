namespace Market.Repository
{
    public interface IAdminRepository : IGenericRepository<AdminTable>
    {
        bool Login(string UserID, string Password);
    }
}
