using RDFSharp.Model;
using RDFSharp.Store;
using System;
using System.Linq;
using Xunit;

namespace DemoApp.RDFComponentTests.StoreTests
{
    public static class QuadrupleUnitTests
    {
        [Fact]
        public static void GetQuadrupleContextTest()
        {
            RDFQuadruple quad = new RDFQuadruple(
                new RDFContext("http://www.wikipedia.com/"),
                new RDFResource("http://www.waltdisney.com/mickey_mouse"),
                new RDFResource("http://xmlns.com/foaf/0.1/age"),
                new RDFTypedLiteral("85", RDFModelEnums.RDFDatatypes.XSD_INT));

            Assert.Equal("http://www.wikipedia.com/", quad.Context.ToString());
        }

        [Fact]
        public static void GetQuadruplePredicateTest()
        {
            RDFQuadruple quad = new RDFQuadruple(
                new RDFContext("http://www.wikipedia.com/"),
                new RDFResource("http://www.waltdisney.com/mickey_mouse"),
                new RDFResource("http://xmlns.com/foaf/0.1/age"),
                new RDFTypedLiteral("85", RDFModelEnums.RDFDatatypes.XSD_INT));

            Assert.Equal("http://xmlns.com/foaf/0.1/age", quad.Predicate.ToString());
        }
        [Fact]
        public static void GetQuadrupleSubjectTest()
        {
            RDFQuadruple quad = new RDFQuadruple(
                new RDFContext("http://www.wikipedia.com/"),
                new RDFResource("http://www.waltdisney.com/mickey_mouse"),
                new RDFResource("http://xmlns.com/foaf/0.1/age"),
                new RDFTypedLiteral("85", RDFModelEnums.RDFDatatypes.XSD_INT));

            Assert.Equal("http://www.waltdisney.com/mickey_mouse", quad.Subject.ToString());
        }

    }
}
