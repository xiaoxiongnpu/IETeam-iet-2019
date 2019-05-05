using RDFSharp.Model;
using RDFSharp.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    class Program
    {
        //source: http://dadev.cloudapp.net/Datos%20Abiertos/PDF/ReferenceGuide.pdf
        static void Main(string[] args)
        {
            Console.WriteLine("TRIPLES AND GRAPH DEMO");
            //create resource from string
            RDFResource donaldduck = new RDFResource("http://www.waltdisney.com/donald_duck");

            //create resource from uri
            RDFResource goofygoof = new RDFResource(new Uri("http://www.waltdisney.com/goofy_goof").ToString());

            //create blank resource
            RDFResource disney_group = new RDFResource();

            //create plain literal
            // "Donald Duck"
            RDFPlainLiteral donaldduck_name = new RDFPlainLiteral("Donald Duck");
            //create plain literal with language tag
            // "Donald Duck"@en-US
            RDFPlainLiteral donaldduck_name_enus = new RDFPlainLiteral("Donald Duck", "en-US");
            //create typed literal
            // "85"^^xsd:integer
            RDFTypedLiteral mickeymouse_age = new RDFTypedLiteral("85", RDFModelEnums.RDFDatatypes.XSD_INTEGER);


            //create triples
            // "Mickey Mouse is 85 years old"
            RDFTriple mickeymouse_is85yr = new RDFTriple(new RDFResource("http://www.waltdisney.com/mickey_mouse"),
                                                         new RDFResource("http://xmlns.com/foaf/0.1/age"),
                                                         mickeymouse_age);

            // "Donald Duck has English-US name "Donald Duck""
            RDFTriple donaldduck_name_enus_triple = new RDFTriple(donaldduck, 
                                                                  new RDFResource("http://xmlns.com/foaf/0.1/name"), 
                                                                  donaldduck_name_enus);

            // "Goofy Goof is 82 years old"
            RDFTriple goofygoof_is82yr = new RDFTriple(goofygoof,
                                                       RDFVocabulary.FOAF.AGE,
                                                       new RDFPlainLiteral("82"));
            // "Donald Duck knows Goofy Goof"
            RDFTriple donaldduck_knows_goofygoof = new RDFTriple(donaldduck,
                                                                 RDFVocabulary.FOAF.KNOWS,
                                                                 goofygoof);

            //create graph from a list of triples
            List<RDFTriple> triples = new List<RDFTriple>()
            {
                mickeymouse_is85yr,
                donaldduck_name_enus_triple,
                goofygoof_is82yr,
                donaldduck_knows_goofygoof
            };
            RDFGraph waltdisney = new RDFGraph(triples);

            //set context of a graph
            waltdisney.SetContext(new Uri("http://waltdisney.com/"));

            //iterate triples of a graph
            foreach (RDFTriple t in waltdisney)
            {
                Console.WriteLine("Triple: " + t);
                Console.WriteLine("Subject: " + t.Subject);
                Console.WriteLine("Predicate: " + t.Predicate);
                Console.WriteLine("Object: " + t.Object);
                Console.WriteLine();
            }

            //compose multiple selections
            RDFGraph triples_by_subject_and_predicate =
            waltdisney.SelectTriplesBySubject(donaldduck)
             .SelectTriplesByPredicate(new RDFResource("http://xmlns.com/foaf/0.1/name"));

            Console.WriteLine("Number of triples where the subject is Donald Duck and the predicate is foaf:name: " + triples_by_subject_and_predicate.TriplesCount);
            Console.WriteLine();

            Console.WriteLine("NAMESPACES DEMO");
            //create namespace
            RDFNamespace waltdisney_ns = new RDFNamespace("wd", "http://www.waltdisney.com/");
            //use namespace in resource creation
            RDFResource duckburg = new RDFResource(waltdisney_ns + "duckburg");
            RDFResource mouseton = new RDFResource(waltdisney_ns + "mouseton");

            //get default namespace
            RDFNamespace nSpace = RDFNamespaceRegister.DefaultNamespace;

            //set default namespace
            RDFNamespaceRegister.SetDefaultNamespace(waltdisney_ns); //new graphs will default to this context

            //iterate namespaces
            foreach (RDFNamespace ns in RDFNamespaceRegister.Instance)
            {
                Console.WriteLine("Prefix: " + ns.NamespacePrefix);
                Console.WriteLine("Namespace: " + ns.NamespaceUri);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
