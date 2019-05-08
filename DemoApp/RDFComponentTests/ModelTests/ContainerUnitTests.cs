using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RDFSharp.Model;

namespace DemoApp.RDFComponentTests.ModelTests
{
    public static class ContainerUnitTests
    {
        #region AddTests
        public static AddResourceItemTest()
        {
            var container = new RDFContainer(RDFModelEnums.RDFContainerTypes.Bag, RDFModelEnums.RDFItemTypes.Resource);
            container.AddItem(new RDFResource("http://www.index.hu"));
        }
        #endregion
    }
}
