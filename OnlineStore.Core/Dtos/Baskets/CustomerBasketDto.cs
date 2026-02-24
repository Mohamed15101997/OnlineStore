namespace OnlineStore.Core.Dtos.Baskets
{
	public class CustomerBasketDto
	{
		public string Id { get; set; }
		public List<BasketItemDto> Items { get; set; }
	}
}
