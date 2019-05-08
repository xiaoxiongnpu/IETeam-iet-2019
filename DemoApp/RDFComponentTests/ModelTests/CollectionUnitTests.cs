using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.RDFComponentTests.ModelTests
{
    public static class CollectionUnitTests
    {
        [Fact]
        public void AddResourceItemTest()
        {
            var collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
            var resource = new RDFResource("https://www.index.hu");
            collection.AddItem(resource);
            Assert.Equal(1, collection.ItemsCount);
        }

        [Fact]
        public void AddLiteralItemTest()
        {
            var collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Literal);
            var literal = new RDFLiteral("https://www.index.hu");
            collection.AddItem(literal);
            Assert.Equal(1, collection.ItemsCount);
        }
    }
}
