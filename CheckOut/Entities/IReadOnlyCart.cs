namespace CheckOut.Entities
{
    public interface IReadOnlyCart
    {
        decimal Cost { get; }
        decimal Discount { get; }
        int ProductId { get; }
        string ProductName { get; }
        int Quantity { get; }
        decimal RegularPrice { get; }
        decimal Total { get; }
    }
}