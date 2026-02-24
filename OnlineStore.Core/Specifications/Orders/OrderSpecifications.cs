using OnlineStore.Core.Entities.Order;

namespace OnlineStore.Core.Specifications.Orders
{
	public class OrderSpecifications : BaseSpecifications<Order , int>
	{
		public OrderSpecifications(string buyerEmail , int orderId) 
			: base(x => x.BuyerEmail == buyerEmail && x.Id == orderId)

		{
			ApplyIncludes();
		}
		public OrderSpecifications(string buyerEmail)
			: base(x => x.BuyerEmail == buyerEmail)

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
