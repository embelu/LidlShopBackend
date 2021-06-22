using LidlShop.BL.Models;
using LidlShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlShop.BL.Helpers
{
    public static class ProduitExtension
    {
        public static LidlProduitLb FromDTO (this ProduitDTO produitDTO)
        {
            return new LidlProduitLb()
            {
                Id = produitDTO.Id,
                Description = produitDTO.Description,
                Nom = produitDTO.Nom,
                LienImg = produitDTO.LienImg,
                Prix = produitDTO.Prix,
                IdCategorie = produitDTO.IdCategorie
            };
        }

        public static ProduitDTO ToDTO(this LidlProduitLb lidlProduitLb)
        {
            return new ProduitDTO()
            {
                Id = lidlProduitLb.Id,
                Description = lidlProduitLb.Description,
                Nom = lidlProduitLb.Nom,
                LienImg = lidlProduitLb.LienImg,
                Prix = lidlProduitLb.Prix,
                IdCategorie = lidlProduitLb.IdCategorie
            };
        }
    }
}
