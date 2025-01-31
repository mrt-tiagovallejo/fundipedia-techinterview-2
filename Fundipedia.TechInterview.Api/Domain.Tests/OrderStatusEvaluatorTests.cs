using Fundipedia.TechInterview.Domain.Classes;
using Fundipedia.TechInterview.Domain.Interfaces;
using Fundipedia.TechInterview.Models;

namespace Fundipedia.TechInterview.Domain.Tests;

public class OrderStatusEvaluatorTests
{
    private IOrderStatusEvaluator _evaluator;

    [SetUp]
    public void Setup()
    {
        _evaluator = new OrderStatusEvaluator();
    }

    [TestCase(true, OrderType.Repair, true, true, OrderStatus.Closed)]
    [TestCase(true, OrderType.Hire, false, true, OrderStatus.Closed)]
    [TestCase(false, OrderType.Repair, false, true, OrderStatus.AuthorisationRequired)]
    [TestCase(true, OrderType.Hire, true, false, OrderStatus.AuthorisationRequired)]
    [TestCase(false, OrderType.Hire, false, false, OrderStatus.Confirmed)]
    public void Evaluate_Returns_CorrectStatus(bool IsRushOrder, OrderType OrderType, bool IsNewCustomer, bool IsLargeOrder, OrderStatus expectedStatus)
    {
        var request = new OrderRequest(IsRushOrder, OrderType, IsNewCustomer, IsLargeOrder);
        var result = _evaluator.Evaluate(request);
        Assert.That(result, Is.EqualTo(expectedStatus));
    }
}