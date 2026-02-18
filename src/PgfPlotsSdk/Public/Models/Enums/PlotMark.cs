using PgfPlotsSdk.Internal.Attributes;

namespace PgfPlotsSdk.Public.Models.Enums;

public enum PlotMark
{
    [PgfPlotsKey("none")]
    None,
    
    [PgfPlotsKey("*")]
    Star,

    [PgfPlotsKey("+")]
    Plus,

    [PgfPlotsKey("x")]
    Cross,

    [PgfPlotsKey("o")]
    Circle,

    [PgfPlotsKey("square")]
    Square,

    [PgfPlotsKey("triangle")]
    Triangle,

    [PgfPlotsKey("diamond")]
    Diamond,

    [PgfPlotsKey("pentagon")]
    Pentagon
}