using Basket.Host.Domain.Basket;
using Dapper;
using System.Data;
using Basket.Host.Domain.Basket.DomainModels;
using System.Data.SqlClient;

namespace Basket.Host.Persistence.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        public BasketRepository()
        {
            
        }

        public async Task<UserBasket> GetUserBasket(int UserId)
        {
            string query = $@"select Id ,
                                     UserId ,
                                     Amount ,
                                     TotalAmount ,
                                     DeliveryPrice ,
                                     VatAmount 
                              From 
                              Basket 
                                    WHERE UserId = @UserId";

            var parameters = new DynamicParameters();
            parameters.Add("UserId", UserId, DbType.Int32, null);

            using (var connection = new SqlConnection(""))
            {
                var result =
                    await connection.QueryFirstOrDefaultAsync<UserBasket>(query, parameters)
                    .ConfigureAwait(false);

                return result;
            }
        }

        public async Task<int> AddBasket(UserBasket basket)
        {
            throw new NotImplementedException();
        }

        public Task AddUserBasketProductItem(UserBasketProductItem userBasketProductItem)
        {
            throw new NotImplementedException();
        }

        public Task<UserBasketProductItem> GetUserBasketProductItem(int BasketId, string Slug)
        {
            throw new NotImplementedException();
        }

        public Task<UserBasketProductItem> GetUserBasketProductItem(string Slug)
        {
            throw new NotImplementedException();
        }

        public Task<UserBasketProductItem> UpadteUserBasketProductItem(string Slug, decimal Price, decimal LatestPrice, bool UserChangedSeen)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBasket(UserBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}
