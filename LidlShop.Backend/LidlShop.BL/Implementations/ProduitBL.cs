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
    public class ProduitBL : IProduitBL
    {
        private readonly IProduitRepository _produitRepository;

        public ProduitBL(IProduitRepository produitRepository)
        {
            _produitRepository = produitRepository;
        }


        public int Post(ProduitDTO produitDTO)
        {
            LidlProduitLb lidlProduitLb = new LidlProduitLb();

            lidlProduitLb.Description = produitDTO.Description;
            lidlProduitLb.IdCategorie = produitDTO.IdCategorie;
            lidlProduitLb.Nom = produitDTO.Nom;
            lidlProduitLb.Prix = produitDTO.Prix;
            lidlProduitLb.LienImg = produitDTO.LienImg;

            return _produitRepository.Post(lidlProduitLb);
        }

        public ProduitDTO GetById(int id)
        {
            LidlProduitLb lidlProduitLb = _produitRepository.GetById(id);

            if (lidlProduitLb == null)
            {
                throw new NotFoundException($"Produit inexistant :  {id} !");
            }

            return new ProduitDTO()
            {
                Id = lidlProduitLb.Id,
                Nom = lidlProduitLb.Nom,
                Description = lidlProduitLb.Description,
                Prix = lidlProduitLb.Prix,
                LienImg = lidlProduitLb.LienImg,
                IdCategorie = lidlProduitLb.IdCategorie,
            };
        }

        public List<ProduitDTO> GetAll()
        {
            List<LidlProduitLb> lidlProduitLBs = _produitRepository.GetAll();

            if (lidlProduitLBs.Count == 0)
            {
                throw new NotFoundException("Pas de produits présents en DB");
            }

            List<ProduitDTO> produitDTOs = new List<ProduitDTO>();

            foreach (var item in lidlProduitLBs)
            {
                produitDTOs.Add(new ProduitDTO() 
                {   
                    Id = item.Id,
                    Nom = item.Nom,
                    Description = item.Description,
                    Prix = item.Prix,
                    LienImg = item.LienImg,
                    IdCategorie = item.IdCategorie
                });
            }

            return produitDTOs;
        }


        public int Put(ProduitDTO produitDTO)
        {
            var lidlProduitLbtoUpdate = _produitRepository.GetById(produitDTO.Id);

            lidlProduitLbtoUpdate.Nom = produitDTO.Nom;
            lidlProduitLbtoUpdate.Description = produitDTO.Description;
            lidlProduitLbtoUpdate.LienImg = produitDTO.LienImg;
            lidlProduitLbtoUpdate.Prix = produitDTO.Prix;
            lidlProduitLbtoUpdate.IdCategorie = produitDTO.IdCategorie;  

            return _produitRepository.Put(lidlProduitLbtoUpdate);
        }

        public int Delete(int id)
        {
            var lidlProduitLbtoDelete = _produitRepository.GetById(id);
            return _produitRepository.Delete(lidlProduitLbtoDelete);
        }
    }
}
