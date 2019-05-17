using RDFSharp.Model;
using RDFSharp.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DemoApp.RDFComponentTests.QueryTests
{
    public class FilterTests
    {
        private RDFGraph graph;
        private RDFPatternGroup pg1;
        private RDFResource donaldduck;
        private RDFResource goofygoof;
        private RDFVariable x;
        private RDFVariable y;
        private RDFVariable n;
        private RDFVariable h;
        private RDFResource dogOf;
        private RDFPattern n_y_dogOf_x;
        private RDFPattern y_dogOf_x;

        private readonly ITestOutputHelper output;

        public FilterTests(ITestOutputHelper output)
        {
            graph = GraphBuilder.WaltDisneyGraphBuild();
            donaldduck = new RDFResource("http://www.waltdisney.com/donald_duck");
            goofygoof = new RDFResource("http://www.waltdisney.com/goofy_goof");
            x = new RDFVariable("x");
            y = new RDFVariable("y");
            n = new RDFVariable("n");
            h = new RDFVariable("h");
            pg1 = new RDFPatternGroup("PG1");
            dogOf = new RDFResource(RDFVocabulary.DC.BASE_URI + "dogOf");

            this.output = output;
        }

        [Fact]
        public void CreateVariableTest()
        {
            x = new RDFVariable("x");
            Assert.Equal("?X", x.VariableName);
        }

        [Fact]
        public void CreatePatternGroupTest()
        {
            pg1 = new RDFPatternGroup("PG1");
            Assert.Equal("PG1", pg1.PatternGroupName);
        }

        [Fact]
        public void CreateTriplePatternTest()
        {
            y_dogOf_x = new RDFPattern(y, dogOf, x);
            Assert.Equal(x, y_dogOf_x.Object);
        }

        [Fact]
        public void CreateQuadruplePatternTest()
        {
            n_y_dogOf_x = new RDFPattern(n, y, dogOf, x);
            Assert.Equal(y, n_y_dogOf_x.Subject);
        }

        [Fact]
        public void CreateEmptySelectQueryTest()
        {
            var selectQuery = new RDFSelectQuery();
            Assert.NotEqual(0, selectQuery.QueryMemberID);
        }

        [Fact]
        public void CreateSelectQueryResultTest()
        {
            var selectQuery = new RDFSelectQuery();
            var selectQueryResult = selectQuery.ApplyToGraph(graph);
            Assert.Equal(0, selectQueryResult.SelectResultsCount);
        }

        [Fact]
        public void CreateEmptyAskQueryTest()
        {
            var askQuery= new RDFAskQuery();
            Assert.NotEqual(0, askQuery.QueryMemberID);
        }

        [Fact]
        public void CreateAskQueryResultTest()
        {
            var askQuery = new RDFAskQuery();
            var askQueryResult = askQuery.ApplyToGraph(graph);
            Assert.False(askQueryResult.AskResult);
        }

        [Fact]
        public void CreateEmptyConstructQueryTest()
        {
            var constructQuery = new RDFConstructQuery();
            Assert.NotEqual(0, constructQuery.QueryMemberID);
        }

        [Fact]
        public void CreateConstructQueryResultTest()
        {
            var constructQuery = new RDFConstructQuery();
            RDFConstructQueryResult constructQueryResult = constructQuery.ApplyToGraph(graph);
            Assert.Equal(0, constructQueryResult.ConstructResultsCount);
        }

        [Fact]
        public void CreateEmptyDescribeQueryTest()
        {
            var describeQuery = new RDFDescribeQuery();
            Assert.NotEqual(0, describeQuery.QueryMemberID);
        }

        [Fact]
        public void CreateDescribeQueryResultTest()
        {
            var describeQuery = new RDFDescribeQuery();
            var describeQueryResult = describeQuery.ApplyToGraph(graph);
            Assert.Equal(0, describeQueryResult.DescribeResultsCount);
        }

        //<--12
        [Fact]
        public void CreateSameTermFilter()
        {
            var filter = new RDFSameTermFilter(x, donaldduck);
            pg1.AddFilter(filter);
            Assert.Contains(filter.ToString(), pg1.ToString());
        }

        [Fact]
        public void CreateLangMatchesFilter()
        {
            var filter = new RDFLangMatchesFilter(n, "it-IT");
            pg1.AddFilter(filter);
            Assert.Contains(filter.ToString(), pg1.ToString());
        }

        [Fact]
        public void CreateComparisonFilter()
        {
            var filter = new RDFComparisonFilter(RDFQueryEnums.RDFComparisonFlavors.LessThan, y, new RDFPlainLiteral("25"));
            pg1.AddFilter(filter);
            Assert.Contains(filter.ToString(), pg1.ToString());
        }

        [Fact]
        public void CreateIsLiteralFilter()
        {
            var filter = new RDFIsLiteralFilter(x);
            pg1.AddFilter(filter);
            Assert.Contains(filter.ToString(), pg1.ToString());
        }

        [Fact]
        public void CreateIsNumericFilter()
        {
            var filter = new RDFIsUriFilter(x);
            pg1.AddFilter(filter);
            Assert.Contains(filter.ToString(), pg1.ToString());
        }

        [Fact]
        public void CreateRegexFilter()
        {
            var filter = new RDFRegexFilter(n, new Regex(@"Mouse", RegexOptions.IgnoreCase));
            pg1.AddFilter(filter);
            Assert.Contains(filter.ToString(), pg1.ToString());
        }

        [Fact]
        public void AddOrderByModifierDescToQueryTest()
        {
            var query = new RDFSelectQuery();
            var modifier = new RDFOrderByModifier(x, RDFQueryEnums.RDFOrderByFlavors.DESC);
            query.AddModifier(modifier);
            //output.WriteLine(query.ToString() + " " + modifier.ToString());
            Assert.Contains($"order by {modifier}".ToUpper(), query.ToString().ToUpper());
        }

        [Fact]
        public void AddOrderByModifierAscToQueryTest()
        {
            var query = new RDFSelectQuery();
            var modifier = new RDFOrderByModifier(n, RDFQueryEnums.RDFOrderByFlavors.ASC);
            query.AddModifier(modifier);
            Assert.Contains($"order by {modifier}".ToUpper(), query.ToString().ToUpper());
        }

        [Fact]
        public void AddDistinctModifierToQueryTest()
        {
            var query = new RDFSelectQuery();
            var modifier = new RDFDistinctModifier();
            query.AddModifier(modifier);
            Assert.Contains("distinct".ToUpper(), query.ToString().ToUpper());
        }

        [Fact]
        public void AddLimitModifierToQueryTest()
        {
            var query = new RDFSelectQuery();
            var modifier = new RDFLimitModifier(100);
            query.AddModifier(modifier);
            Assert.Contains(modifier.ToString(), query.ToString());
        }

        [Fact]
        public void AddOffsetModifierToQueryTest()
        {
            var query = new RDFSelectQuery();
            var modifier = new RDFOffsetModifier(25);
            query.AddModifier(modifier);
            Assert.Contains(modifier.ToString(), query.ToString());
        }

        //<--23

        [Fact]
        public void AddPatternToPatternGroupTest()
        {
            RDFSelectQuery q = new RDFSelectQuery();
            pg1.AddPattern(new RDFPattern(x, RDFVocabulary.FOAF.AGE, new RDFPlainLiteral("85")));
            q.AddPatternGroup(pg1);

            RDFSelectQueryResult selectResult = q.ApplyToGraph(graph);
            output.WriteLine(selectResult.SelectResults.Rows.Count.ToString());
            //output.WriteLine(graph.TriplesCount.ToString());
        }
    }
}