using AutoFixture;
using PgfPlots.Net.Internal.Reflection;
using PgfPlots.Net.Internal.SyntaxTree;
using PgfPlots.Net.Internal.SyntaxTree.Nodes.Axes;
using PgfPlots.Net.Internal.SyntaxTree.Nodes.Options;
using PgfPlots.Net.Public.ElementDefinitions.Enums;
using PgfPlots.Net.Public.ElementDefinitions.Options;
using Shouldly;

namespace PgfPlots.Net.Tests.SyntaxTreeTests.Nodes.Axes;

public class AxisNodeTests
{
    private readonly Fixture _fixture;

    public AxisNodeTests()
    {
        _fixture = new();
    }

    [Fact]
    public void CanGenerateCorrectSourceWithNoOptionsOrPlots()
    {
        AxisNode axisNode = new();
        OptionsCollectionNode optionsNode = new();
        axisNode.AddChild(optionsNode);
        PgfPlotsSyntaxTree tree = new(axisNode);
        const string expected = """
                              \begin{axis}[]
                              \end{axis}
                              """;

        string source = tree.GenerateSource();

        source.ShouldBe(expected);
    }
    
    [Fact]
    public void CanGenerateCorrectSourceWithOptionsButNoPlots()
    {
        AxisOptions axis = _fixture.Create<AxisOptions>();
        Dictionary<string, string?> optionsDict = axis.GetOptionsDictionary();

        
        OptionsCollectionNode optionsCollectionNode = new();
        IEnumerable<OptionNode> optionsNodes = optionsDict.Select(option => new OptionNode(option));
        optionsCollectionNode.AddChildren(optionsNodes);
        
        AxisNode axisNode = new();
        axisNode.AddChild(optionsCollectionNode);

        PgfPlotsSyntaxTree tree = new(axisNode);
        
        string expected = $$"""
                            \begin{axis}[xlabel={{axis.XLabel}}, ylabel={{axis.YLabel}}, xmin={{axis.XMin}}, ymin={{axis.YMin}}, xmax={{axis.XMax}}, ymax={{axis.YMax}}, minor y tick num={{axis.MinorYTickNumber}}, minor x tick num={{axis.MinorXTickNumber}}, major y tick num={{axis.MajorYTickNumber}}, major x tick num={{axis.MajorXTickNumber}}, xtick={{{string.Join(',', axis.XTicks!)}}}, ytick={{{string.Join(',', axis.YTicks!)}}}, grid={{PgfPlotsAttributeHelper.GetPgfPlotsKey<GridSetting>(axis.Grid.ToString()!)}}]
                            \end{axis}
                            """;

        string result = tree.GenerateSource();

        result.ShouldBe(expected);
    }
}