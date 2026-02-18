using System.Numerics;
using PgfPlotsSdk.Public.Models.Plots.Data;

namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Pies.Data;

internal class RawPieSliceCollectionNode<T>: SyntaxNode where T : INumber<T>
{
	public RawPieSliceCollectionNode(params PieChartSliceData<T>[] data) // For instances where you've built a collection container already
	{
		foreach (PieChartSliceData<T> d in data)
		{
			AddChild(new RawSliceNode<T>(d));
		}
	}

	protected override string BeforeChildren => "{";
	protected override string BetweenChildren => ", ";
	protected override string AfterChildren => "}";
}
