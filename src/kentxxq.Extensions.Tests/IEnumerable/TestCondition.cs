using System.Collections.Generic;
using System.Linq;
using kentxxq.Extensions.IEnumerable;
using Xunit;

namespace kentxxq.Extensions.Tests.IEnumerable;

public class TestCondition
{
    private static readonly List<string> Data = new() { "a", "b", "c", "d" };

    [Fact]
    public void TestIf()
    {
        var result = Data.If(true, p => p.Where(i => i == "d"));
        Assert.Single(result);
        Assert.Equal("d", result.First());
    }
}
