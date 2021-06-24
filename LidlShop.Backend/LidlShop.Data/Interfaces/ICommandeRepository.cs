using LidlShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlShop.Data.Interfaces
{
    public interface ICommandeRepository
    {
        int Post(LidlCommandeLb lidlCommandeLb);
        List<LidlCommandeLb> GetAll();
        LidlCommandeLb GetById(int id);
        int Delete(LidlCommandeLb lidlCommandeLbToDelete);
        int Put(LidlCommandeLb lidlCommandeLbToUpdate);
    }
    
}
