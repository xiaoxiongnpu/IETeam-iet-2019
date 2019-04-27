using RDFSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Code sample 1: Creating an RDFGraph with 3 triples, then write them to console.
            var rdf = new RDFGraph(new List<RDFTriple>() {
                new RDFTriple(new RDFResource("http://example.org/book/book1"), new RDFResource("http://purl.org/dc/elements/1.1/title"), new RDFPlainLiteral("SPARQL Tutorial")),
                new RDFTriple(new RDFResource("http://example.org/book/book2"), new RDFResource("http://purl.org/dc/elements/1.1/title"), new RDFPlainLiteral("RDF book")),
                new RDFTriple(new RDFResource("https://wwww.w3.org/"), new RDFResource("http://purl.org/dc/elements/1.1/title"), new RDFPlainLiteral("World Wide Web Consortium")),
            });

            foreach(var triple in rdf)
            {
                Console.WriteLine(triple.ToString()); 
            }

            Console.ReadKey();
        }
    }
}
