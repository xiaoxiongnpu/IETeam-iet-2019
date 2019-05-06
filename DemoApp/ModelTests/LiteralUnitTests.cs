using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDFSharp.Model;
using Xunit;

namespace DemoApp.ModelTests
{
    public class LiteralUnitTests
    {

        [Fact]
        public void CreatingPlainLiteralWithValidValueTest()
        {
            //Egyszerű literális "normális" alapértékkel
            var plainLiteral = new RDFPlainLiteral("VIK");
            Assert.Equal("VIK", plainLiteral.Value);
        }
        [Fact]
        public void CreatingPlainLiteralWithoutValueTest()
        {
            //Egyszerű literális null alapértékkel
            var plainLiteral = new RDFPlainLiteral(null);
            Assert.Equal("", plainLiteral.Value);
        }

        [Fact]
        public void CreatingPlainLiteralWithoutLanguageTest()
        {
            //Egyszerű literális nyelv érték hozzáadás nélkül
            var plainLiteral = new RDFPlainLiteral("C'est la vie!");
            Assert.Equal("", plainLiteral.Language);
        }

        [Fact]
        public void CreatingPlainLiteralWithLanguageTest()
        {
            //Egyszerű literális rendes nyelvi értékkel
            var plainLiteral = new RDFPlainLiteral("C'est la vie!", "FR");
            Assert.Equal("C'est la vie!@FR", plainLiteral.ToString());
        }

        [Fact]
        public void CreatingPlainLiteralWithWrongLanguageTest()
        {
            //Egyszerű literális rossz nyelvi értékkel
            var plainLiteral = new RDFPlainLiteral("C'est la vie!", "WhatThePepperoni");
            Assert.Equal("", plainLiteral.Language);
        }
    }
}
