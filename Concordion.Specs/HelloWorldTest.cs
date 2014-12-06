using System;
using System.Collections.Generic;
using Concordion.Integration;

namespace Concordion.Specs
{
    [ConcordionTest]
    public class HelloWorldTest
    {

        public string GetGreeting()
        {
            return "Hello World!";
        }
    }
}
