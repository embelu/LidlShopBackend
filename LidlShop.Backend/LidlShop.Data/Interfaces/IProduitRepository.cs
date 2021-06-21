using LidlShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlShop.Data.Interfaces
{
    public interface IProduitRepository
    {
        int Post(LidlProduitLb lidlProduitLb);
        LidlProduitLb GetById(int id);
        List<LidlProduitLb> GetAll();
        int Put(LidlProduitLb lidlProduitLbtoUpdate);
        int Delete(LidlProduitLb lidlProduitLbtoDelete);
    }
}
