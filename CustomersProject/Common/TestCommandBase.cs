using ProjectSystem.Persistence;


namespace CustomersProjectTest.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly CustomersDbContext Context;

        public TestCommandBase()
        {
            Context = CustomersFactory.CreateDbContext();
        }

        public void Dispose()
        {
            CustomersFactory.Destroy(Context);
        }
    }
}
