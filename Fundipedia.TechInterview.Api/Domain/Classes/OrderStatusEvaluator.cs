using Fundipedia.TechInterview.Domain.Classes.Rules;
using Fundipedia.TechInterview.Domain.Interfaces;
using Fundipedia.TechInterview.Models;

namespace Fundipedia.TechInterview.Domain.Classes;

public class OrderStatusEvaluator : IOrderStatusEvaluator
{
    private readonly List<IOrderRule> _orderRules;

    public OrderStatusEvaluator()
    {
        _orderRules = new List<IOrderRule>
        {
            new LargeRepairForNewCustomer()
            // TODO: add remaining rules
        };
    }

    public OrderStatus Evaluate(OrderRequest request)
    {
        // iterate through the different order rules and retrieve status of first match
        var rule = _orderRules.First(r => r.IsMatch(request));
        return rule.GetStatus();
    }
}
