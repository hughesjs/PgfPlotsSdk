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
    Pentagon,

    [PgfPlotsKey("asterisk")]
    Asterisk,

    [PgfPlotsKey("star")]
    FiveStar,

    [PgfPlotsKey("|")]
    Bar,

    [PgfPlotsKey("-")]
    Dash,

    [PgfPlotsKey("square*")]
    FilledSquare,

    [PgfPlotsKey("triangle*")]
    FilledTriangle,

    [PgfPlotsKey("diamond*")]
    FilledDiamond,

    [PgfPlotsKey("pentagon*")]
    FilledPentagon,

    [PgfPlotsKey("oplus")]
    Oplus,

    [PgfPlotsKey("oplus*")]
    FilledOplus,

    [PgfPlotsKey("otimes")]
    Otimes,

    [PgfPlotsKey("otimes*")]
    FilledOtimes
}