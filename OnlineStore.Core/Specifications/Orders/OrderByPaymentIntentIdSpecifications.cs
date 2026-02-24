using OnlineStore.Core.Entities.Order;

namespace OnlineStore.Core.Specifications.Orders
{
	public class OrderByPaymentIntentIdSpecifications : BaseSpecifications<Order,int>
	{
		public OrderByPaymentIntentIdSpecifications( string paymentIntentId)
			: base(x => x.PaymentIntentId == paymentIntentId)

		{
			ApplyIncludes();
		}
		public void ApplyIncludes()
		{
			Includes.Add(x => x.DeliveryMethod);
			Includes.Add(x => x.Items);
		}
	}
}
