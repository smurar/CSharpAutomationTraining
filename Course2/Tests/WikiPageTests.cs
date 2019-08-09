using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Tests
{
    public class WikiPageTests : BaseTest
    {
        [Test]
        public void CheckPageTitleTest()
        {
            GoToWikiPage()
                .CheckWikiTitle(MyResource.WikiTitle);
        }

        [Test]
        public void WriteIntoTextAreTest()
        {
            GoToWikiPage()
                .AddTextToTextArea(MyResource.TextToWrite);
        }

    }
}
