using Basket.Host.Repositories;
using MediatR;

namespace Basket.Host.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly DapperContext _dapperContext;
        private readonly IDbConnectionFactory _connectionFactory;

        public TransactionBehavior(DapperContext dapperContext, IDbConnectionFactory connectionFactory)
        {
            _dapperContext = dapperContext;
            _connectionFactory = connectionFactory;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var connection = _connectionFactory.CreateConnection();
            connection.Open();
            var transaction = connection.BeginTransaction();

            _dapperContext.Init(connection, transaction);

            try
            {
                var response = await next();

                transaction.Commit();
                return response;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                _dapperContext.Clear();
                transaction.Dispose();
                connection.Dispose();
            }
        }
    }

}
