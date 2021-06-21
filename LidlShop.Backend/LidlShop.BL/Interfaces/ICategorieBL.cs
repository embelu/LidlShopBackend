using LidlShop.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlShop.BL.Interfaces
{
    public interface ICategorieBL
    {
        int Post(CategorieDTO categorieDTO);
        List<CategorieDTO> GetAll();
        CategorieDTO GetById(int id);
        int Put(CategorieDTO categorieDTO);
        int Delete(int id);
    }
}
