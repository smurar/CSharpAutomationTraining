using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Tests
{
    class WindowsFrameTest:BaseTest
    {
       
        [Test]
        [Category("WorkflowTests")]
        public void WriteDifferentFrameTest()
        {
            GoToHomePageForWindowsAndFramesHandling()
                .ClickWindowsFrameLink()
                .WriteToFrame1TextArea()
                .SwitchToDefaultContent()
                .WriteToFrame2TextArea();
        }
    }
}
