using Fundipedia.TechInterview.Domain.Classes.Rules;
using Fundipedia.TechInterview.Models;

namespace Fundipedia.TechInterview.Domain.Tests;

public class OrderRuleTests
{
    [Test]
    public void LargeRepairForNewCustomerRule_Returns_ClosedStatus()
    {
        var rule = new LargeRepairOrderForNewCustomerRule();
        Assert.That(rule.GetStatus(), Is.EqualTo(OrderStatus.Closed));
    }

    [Test]
    public void LargeRepairForNewCustomerRule_Returns_IsMatch_WhenValidMatch()
    {
        var rule = new LargeRepairOrderForNewCustomerRule();
        var validRequest = new OrderRequest(true, OrderType.Repair, true, true);
        Assert.IsTrue(rule.IsMatch(validRequest));

        var invalidRequest = new OrderRequest(true, OrderType.Repair, false, false);
        Assert.IsFalse(rule.IsMatch(invalidRequest));
    }

    [Test]
    public void LargeRushHireOrderRule_Returns_ClosedStatus()
    {
        var rule = new LargeRushHireOrderRule();
        Assert.That(rule.GetStatus(), Is.EqualTo(OrderStatus.Closed));
    }

    [Test]
    public void LargeRushHireOrderRule_Returns_IsMatch_WhenValidMatch()
    {
        var rule = new LargeRushHireOrderRule();
        var validRequest = new OrderRequest(true, OrderType.Hire, false, true);
        Assert.IsTrue(rule.IsMatch(validRequest));

        var invalidRequest = new OrderRequest(false, OrderType.Hire, false, false);
        Assert.IsFalse(rule.IsMatch(invalidRequest));
    }

    [Test]
    public void LargeRepairOrderRule_Returns_AuthorisationRequiredStatus()
    {
        var rule = new LargeRepairOrderRule();
        Assert.That(rule.GetStatus(), Is.EqualTo(OrderStatus.AuthorisationRequired));
    }

    [Test]
    public void LargeRepairOrderRule_Returns_IsMatch_WhenValidMatch()
    {
        var rule = new LargeRepairOrderRule();
        var validRequest = new OrderRequest(false, OrderType.Repair, false, true);
        Assert.IsTrue(rule.IsMatch(validRequest));

        var invalidRequest = new OrderRequest(false, OrderType.Repair, false, false);
        Assert.IsFalse(rule.IsMatch(invalidRequest));
    }

    [Test]
    public void RushOrderForNewCustomerRule_Returns_AuthorisationRequiredStatus()
    {
        var rule = new RushOrderForNewCustomerRule();
        Assert.That(rule.GetStatus(), Is.EqualTo(OrderStatus.AuthorisationRequired));
    }

    [Test]
    public void RushOrderForNewCustomerRule_Returns_IsMatch_WhenValidMatch()
    {
        var rule = new RushOrderForNewCustomerRule();
        var validRequest = new OrderRequest(true, OrderType.Hire, true, false);
        Assert.IsTrue(rule.IsMatch(validRequest));

        var invalidRequest = new OrderRequest(false, OrderType.Hire, true, false);
        Assert.IsFalse(rule.IsMatch(invalidRequest));
    }

    [Test]
    public void DefaultOrderRule_Returns_ConfirmedStatus()
    {
        var rule = new DefaultRule();
        Assert.That(rule.GetStatus(), Is.EqualTo(OrderStatus.Confirmed));
    }

    [Test]
    public void DefaultOrderRule_Returns_IsMatch()
    {
        var rule = new DefaultRule();
        var request = new OrderRequest(false, OrderType.Hire, false, false);
        Assert.IsTrue(rule.IsMatch(request));
    }
}