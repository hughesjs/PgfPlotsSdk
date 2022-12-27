using PgfPlots.Net.Internal.Services;
using PgfPlots.Net.Public.ElementDefinitions;
using PgfPlots.Net.Public.ElementDefinitions.Options;
using PgfPlots.Net.Public.Exceptions;
using PgfPlots.Net.Public.Interfaces.Services;
using Shouldly;

namespace PgfPlots.Net.Tests.Services;

public class PgfPlotSourceGeneratorTests
{
	private readonly IPgfPlotSourceGenerator _sourceGenerator = new PgfPlotSourceGenerator();
	
	[Fact]
	public void GeneratesSourceWithValidDefinition()
	{
		PgfPlotDefinition definition = new(new(), new());
		string res = _sourceGenerator.GenerateSourceCode(definition);
		res.ShouldNotBeNullOrEmpty();
	}

	[Fact]
	public void ThrowsPgfPlotGenerationExceptionWithInvalidDefinition()
	{
		PgfPlotDefinition definition = new(null!, new());
		PgfPlotsGeneratorException ex = Should.Throw<PgfPlotsGeneratorException>(() => _sourceGenerator.GenerateSourceCode(definition));
		ex.InnerException.ShouldNotBeNull();
	}
}