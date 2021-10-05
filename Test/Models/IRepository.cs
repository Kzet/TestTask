using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public interface IRepository
    {
        IQueryable<Symbol> Symbols { get; }
        IQueryable<Message> Messages { get; }

        public void SaveMessage(Message message);
        public Dictionary<char, char> GetSymbolsfromDb();
    }
}
