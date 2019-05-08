using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RDFSharp.Model;

namespace DemoApp.RDFComponentTests.ModelTests
{
    public static class ContainerUnitTests
    {
        #region AddTests
        [Fact]
        public static void AddResourceItemTest()
        {
            var container = new RDFContainer(RDFModelEnums.RDFContainerTypes.Bag, RDFModelEnums.RDFItemTypes.Resource);
            container.AddItem(new RDFResource("https://www.index.hu"));
            Assert.Equal(1, container.ItemsCount);
        }

        [Fact]
        public static void AddLiteralItemTest()
        {
            var container = new RDFContainer(RDFModelEnums.RDFContainerTypes.Bag, RDFModelEnums.RDFItemTypes.Resource);
            container.AddItem(new RDFLiteral("literalString"));
            Assert.Equal(1, container.ItemsCount);
        }

        [Fact]
        public static void DuplicateItemTest()
        {
            var container = new RDFContainer(RDFModelEnums.RDFContainerTypes.Alt, RDFModelEnums.RDFItemTypes.Resource);
            container.AddItem(new RDFResource("https://www.index.hu"));
            container.AddItem(new RDFResource("https://www.index.hu"));
            Assert.Equal(1, container.ItemsCount);
        }
        #endregion

        #region RemoveTests
        [Fact]
        public static void RemoveResourceItemTest()
        {
            var container = new RDFContainer(RDFModelEnums.RDFContainerTypes.Alt, RDFModelEnums.RDFItemTypes.Resource);
            var resource = new RDFResource("https://www.index.hu");
            container.AddItem(resource);

            container.RemoveItem(resource);

            Assert.Equal(0, container.ItemsCount);
        }

        [Fact]
        public static void RemoveLiteralItemTest()
        {
            var container = new RDFContainer(RDFModelEnums.RDFContainerTypes.Alt, RDFModelEnums.RDFItemTypes.Literal);
            var literal = new RDFLiteral("literalString");
            container.AddItem(literal);

            container.RemoveItem(literal);

            Assert.Equal(0, container.ItemsCount);
        }

        [Fact]
        public static void RemoveFromEmptyContainerTest()
        {
            var container = new RDFContainer(RDFModelEnums.RDFContainerTypes.Alt, RDFModelEnums.RDFItemTypes.Resource);
            var resource = new RDFResource("https://www.index.hu");

            container.RemoveItem(resource);

            Assert.Equal(0, container.ItemsCount);
        }
        #endregion

        #region ReifyTests
        [Fact]
        public static void ReifyEmptyContainerTest()
        {
            var container = new RDFContainer(RDFModelEnums.RDFContainerTypes.Set, RDFModelEnums.RDFItemTypes.Resource);
            var emptyGraph = container.ReifyContainer();
            Assert.Equal(1, emptyGraph.TriplesCount);
        }
        #endregion
    }
}
