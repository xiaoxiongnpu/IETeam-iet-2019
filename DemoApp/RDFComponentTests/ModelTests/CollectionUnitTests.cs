using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoApp.RDFComponentTests.ModelTests
{
    public static class CollectionUnitTests
    {
        [Fact]
        public static void addRersourceItemToCollection()
        {
            var collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Resourse);
            var resourse = new RDFResource("https://www.index.hu");
            collection.AddItem(resourse);
            Assert.Equal(1, collection.ItemCount);
        }

        [Fact]
        public static void addLiteralItemToCollection()
        {
            var collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Literal);
            var literal = new RDFLiteral("https://www.index.hu");
            collection.AddItem(literal);
            Assert.Equal(1, collection.ItemCount);
        }
    }
}
