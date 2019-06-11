using Course01.Course02;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course01.Helpers
{
    public class Verifier
    {

        public void CheckThatAreEqual<T> (string info, T expected, T actual)
        {
            Reporter.LogInfo(info + " | Expected:  '" + string.Format("{0}", expected) + "'  | Actual:  '" + string.Format("{0}", actual));
            try
            {
                Assert.AreEqual(expected, actual);
                Reporter.LogPass("Checker has passed");
            }
            catch (Exception e)
            {
                Reporter.LogFail(info + " - has failed. | Expected:  '" + string.Format("{0}", expected) + "'  | Actual: '" + string.Format("{0}", actual));
            }

        }
    }
}
