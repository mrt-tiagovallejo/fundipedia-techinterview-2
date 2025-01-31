using Fundipedia.TechInterview.Domain.Interfaces;
using Fundipedia.TechInterview.Models;

namespace Fundipedia.TechInterview.Domain.Classes.Rules;

public class LargeRepairOrderRule : IOrderRule
{
    public OrderStatus GetStatus() => OrderStatus.AuthorisationRequired;

    public bool IsMatch(OrderRequest request)
        => request.IsLargeOrder 
        && request.OrderType == OrderType.Repair;
}
