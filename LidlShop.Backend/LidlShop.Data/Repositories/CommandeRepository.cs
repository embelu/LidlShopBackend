using LidlShop.Data.Entities;
using LidlShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlShop.Data.Repositories
{
    public class CommandeRepository : ICommandeRepository
    {
        private readonly DB_FormationContext _context;
        public CommandeRepository(DB_FormationContext context)
        {
            _context = context;
        }

        public int Post(LidlCommandeLb lidlCommandeLb)
        {
            _context.LidlCommandeLbs.Add(lidlCommandeLb);
            _context.SaveChanges();
            return lidlCommandeLb.Id;
        }
    }
}
