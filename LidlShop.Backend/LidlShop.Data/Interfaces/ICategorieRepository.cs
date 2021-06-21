using LidlShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlShop.Data.Interfaces
{
    public interface ICategorieRepository
    {
        int Post(LidlCategorieLb lidlCategorieLb);
        List<LidlCategorieLb> GetAll();
        LidlCategorieLb GetById(int id);
        int Put(LidlCategorieLb lidlCategorieLbtoUpdate);
        int Delete(LidlCategorieLb lidlCategorieLb);
    }
}
