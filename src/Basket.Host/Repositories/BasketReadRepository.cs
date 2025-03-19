using Basket.Host.Domain.Basket;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using Basket.Host.Domain.Basket.Entities;

namespace Basket.Host.Repositories
{
    public class BasketReadRepository : IBasketReadRepository
    {
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

        public Task<UserBasketItem> GetUserBasketItem(int basketid, string Slug)
        {
            throw new NotImplementedException();
        }

        public Task<UserBasketItem> GetUserBasketItem(int BasketItemId)
        {
            throw new NotImplementedException();
        }

        public Task<UserBasketItem> GetUserBasketItem(string Slug)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserBasketItem>> GetUserBasketItems(string Slug)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserBasket>> GetUserBaskets(IEnumerable<int> UserBasketIds)
        {
            throw new NotImplementedException();
        }
    }
}
