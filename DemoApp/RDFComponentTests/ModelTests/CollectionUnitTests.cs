using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDFSharp.Model;
using Xunit;

namespace DemoApp.RDFComponentTests.ModelTests
{
    public static class CollectionUnitTests
    {
        #region AddTests
        [Fact]
        public void AddNullTest()
        {
            var collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
            RDFResource resource = null;
            collection.AddItem(resource);
            Assert.Equal(1, collection.ItemsCount);
        }

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

        [Fact]
        public static void EmptyCollectionTest()
        {
            var collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
            Assert.Equal(0, collection.ItemsCount);
        }

        [Fact]
        public static void DuplicatedItemsTest()
        {
            var collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
            var item1 = new RDFResource("https://index.hu");
            var item2= new RDFResource("https://index.hu");

            collection.AddItem(item1);
            collection.AddItem(item2);
            Assert.Equal(1, collection.ItemsCount);
        }
        #endregion

        #region RemoveTests
        [Fact]
        public static void RemoveResourceItemTest()
        {
            var collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
            var resource = new RDFResource("https://www.index.hu");
            collection.AddItem(resource);

            collection.RemoveItem(resource);
            Assert.Equal(RDFVocabulary.RDF.NIL, collection.ReificationSubject);
            Assert.Equal(0, collection.ItemsCount);
        }

        [Fact]
        public static void RemoveLiteralItemTest()
        {
            var collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Literal);
            var literal = new RDFResource("https://www.index.hu");
            collection.AddItem(literal);

            collection.RemoveItem(literal);
            Assert.Equal(RDFVocabulary.RDF.NIL, collection.ReificationSubject);
            Assert.Equal(0, collection.ItemsCount);
        }

        [Fact]
        public static void ClearItemsTest()
        {
            var collection = new RDFCollection(RDFModelEnums.RDFItemTypes.Resource);
            var resource1 = new RDFResource("https://www.index.hu");
            var resource2 = new RDFResource("https://www.google.com");
            collection.AddItem(resource1);
            collection.AddItem(resource2);

            collection.ClearItems();
            Assert.Equal(RDFVocabulary.RDF.NIL, collection.ReificationSubject);
            Assert.Equal(0, collection.ItemsCount);
        }
        #endregion
    }
}
