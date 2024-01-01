using ShopOnlineCafe.Shared;
using Stripe.Checkout;

namespace ShopOnlineCafe.Server.Repository.PaymentRepository
{
    public interface IPaymentRepository
    {
        Session CreateCheckoutSession(List<OrderProduct> orders);
    }
}
