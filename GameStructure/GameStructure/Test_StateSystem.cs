using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GameStructure
{
    [TestFixture]
    public class Test_StateSystem
    {
        [Test]
        public void TestAddedStateExists()
        {
            StateSystem stateSystem = new StateSystem();
            stateSystem.AddState("splash", new SplashScreenState
            (stateSystem));

            // Does the added function now exist?
            Assert.IsTrue(stateSystem.Exists("splash"));
        }

    }
}