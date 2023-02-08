﻿using PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Capabilities;

namespace PgfPlotsSdk.Public.Interfaces.Builders.FluentPgfPlot.Composed;

public interface ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions :
	ICanAddWrapper<ICanAddAxisContents<ICanAddAxisContentsOrSetAxisOptionsOrBuild>, ICanAddPieContents<ICanAddPieContentsOrSetPieOptionsOrBuild>>,
	ICanAddFigureDecorations<ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions>,
	ICanSetWrapperOptions<ICanAddWrapperOrAddWrapperDecorationsOrSetWrapperOptions> { }