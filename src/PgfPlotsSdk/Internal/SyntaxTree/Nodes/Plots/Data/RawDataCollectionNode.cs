using PgfPlotsSdk.Public.Interfaces.Data;

namespace PgfPlotsSdk.Internal.SyntaxTree.Nodes.Plots.Data;

internal class RawDataCollectionNode: SyntaxNode
{
    public RawDataCollectionNode(IEnumerable<ILatexData> data)
    {
        foreach (ILatexData d in data)
        {
            AddChild(new RawDataNode(d));
        }
    }

    public RawDataCollectionNode(ILatexData data) // For instances where you've built a collection container already
    {
        AddChild(new RawDataNode(data));
    }

    protected override string BeforeChildren => " plot coordinates {";
    protected override string BetweenChildren => " ";
    protected override string AfterChildren => "}";

}