using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

public interface ICanAddAxisPlotOrSetAxisOptions: ICanAddAxisPlot<ICanAddAxisPlotOrSetPlotOptionsOrBuild>, ICanSetAxisOptions<ICanAddAxisPlotOrSetAxisOptions> { }