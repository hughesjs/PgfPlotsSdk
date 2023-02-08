﻿using PgfPlotsSdk.Public.ElementDefinitions.Enums;
using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots;

namespace PgfPlotsSdk.Public.ElementDefinitions.Wrappers;

public class PgfPlotWithAxesDefinition: PgfPlotDefinition
{
	public PgfPlotWithAxesDefinition(AxisOptions axisOptions, AxisType axisType)
	{
		AxisType = axisType;
		AxisOptions = axisOptions;
	}

	public PgfPlotWithAxesDefinition(AxisOptions axisOptions, AxisType axisType, params PlotDefinition[] plotDefinitions): base(plotDefinitions)
	{
		AxisOptions = axisOptions;
		AxisType = axisType;
	}
	
	public AxisOptions AxisOptions { get; }

	public AxisType AxisType { get; }
}