// public class DiscountService : IDiscountService
// {
//     // Example of a simple bulk discount policy
//     public decimal CalculateDiscount(Basket basket)
//     {
//         decimal discount = 0;
//         // Define your discount logic here
//         // Example: 10% discount for orders over 10 items
//         if (basket.Items.Sum(i => i.Quantity) > 10)
//         {
//             discount = basket.TotalPrice * 0.10m; // 10% discount
//         }
//         return discount;
//     }
// }

// public interface IDiscountService
// {
//     decimal CalculateDiscount(Basket basket);
// }