using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnlineCafe.Server.Repository.PaymentRepository;
using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpPost("Checkout")]
        public ActionResult CreateCheckouteSession(List<OrderProduct>orders)
        {
            var session = _paymentRepository.CreateCheckoutSession(orders);
            return Ok(session.Url);
        }
    }
}
