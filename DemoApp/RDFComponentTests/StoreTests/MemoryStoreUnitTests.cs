using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RDFSharp.Store;
using RDFSharp.Model;

namespace DemoApp.RDFComponentTests.StoreTests
{
    public static class MemoryStoreUnitTests
    {

        [Fact]
        public static void CreateSimpleStoreTest()
        {
            RDFMemoryStore rdfms = StoreBuilder.CreateStore();
            Assert.Equal(3, rdfms.QuadruplesCount);
        }

        [Fact]
        public static void ContainsQuadrupleTest()
        {
            RDFMemoryStore rdfms = StoreBuilder.CreateStore();
            RDFQuadruple contain = (new RDFQuadruple(
                new RDFContext("http://www.waltdisney.com/"),
                new RDFResource("http://www.waltdisney.com/mickey_mouse"),
                new RDFResource("http://xmlns.com/foaf/0.1/age"),
                new RDFTypedLiteral("85", RDFModelEnums.RDFDatatypes.XSD_INT))
            );
            Assert.True(rdfms.ContainsQuadruple(contain));
        }        
    }
}
