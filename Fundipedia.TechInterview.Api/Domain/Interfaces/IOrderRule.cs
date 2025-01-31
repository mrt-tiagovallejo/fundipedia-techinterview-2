using Fundipedia.TechInterview.Models;

namespace Fundipedia.TechInterview.Domain.Interfaces;

public interface IOrderRule
{
    bool IsMatch(OrderRequest request);
    OrderStatus GetStatus();
}
