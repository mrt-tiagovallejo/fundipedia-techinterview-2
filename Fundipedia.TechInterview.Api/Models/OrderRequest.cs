namespace Fundipedia.TechInterview.Models;

public record OrderRequest(bool IsRushOrder, OrderType OrderType, bool IsNewCustomer, bool IsLargeOrder);
