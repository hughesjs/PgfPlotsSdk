using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.Models.Enums;

// TODO - Handle these in options
[Flags]
[PgfPlotsFlagSeparator("")]
public enum PositionFlags
{
	[PgfPlotsKey("h")]
	Here = 1,
	
	[PgfPlotsKey("t")]
	Top = 1 << 1,
	
	[PgfPlotsKey("b")]
	Bottom  = 1 << 2,
	
	[PgfPlotsKey("p")]
	SeparatePage = 1 << 3,
	
	[PgfPlotsKey("!")]
	Force = 1 << 4,
	
	[PgfPlotsKey("H")]
	ForceExactlyHere = 1 << 5
}