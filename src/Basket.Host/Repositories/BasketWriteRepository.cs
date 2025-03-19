using Basket.Host.Domain.Basket;
using Dapper;
using System.Data;
using Basket.Host.Domain.Basket.DomainModels;
using System.Data.SqlClient;

namespace Basket.Host.Repositories
{
    public class BasketWriteRepository : IBasketWriteRepository
    {
        public Task<int> AddBasket(UserBasket basket)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBasket(UserBasket basket)
        {
            throw new NotImplementedException();
        }

        public Task AddUserBasketItem(UserBasketItem userBasketItem)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBasketItem(UserBasketItem basket)
        {
            throw new NotImplementedException();
        }
    }
}
