using LidlShop.BL.Exceptions;
using LidlShop.BL.Interfaces;
using LidlShop.BL.Models;
using LidlShop.Data.Entities;
using LidlShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlShop.BL.Implementations
{
    public class CategorieBL : ICategorieBL
    {
        private readonly ICategorieRepository _categorieRepository;
        public CategorieBL(ICategorieRepository categorieRepository)
        {
            _categorieRepository = categorieRepository;
        }


        public int Post(CategorieDTO categorieDTO)
        {
            LidlCategorieLb lidlCategorieLb = new LidlCategorieLb();
            lidlCategorieLb.Nom = categorieDTO.Nom;
            lidlCategorieLb.Description = categorieDTO.Description;
            lidlCategorieLb.LienImg = categorieDTO.LienImg;

            return _categorieRepository.Post(lidlCategorieLb);
        }


        public List<CategorieDTO> GetAll()
        {
            List<LidlCategorieLb> lidlCategorieLBs = _categorieRepository.GetAll();

            if (lidlCategorieLBs.Count == 0)
            {
                throw new NotFoundException("Pas de catégories présentes en DB");
            }

            List<CategorieDTO> categorieDTOs = new List<CategorieDTO>();

            foreach (var item in lidlCategorieLBs)
            {
                categorieDTOs.Add(new CategorieDTO() {Id = item.Id, Nom = item.Nom, Description = item.Description, LienImg = item.LienImg });
            }

            return categorieDTOs;
        }


        public CategorieDTO GetById(int id)
        {
            LidlCategorieLb lidlCategorieLb = _categorieRepository.GetById(id);

            if (lidlCategorieLb == null)
            {
                throw new NotFoundException($"Categorie inexistante :  {id} !");
            }

            return new CategorieDTO()
            {
                Id = lidlCategorieLb.Id,
                Nom = lidlCategorieLb.Nom,
                Description = lidlCategorieLb.Description,
                LienImg = lidlCategorieLb.LienImg
            };
        }


        public int Put(CategorieDTO categorieDTO)
        {
            var lidlCategorieLbtoUpdate = _categorieRepository.GetById(categorieDTO.Id);

            lidlCategorieLbtoUpdate.Nom = categorieDTO.Nom;
            lidlCategorieLbtoUpdate.Description = categorieDTO.Description;
            lidlCategorieLbtoUpdate.LienImg = categorieDTO.LienImg;

            return _categorieRepository.Put(lidlCategorieLbtoUpdate);
        }


        public int Delete(int id)
        {
           var lidlCategorieLbtoDelete = _categorieRepository.GetById(id);
           return _categorieRepository.Delete(lidlCategorieLbtoDelete);
        }
    }
}
