using LidlShop.Data.Entities;
using LidlShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LidlShop.Data.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly DB_FormationContext _context;

        public CategorieRepository(DB_FormationContext context)
        {
            _context = context;
        }

        public int Post(LidlCategorieLb lidlCategorieLb)
        {
            _context.LidlCategorieLbs.Add(lidlCategorieLb);
            _context.SaveChanges();
            return lidlCategorieLb.Id;
        }


        public List<LidlCategorieLb> GetAll()
        {
            return _context.LidlCategorieLbs.ToList();
        }


        public LidlCategorieLb GetById(int id)
        {
            return _context.LidlCategorieLbs.Find(id);
        }


        public int Put(LidlCategorieLb lidlCategorieLbtoUpdate)
        {
            _context.LidlCategorieLbs.Update(lidlCategorieLbtoUpdate);
            _context.SaveChanges();

            return lidlCategorieLbtoUpdate.Id;
        }


        public int Delete(LidlCategorieLb lidlCategorieLb)
        {
            _context.LidlCategorieLbs.Remove(lidlCategorieLb);
            _context.SaveChanges();
            return lidlCategorieLb.Id;
        }
    }
}
