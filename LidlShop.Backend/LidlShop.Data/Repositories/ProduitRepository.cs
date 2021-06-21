using LidlShop.Data.Entities;
using LidlShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LidlShop.Data.Repositories
{
    public class ProduitRepository : IProduitRepository
    {
        private readonly DB_FormationContext _context;

        public ProduitRepository(DB_FormationContext context)
        {
            _context = context;
        }

        public int Delete(LidlProduitLb lidlProduitLbtoDelete)
        {
            _context.LidlProduitLbs.Remove(lidlProduitLbtoDelete);
            _context.SaveChanges();
            return lidlProduitLbtoDelete.Id;
        }

        public List<LidlProduitLb> GetAll()
        {
            return _context.LidlProduitLbs.ToList();
        }

        public LidlProduitLb GetById(int id)
        {
            return _context.LidlProduitLbs.Find(id);
        }

        public int Post(LidlProduitLb lidlProduitLb)
        {
            _context.LidlProduitLbs.Add(lidlProduitLb);
            _context.SaveChanges();

            return lidlProduitLb.Id;
        }

        public int Put(LidlProduitLb lidlProduitLbtoUpdate)
        {
            _context.LidlProduitLbs.Update(lidlProduitLbtoUpdate);
            _context.SaveChanges();

            return lidlProduitLbtoUpdate.Id;
        }
    }
}
