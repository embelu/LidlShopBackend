using LidlShop.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlShop.BL.Interfaces
{
    public interface IProduitBL
    {
        int Post(ProduitDTO produitDTO);
        ProduitDTO GetById(int id);
        List<ProduitDTO> GetAll();
        int Put(ProduitDTO produitDTO);
        int Delete(int id);

    }
}
