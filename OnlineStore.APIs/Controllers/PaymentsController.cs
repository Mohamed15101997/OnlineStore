using Stripe;
namespace OnlineStore.APIs.Controllers
{
	public class PaymentsController : OnlineStoreController
	{
		private readonly IPaymentService _paymentService;
		private readonly IConfiguration _configuration;

		public PaymentsController(IPaymentService paymentService,IConfiguration configuration)
		{
			_paymentService = paymentService;
			_configuration = configuration;
		}
		[HttpPost("Payment")]
		public async Task<IActionResult> CreatePayment(int orderId) 
		{
			var payment = await _paymentService.CreateOrUpdatePaymentIntentId(User, orderId);

			if (payment is null) 
				return BadRequest(new ApiResponseError(StatusCodes.Status400BadRequest));

			return Ok(payment);
		}
		[HttpPost("stripe-webhook")]
		public async Task<IActionResult> StripeWebhook()
		{
			var json = await new StreamReader(Request.Body).ReadToEndAsync();

			var eventSecret = _configuration["Stripe:EventSecret"];

			var stripeEvent = EventUtility.ConstructEvent(
				json,
				Request.Headers["Stripe-Signature"],
				eventSecret
			);

			var paymentIntent = stripeEvent.Data.Object as PaymentIntent;

			switch (stripeEvent.Type)
			{
				case "payment_intent.succeeded":


					var orderId = paymentIntent.Metadata["orderId"];

					await _paymentService.UpdateOrderStatus( paymentIntent.Id, true);

					break;

				case "payment_intent.payment_failed":


					var failedOrderId = paymentIntent.Metadata["orderId"];

					await _paymentService.UpdateOrderStatus(paymentIntent.Id, false);

					break;
			}

			return Ok();
		}
	}
}
