using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.Models.Enums;

public enum PieTextOption
{
	[PgfPlotsKey("label")]
	Label,

	[PgfPlotsKey("pin")]
	Pin,
		
	[PgfPlotsKey("inside")]
	Inside,
	
	[PgfPlotsKey("legend")]
	Legend
}