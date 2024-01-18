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
//         {
//             decimal discount = 0m;
//             foreach (var item in basket.Items)
//             {
//                 // Check if the item and price are not null and quantity is greater than 10
//                 if (item.Product != null && item.Product.Price != null && item.Quantity > 10)
//                 {
//                     decimal price = item.Product.Price.Value;
//                     decimal quantityDiscount = item.Quantity * price * 0.10m; // 10% discount for the quantity
//                     discount += quantityDiscount;
//                 }
//             }

//             return discount;
//         }
//     }
// }
