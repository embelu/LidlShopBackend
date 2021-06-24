using LidlShop.Data.Entities;
using LidlShop.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public int Delete(LidlCommandeLb lidlCommandeLbToDelete)
        {
            foreach (var item in lidlCommandeLbToDelete.LidlDetailCommandeLbs)
            {
                _context.LidlDetailCommandeLbs.Remove(item);
            }

            _context.LidlCommandeLbs.Remove(lidlCommandeLbToDelete);
            _context.SaveChanges();
            return lidlCommandeLbToDelete.Id;
        }

        public List<LidlCommandeLb> GetAll()
        {
            return _context.LidlCommandeLbs.Include(c => c.LidlDetailCommandeLbs).ThenInclude(d => d.IdProduitNavigation).ToList();
        }

        public LidlCommandeLb GetById(int id)
        {
            return _context.LidlCommandeLbs.Where(c => c.Id == id).Include(c => c.LidlDetailCommandeLbs).ThenInclude(d => d.IdProduitNavigation).Single();
        }

        public int Post(LidlCommandeLb lidlCommandeLb)
        {
            _context.LidlCommandeLbs.Add(lidlCommandeLb);
            _context.SaveChanges();
            return lidlCommandeLb.Id;
        }

       


        public int Put(LidlCommandeLb lidlCommandeUpdated)
        {

            LidlCommandeLb lidlCommandeLbToUpdate = GetById(lidlCommandeUpdated.Id);

            //DETAILS A AJOUTER
            List<LidlDetailCommandeLb> lidlDetailCommandeLbsToCreate = lidlCommandeUpdated.LidlDetailCommandeLbs.Where(c => c.Id == 0).ToList();
            foreach (var item in lidlDetailCommandeLbsToCreate)
            {
                _context.LidlDetailCommandeLbs.Add(item);
                _context.SaveChanges();
            }

            // DETAILS A SUPPRIMER
            List<LidlDetailCommandeLb> lidlDetailCommandeLbsToDelete = lidlCommandeLbToUpdate.LidlDetailCommandeLbs.Where(dc => !lidlCommandeUpdated.LidlDetailCommandeLbs.Any(d => dc.Id == d.Id)).ToList();
            foreach (var item in lidlDetailCommandeLbsToDelete)
            {
                _context.LidlDetailCommandeLbs.Remove(item);
                _context.SaveChanges();
            }



            // DETAILS A MODIFIER
            List<LidlDetailCommandeLb> lidlDetailCommandeLbsToUpdate = lidlCommandeLbToUpdate.LidlDetailCommandeLbs.Where(dc => lidlCommandeUpdated.LidlDetailCommandeLbs.Any(d => dc.Id == d.Id)).ToList();


            foreach (var item in lidlDetailCommandeLbsToUpdate)
            {
                var x = lidlCommandeUpdated.LidlDetailCommandeLbs.First(x => x.Id == item.Id);

                item.Quantite = x.Quantite;

                _context.LidlDetailCommandeLbs.Update(item);
                _context.SaveChanges();
            }



            

            return lidlCommandeUpdated.Id;



        }
    }
}
