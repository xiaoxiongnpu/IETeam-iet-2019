using RDFSharp.Store;
using System;
using System.Linq;
using Xunit;

namespace DemoApp.RDFComponentTests.StoreTests
{
    public static class FederationUnitTests
    {
        [Fact]
        public static void AddStoreToFederationTest()
        {
            RDFFederation fed = StoreBuilder.CreateFederation();
            Assert.Equal(1, fed.StoresCount);
        }

        [Fact]
        public static void RemoveStoreFromFederationTest()
        {
            RDFFederation fed = StoreBuilder.CreateFederation();
            fed.ClearStores();
            Assert.Empty(fed);
        }

        [Fact]
        public static void EmptyConstructorFederation()
        {
            RDFFederation fed = new RDFFederation();
            Assert.NotNull(fed);
        }
        [Fact]
        public static void AddingTwoExactStoresToFederationTest()
        {
            RDFFederation fed = new RDFFederation();
            fed.AddStore(StoreBuilder.CreateStore());
            fed.AddStore(StoreBuilder.CreateStore());
            Assert.NotEqual(fed.First().StoreID, fed.Last().StoreID);
        }
    }
}
