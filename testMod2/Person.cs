using System;
using System.Collections.Generic;
using System.Text;

namespace testMod2
{
    class Person:Essential, IEssential
    {
        public Person(string name) : base(name) { }

        public string sayHi()
        {
            return $"Hello I'm real person {Name}";
        }
    }
}
