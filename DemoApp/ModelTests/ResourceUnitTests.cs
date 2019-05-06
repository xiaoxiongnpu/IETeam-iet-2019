using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDFSharp.Model;
using Xunit;

namespace DemoApp.ModelTests
{
    /* Egy RDFResource létrehozásával egy NODE-ot
    *  vagy egy URI-t példányosítunk ez true értékkel tér vissza,
    *  ha a megadott paraméter egy resource-nak felel meg
    */
    public class ResourceUnitTests
    {
        [Fact]
        public static void CreatingResourceWithValidURITest()
        {
            //Erőforrás string-ként megadott URI-ból
            var validURI = new RDFResource("https://www.youtube.com/");
            Assert.Equal("https://www.youtube.com/", validURI.URI.ToString());
        }

        [Fact]
        public static void CreatingBlankResourceTest()
        {
            //Tudunk üres erőforrás objektumot is létrehozni
            var validURI = new RDFResource();
            Assert.True(validURI.IsBlank);
        }

        [Fact]
        public static void CreatingResourceWithInValidURITest()
        {
            try
            {
                new RDFResource("invalid input which is not a URI");
            }
            catch (RDFModelException me)
            {
                Console.WriteLine("{0} exception caught",me);
            }
        }
    }
}
