using LukeRamsayWebAPI.Models;
using LukeRamsayWebAPI.Data;
using Microsoft.EntityFrameworkCore;
namespace LukeRamsayWebAPI.services
{
    public interface IBasketService
    {
        Task<Basket> GetBasketByCustomerIdAsync(int customerId);
        Task<Basket> UpdateBasketAsync(Basket basket);
        Task AddItemToBasketAsync(int basketId, BasketItem item);
        Task<decimal> CalculateTotalPriceAsync(int basketId);
    }

    public class BasketService : IBasketService
    {
        private readonly ECommerceContext _context;
        // private readonly IDiscountService _discountService;

        // public BasketService(ECommerceContext context, IDiscountService discountService)
        public BasketService(ECommerceContext context)
        {
            _context = context;
            // _discountService = discountService;
        }

        public async Task<Basket> GetBasketByCustomerIdAsync(int customerId)
        {
            var basket = await _context.Baskets
                .Include(b => b.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(b => b.CustomerId == customerId);

            if (basket == null)
            {
                basket = new Basket
                {
                    CustomerId = customerId,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Status = "Active",
                    IsCheckedOut = false
                };

                _context.Baskets.Add(basket);
                await _context.SaveChangesAsync();
            }

            return basket;
        }

        public async Task<Basket> UpdateBasketAsync(Basket basket)
        {
            basket.LastUpdatedDate = DateTime.Now;
            _context.Baskets.Update(basket);
            await _context.SaveChangesAsync();
            return basket;
        }

        public async Task AddItemToBasketAsync(int basketId, BasketItem item)
        {
            var basket = await _context.Baskets
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.BasketId == basketId);

            if (basket == null)
            {
                throw new Exception("Basket not found");
            }

            var existingItem = basket.Items.FirstOrDefault(i => i.ProductId == item.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                basket.Items.Add(item);
            }

            await UpdateBasketAsync(basket);
        }

        public async Task<decimal> CalculateTotalPriceAsync(int basketId)
    {
        var basket = await _context.Baskets
            .Include(b => b.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(b => b.BasketId == basketId);

        if (basket == null)
        {
            throw new Exception("Basket not found");
        }
                    return basket.Items?.Sum(i => i.Quantity * i.Product?.Price ?? 0) ?? 0;
        

        // var totalPrice = basket.Items?.Sum(i => i.Quantity * i.Product?.Price ?? 0) ?? 0;
        // var discount = _discountService.CalculateDiscount(basket);
        // return totalPrice - discount;
        
    }
    }

}