using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class EFRepository : IRepository
    {
        private ApplicationDbContext context;

        public EFRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Symbol> Symbols => context.Symbols;

        public IQueryable<Message> Messages => context.Messages;

        public void SaveMessage(Message message)
        {
            if(message.OldMessage != null)
            {
                context.Messages.Add(message);
            }
            context.SaveChanges();
        }

        public void DeleteMessagesOnDb()
        {
            var messages = context.Messages;
            foreach(var mes in messages)
            {
                context.Messages.Remove(mes);
            }
        }

        public Dictionary<char, char> GetSymbolsfromDb()
        {
            Dictionary<char, char> dictSymb = new Dictionary<char, char>();
            foreach (Symbol sym in context.Symbols)
            {
                dictSymb.Add(sym.OldSymbol, sym.NewSymbol);
            }
            return dictSymb;
        }
    }
}
