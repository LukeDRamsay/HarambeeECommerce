using LukeRamsayWebAPI.Models;
using LukeRamsayWebAPI.services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LukeRamsayWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        // GET: api/basket/customer/{customerId}
        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<Basket>> GetBasketByCustomerId(int customerId)
        {
            try
            {
                var basket = await _basketService.GetBasketByCustomerIdAsync(customerId);
                return Ok(basket);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/basket/addItem
        [HttpPost("addItem")]
        public async Task<IActionResult> AddItemToBasket(int basketId, BasketItem item)
        {
            try
            {
                await _basketService.AddItemToBasketAsync(basketId, item);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/basket/update
        [HttpPut("update")]
        public async Task<IActionResult> UpdateBasket(Basket basket)
        {
            try
            {
                await _basketService.UpdateBasketAsync(basket);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/basket/totalPrice/{basketId}
        [HttpGet("totalPrice/{basketId}")]
        public async Task<ActionResult<decimal>> CalculateTotalPrice(int basketId)
        {
            try
            {
                var totalPrice = await _basketService.CalculateTotalPriceAsync(basketId);
                return Ok(totalPrice);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
