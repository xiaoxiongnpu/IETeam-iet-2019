using RDFSharp.Store;
using System;
using System.Linq;
using Xunit;

namespace DemoApp.RDFComponentTests.StoreTests
{
    public static class ContextUnitTests
    {
        [Fact]
        public static void CreatingEmptyContextTest()
        {
            RDFContext cont = new RDFContext();
            Assert.NotNull(cont);
        }

        [Fact]
        public static void CreatingContextFromURITest()
        {
            RDFContext cont = new RDFContext(new Uri("http://www.wikipedia.com/"));

            Assert.Equal("http://www.wikipedia.com/", cont.ToString()); 
        }
    }
}
