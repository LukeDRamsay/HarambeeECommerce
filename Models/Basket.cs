namespace LukeRamsayWebAPI.Models
{
    public class Basket
    {
    public int? BasketId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public List<BasketItem>? Items { get; set; }
        public decimal? TotalPrice
        {
            get
            {
                return Items?.Sum(item => item.Quantity * item.Product.Price) ?? 0;
            }
        }
        public string? DiscountCode { get; set; }

        public string? Status { get; set; }
        public bool? IsCheckedOut { get; set; }



        public Customer? Customer { get; set; }
    }

    public class BasketItem
    {
        public int? BasketItemId { get; set; }
        public int? BasketId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? AddedDate { get; set; }

        public Basket? Basket { get; set; }
        public Product? Product { get; set; }
    }
}