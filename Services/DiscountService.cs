// using LukeRamsayWebAPI.Models;

// namespace LukeRamsayWebAPI.services
// {
//     public interface IDiscountService
//     {
//         decimal CalculateDiscount(Basket basket);
//     }

//     public class DiscountService : IDiscountService
//     {
//         public decimal CalculateDiscount(Basket basket)
//     {
//         decimal discount = 0;
//         foreach (var item in basket.Items)
//         {
//             if (item.Quantity > 10)
//             {
//                 // Directly use item.Product.Price, as it's non-nullable now
//                 discount += item.Quantity * item.Product.Price * 0.10m; // 10% discount
//             }
//         }

//         return discount;
//     }
//     }
// }
