using System.Data;

namespace Basket.Host.Repositories
{
    public class DapperContext
    {
        public IDbConnection? Connection { get; private set; }
        public IDbTransaction? Transaction { get; private set; }

        public void Init(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }

        public void Clear()
        {
            Transaction = null;
            Connection = null;
        }
    }
}
