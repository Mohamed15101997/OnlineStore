using System.Runtime.Serialization;

namespace OnlineStore.Core.Entities.Order
{
	public enum OrderStatus
	{
		[EnumMember(Value = "Pendeing")]
		Pendeing ,
		[EnumMember(Value = "PaymentReceived")]
		PaymentReceived,
		[EnumMember(Value = "PaymentFaild")]
		PaymentFaild,
	}
}
