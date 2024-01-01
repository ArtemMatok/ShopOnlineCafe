using ShopOnlineCafe.Server.Data;
using ShopOnlineCafe.Shared;
using Stripe;
using Stripe.Checkout;

namespace ShopOnlineCafe.Server.Repository.PaymentRepository
{
    public class PaymentRepository : IPaymentRepository
    {
      

        public PaymentRepository()
        {
            StripeConfiguration.ApiKey = "sk_test_51NptwQIBIeskGBr1OPizfA4iSPVobyxtclrHNsZO6L1k7ZUBQvcZYzPslzMUlXUVzNU2f4vQ3y3XCJkN0d9A5jsb007K33QPmv";
        }

        public Session CreateCheckoutSession(List<OrderProduct> orders)
        {
            var lineItems = new List<SessionLineItemOptions>();
            orders.ForEach(x=> lineItems.Add(new SessionLineItemOptions()
            {
                PriceData = new SessionLineItemPriceDataOptions{
                    UnitAmountDecimal = (x.Food.Price)*100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = x.Food.Name,
                       
                    }
                },
                Quantity = x.Quantity,
            }));

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "http://localhost:5171/order-success",
                CancelUrl = "http://localhost:5171"
            };
            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }
    }
}
