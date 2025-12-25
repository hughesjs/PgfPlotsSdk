using PgfPlotsSdk.Public.Builders;
using PgfPlotsSdk.Public.Generated;
using PgfPlotsSdk.Public.Interfaces.Data;
using PgfPlotsSdk.Public.Models.Enums;
using PgfPlotsSdk.Public.Models.Options;
using PgfPlotsSdk.Public.Models.Plots.Data;
using Shouldly;

namespace PgfPlotsSdk.Tests.Builders.FluentPgfPlot;

public class PgfPlotBuilderTests
{
	private readonly ICanAddPgfPlotWithAxesOrAddPgfPlotOrAddFigure _root;

	private static readonly ILatexData[] Data1 =
	{
		new Cartesian2<int>(0, 1),
		new Cartesian2<int>(2, 3),
		new Cartesian2<int>(4, 5)
	};

	private static readonly ILatexData[] Data2 =
	{
		new Cartesian2<int>(5, 6),
		new Cartesian2<int>(7, 8),
		new Cartesian2<int>(8, 2)
	};

	public PgfPlotBuilderTests()
	{
		_root = PgfPlotBuilder.CreateBuilder();
	}

	[Fact]
	public void BuilderIsCreated()
	{
		_root.ShouldNotBeNull();
	}

