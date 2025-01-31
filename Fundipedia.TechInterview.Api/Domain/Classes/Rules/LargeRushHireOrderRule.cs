using Fundipedia.TechInterview.Domain.Interfaces;
using Fundipedia.TechInterview.Models;

namespace Fundipedia.TechInterview.Domain.Classes.Rules;

public class LargeRushHireOrderRule : IOrderRule
{
    public OrderStatus GetStatus() => OrderStatus.Closed;

    public bool IsMatch(OrderRequest request)
        => request.IsLargeOrder 
        && request.OrderType == OrderType.Hire 
        && request.IsRushOrder;
}
