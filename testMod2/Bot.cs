using System;
using System.Collections.Generic;
using System.Text;

namespace testMod2
{
    class Bot:Essential, IEssential
    {
        public Bot(string name):base(name) { }

        public string sayHi()
        {
            return $"Hello I'm not real person, I am bot - {Name}";
        }
    }
}
