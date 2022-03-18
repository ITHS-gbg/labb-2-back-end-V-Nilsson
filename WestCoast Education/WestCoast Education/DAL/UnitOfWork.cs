namespace WestCoast_Education.DAL
{
    public class UnitOfWork : IDisposable
    {
        private WCEContext _wceContext;


        public void Dispose()
        {
            _wceContext.Dispose();
        }
    }
}
