using System.Collections.Generic;

namespace CheckOut.Entities
{
    public interface IHaveItems
    {
        IReadOnlyList<CartItem> Items { get; }
        IReadOnlyCart GetItemByProductName(string name);
    }
}