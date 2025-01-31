using Fundipedia.TechInterview.Domain.Interfaces;
using Fundipedia.TechInterview.Models;

namespace Fundipedia.TechInterview.Domain.Classes.Rules;

public class RushOrderForNewCustomerRule : IOrderRule
{
    public OrderStatus GetStatus() => OrderStatus.AuthorisationRequired;

    public bool IsMatch(OrderRequest request)
        => request.IsRushOrder 
        && request.IsNewCustomer;
}
