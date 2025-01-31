using Fundipedia.TechInterview.Domain.Interfaces;
using Fundipedia.TechInterview.Models;

namespace Fundipedia.TechInterview.Domain.Classes.Rules;

public class DefaultRule : IOrderRule
{
    public OrderStatus GetStatus() => OrderStatus.Confirmed;

    public bool IsMatch(OrderRequest request)
        => true;
}
