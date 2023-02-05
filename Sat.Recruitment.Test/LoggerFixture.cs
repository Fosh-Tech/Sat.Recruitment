using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Sat.Recruitment.Test;

// https://xunit.net/docs/capturing-output
// NOTE: If you used xUnit.net 1.x, you may have previously been writing output
// to Console, Debug, or Trace. When xUnit.net v2 shipped with parallelization
// turned on by default, this output capture mechanism was no longer appropriate.
// 
// https://stackoverflow.com/a/47328428/10989106

public class LoggerFixture : IDisposable
{
    private ILoggerFactory _factory;
    public LoggerFixture()
    {
        _factory = new NullLoggerFactory();
    }
    
    /// <summary>
    /// Create ILogger&lt;T&gt; logger and ignore, use ITestOutputHelper instead in xUnit tests.
    /// </summary>
    public ILoggerFactory Factory => _factory;

    public void Dispose()
    {
        _factory.Dispose();
    }
}