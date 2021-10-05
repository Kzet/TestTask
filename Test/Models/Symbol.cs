using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Symbol
    {
        public long Id { get; set; }
        public char OldSymbol { get; set; }
        public char NewSymbol { get; set; }
    }
}