	[Fact]
	public void CanCreateBasicPlot()
	{
		const string expected = """

								\begin{tikzpicture}
								\begin{axis}
								\addplot plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard, null)
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanCreateBasicPlotWithAxesOptions()
	{
		const string expected = """
	
								\begin{tikzpicture}
								\begin{semilogxaxis}[minor x tick num=12, grid=both]
								\addplot plot coordinates {(0,1) (2,3) (4,5)};
								\end{semilogxaxis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.SemiLogX, new AxisOptions
			{
				Grid = GridSetting.Both,
				MinorXTickNumber = 12
			})
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanCreateBasicPlotWithBuiltAxesOptions()
	{
		const string expected = """

								\begin{tikzpicture}
								\begin{semilogyaxis}[xlabel=XLabel, ylabel=YLabel, xmin=-1, ymin=-4, xmax=10, ymax=11, minor x tick num=4, xtick={2,3,4}, ytick={2,4,6}, grid=both]
								\addplot plot coordinates {(0,1) (2,3) (4,5)};
								\end{semilogyaxis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.SemiLogY)
			.SetXLabel("XLabel")
			.SetYLabel("YLabel")
			.SetGrid(GridSetting.Both)
			.SetXMax(10)
			.SetYMax(11)
			.SetXMin(-1)
			.SetYMin(-4)
			.SetXTicks(2,3,4)
			.SetYTicks(2,4,6)
			.SetMinorXTickNumber(3)
			.SetMinorYTickNumber(4)
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanCreatePlotWithAxisOptions()
	{
		const string expected = """

								\begin{tikzpicture}
								\begin{axis}[xlabel=XAxis, ylabel=YAxis]
								\addplot plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard, new AxisOptions
			{
				XLabel = "XAxis",
				YLabel = "YAxis"
			})
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanCreatePlotWithBuiltAxisOptions()
	{
		const string expected = """

								\begin{tikzpicture}
								\begin{axis}[xlabel=XAxis, ylabel=YAxis]
								\addplot plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard)
			.SetXLabel("XAxis")
			.SetYLabel("YAxis")
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanCreateChartWithTwoPlots()
	{
		const string expected = """

								\begin{tikzpicture}
								\begin{axis}[xlabel=XAxis, ylabel=YAxis]
								\addplot plot coordinates {(0,1) (2,3) (4,5)};
								\addplot plot coordinates {(5,6) (7,8) (8,2)};
								\end{axis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard, new AxisOptions
			{
				XLabel = "XAxis",
				YLabel = "YAxis"
			})
			.AddPlot(Data1)
			.AddPlot(Data2)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanCreatePlotWithPlotOptions()
	{
		const string expected = """

								\begin{tikzpicture}
								\begin{axis}
								\addplot[ybar, only marks] plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard)
			.AddPlot(Data1, new PlotOptions
			{
				BarType = BarType.YBar,
				OnlyMarks = true
			})
			.Build();

		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanCreatePlotWithBuiltPlotOptions()
	{
		const string expected = """

								\begin{tikzpicture}
								\begin{axis}
								\addplot[ybar, only marks] plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard)
			.AddPlot(Data1)
			.SetBarType(BarType.YBar)
			.SetOnlyMarks(true)
			.Build();

		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanCreateDoublePlotWithBuiltPlotOptions()
	{
		const string expected = """

								\begin{tikzpicture}
								\begin{axis}
								\addplot[color=Bittersweet, mark=o, ybar, smooth, only marks] plot coordinates {(0,1) (2,3) (4,5)};
								\addplot[mark size=12, line width=1, fill opacity=0.4, solid, bar width=1.2, fill=Cerulean] plot coordinates {(4,5) (2,3) (0,1)};
								\end{axis}
								\end{tikzpicture}
								""";

		string res = _root
			.AddPgfPlotWithAxes(AxisType.Standard)
			.AddPlot(Data1)
			.SetBarType(BarType.YBar)
			.SetOnlyMarks(true)
			.SetColour(LatexColour.Bittersweet)
			.SetMark(PlotMark.Circle)
			.SetSmooth(true)
			.AddPlot(Data1.AsEnumerable().Reverse())
			.SetBarWidth(1.2f)
			.SetFillColour(LatexColour.Cerulean)
			.SetFillOpacity(0.4f)
			.SetLineStyle(LineStyle.Solid)
			.SetLineWidth(1)
			.SetMarkSize(12)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanCreatePlotWrappedInFigure()
	{
		const string expected = """
								\begin{figure}
								\begin{tikzpicture}
								\begin{axis}
								\addplot plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								\end{figure}
								""";
		string res = _root.AddFigure()
			.AddPgfPlotWithAxes(AxisType.Standard)
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanCreatePlotWrappedInFigureWithPosition()
	{
		const string expected = """
								\begin{figure}[htb]
								\begin{tikzpicture}
								\begin{axis}
								\addplot plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								\end{figure}
								""";
		string res = _root.AddFigure(new FigureOptions
			{
				Position = PositionFlags.Here | PositionFlags.Top | PositionFlags.Bottom
			})
			.AddPgfPlotWithAxes(AxisType.Standard)
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanCreatePlotWrappedInFigureWithBuiltPosition()
	{
		const string expected = """
								\begin{figure}[htb]
								\begin{tikzpicture}
								\begin{axis}
								\addplot plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								\end{figure}
								""";
		string res = _root.AddFigure()
			.SetPlacementFlag(PositionFlags.Here)
			.SetPlacementFlag(PositionFlags.Top)
			.SetPlacementFlag(PositionFlags.Bottom)
			.AddPgfPlotWithAxes(AxisType.Standard)
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanAddCaptionAndLabelToFigure()
	{
		const string expected = """
								\begin{figure}
								\begin{tikzpicture}
								\begin{axis}
								\addplot plot coordinates {(0,1) (2,3) (4,5)};
								\end{axis}
								\end{tikzpicture}
								\caption{This is my caption!}
								\label{fig:myfig}
								\end{figure}
								""";
		string res = _root.AddFigure()
			.SetCaption("This is my caption!")
			.SetLabel("fig:myfig")
			.AddPgfPlotWithAxes(AxisType.Standard)
			.AddPlot(Data1)
			.Build();

		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanCreateMultiplotMultiOptionFigure()
	{
		const string expected = """
								\begin{figure}[H]
								\begin{tikzpicture}
								\begin{axis}[xlabel=The Value of X, ylabel=The Value of Y, grid=both]
								\addplot[color=Cerulean, mark=*] plot coordinates {(0,1) (2,3) (4,5)};
								\addplot[color=Sepia, mark=o, dashed] plot coordinates {(5,6) (7,8) (8,2)};
								\end{axis}
								\end{tikzpicture}
								\caption{This is my caption!}
								\label{fig:myfig}
								\end{figure}
								""";
		string res = _root.AddFigure()
			.SetPlacementFlag(PositionFlags.ForceExactlyHere)
			.SetCaption("This is my caption!")
			.SetLabel("fig:myfig")
			.AddPgfPlotWithAxes(AxisType.Standard)
			.SetXLabel("The Value of X")
			.SetYLabel("The Value of Y")
			.SetGrid(GridSetting.Both)
			.AddPlot(Data1)
			.SetColour(LatexColour.Cerulean)
			.SetMark(PlotMark.Star)
			.AddPlot(Data2)
			.SetColour(LatexColour.Sepia)
			.SetLineStyle(LineStyle.Dashed)
			.SetMark(PlotMark.Circle)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanCreateSimplePie()
	{
		const string expected = """

                                \begin{tikzpicture}
                                \pie {5, 10, 15};
                                \end{tikzpicture}
                                """;

		PieChartSliceData<int> chartSliceOne = new(5);
		PieChartSliceData<int> chartSliceTwo = new(10);
		PieChartSliceData<int> chartSliceThree = new(15);
		PieChartSliceData<int>[] slices = { chartSliceOne, chartSliceTwo, chartSliceThree };

		string res = _root.AddPgfPlot()
			.AddPie(slices)
			.Build();

		res.ShouldBe(expected);
	}

	[Fact]
	public void CanCreatePieWithOptions()
	{
		const string expected = """

                                \begin{tikzpicture}
                                \pie [polar, pos={1,1}, radius=2.3, color={red,green,blue}, sum=30, scale font, after number=\%]{5, 10, 15};
                                \end{tikzpicture}
                                """;

		PieChartSliceData<int> chartSliceOne = new(5);
		PieChartSliceData<int> chartSliceTwo = new(10);
		PieChartSliceData<int> chartSliceThree = new(15);
		PieChartSliceData<int>[] slices = { chartSliceOne, chartSliceTwo, chartSliceThree };

		string res = _root.AddPgfPlot()
			.AddPie(slices, new PieChartOptions
			{
				CentrePosition = new(1, 1),
				ReferenceSum = 30,
				AfterNumberText = @"\%",
				Radius = 2.3f,
				PieChartType = PieType.Polar,
				ScaleFont = true,
				SliceColours = new() { LatexColour.Red, LatexColour.Green, LatexColour.Blue }
			})
			.Build();

		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanCreatePieWithBuiltOptions()
	{
		const string expected = """

                                \begin{tikzpicture}
                                \pie [polar, pos={1,2}, radius=2.3, color={red,green,blue}, sum=30, scale font, after number=\%]{5, 10, 15};
                                \end{tikzpicture}
                                """;

		PieChartSliceData<int> chartSliceOne = new(5);
		PieChartSliceData<int> chartSliceTwo = new(10);
		PieChartSliceData<int> chartSliceThree = new(15);
		PieChartSliceData<int>[] slices = { chartSliceOne, chartSliceTwo, chartSliceThree };

		string res = _root.AddPgfPlot()
			.AddPie(slices)
			.SetCentrePosition(1,2)
			.SetReferenceSum(30)
			.SetAfterNumberText(@"\%")
			.SetRadius(2.3f)
			.SetPieChartType(PieType.Polar)
			.SetScaleFont(true)
			.SetSliceColours(LatexColour.Red, LatexColour.Green, LatexColour.Blue)
			.Build();

		res.ShouldBe(expected);
	}
	
	[Fact]
	public void CanCreateDoublePieWithBuiltOptions()
	{
		const string expected = """

								\begin{tikzpicture}
								\pie [polar, pos={1,2}, radius=2.3, color={red,green,blue}, sum=30, scale font, after number=\%]{5, 10, 15};
								\pie [rotate=12, explode={1,2.4}, hide number, before number=A, text=inside]{15, 10, 5};
								\end{tikzpicture}
								""";

		PieChartSliceData<int> chartSliceOne = new(5);
		PieChartSliceData<int> chartSliceTwo = new(10);
		PieChartSliceData<int> chartSliceThree = new(15);
		PieChartSliceData<int>[] slicesOne = { chartSliceOne, chartSliceTwo, chartSliceThree };
		PieChartSliceData<int>[] slicesTwo = slicesOne.AsEnumerable().Reverse().ToArray();

		string res = _root.AddPgfPlot()
			.AddPie(slicesOne)
			.SetCentrePosition(1,2)
			.SetReferenceSum(30)
			.SetAfterNumberText(@"\%")
			.SetRadius(2.3f)
			.SetPieChartType(PieType.Polar)
			.SetScaleFont(true)
			.SetSliceColours(LatexColour.Red, LatexColour.Green, LatexColour.Blue)
			.AddPie(slicesTwo)
			.SetHideNumber(true)
			.SetTextPosition(PieTextOption.Inside)
			.SetBeforeNumberText("A")
			.SetRotation(12)
			.SetSliceExplosionFactors(1,2.4f)
			.Build();

		res.ShouldBe(expected);
	}
}