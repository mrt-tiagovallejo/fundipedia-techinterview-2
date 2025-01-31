using Fundipedia.TechInterview.Models;

namespace Fundipedia.TechInterview.Domain.Interfaces;

public interface IOrderStatusEvaluator
{
    OrderStatus Evaluate(OrderRequest request);
}
