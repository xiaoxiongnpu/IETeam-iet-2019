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

        //Creating store based on: http://dadev.cloudapp.net/Datos%20Abiertos/PDF/ReferenceGuide.pdf
        public static RDFMemoryStore rdfStore = new RDFMemoryStore();
        public static void CreateStore()
        {
            // "From Wikipedia.com: Mickey Mouse is 85 years old" 
            rdfStore.AddQuadruple(new RDFQuadruple(
                new RDFContext("http://www.wikipedia.com/"),
                new RDFResource("http://www.waltdisney.com/mickey_mouse"),
                new RDFResource("http://xmlns.com/foaf/0.1/age"),
                new RDFTypedLiteral("85", RDFModelEnums.RDFDatatypes.XSD_INT))
            );

            // "From WaltDisney.com: Mickey Mouse is 85 years old" 
            rdfStore.AddQuadruple(new RDFQuadruple(
                new RDFContext("http://www.waltdisney.com/"),
                new RDFResource("http://www.waltdisney.com/mickey_mouse"),
                new RDFResource("http://xmlns.com/foaf/0.1/age"),
                new RDFTypedLiteral("85", RDFModelEnums.RDFDatatypes.XSD_INT))
            );

            // "From Wikipedia.com: Donald Duck has English-US name "Donald Duck"" 
            rdfStore.AddQuadruple(new RDFQuadruple(
                new RDFContext("http://www.wikipedia.com/"),
                new RDFResource("http://www.waltdisney.com/donald_duck"),
                new RDFResource("http://xmlns.com/foaf/0.1/name"),
                new RDFTypedLiteral("Donald Duck", RDFModelEnums.RDFDatatypes.XSD_STRING))
            );
        }
    }
}
