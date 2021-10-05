using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Symbols.Any())
            {
                context.Symbols.AddRange(
                    new Symbol
                    {
                        OldSymbol = 'а',
                        NewSymbol = 'н'
                    },
                    new Symbol
                    {
                        OldSymbol = 'б',
                        NewSymbol = 'к'
                    },
                    new Symbol
                    {
                        OldSymbol = 'в',
                        NewSymbol = 'ы'
                    });
                context.SaveChanges();
            }
        }
    }
}
