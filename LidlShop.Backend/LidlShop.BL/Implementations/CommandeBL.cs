using LidlShop.BL.Exceptions;
using LidlShop.BL.Interfaces;
using LidlShop.BL.Models;
using LidlShop.Data.Entities;
using LidlShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LidlShop.BL.Implementations
{
    public class CommandeBL : ICommandeBL
    {
        private readonly ICommandeRepository _commandeRepository;

        public CommandeBL(ICommandeRepository commandeRepository)
        {
            _commandeRepository = commandeRepository;
        }


        public int Post(CommandeDTO commandeDTO)
        {

            if (commandeDTO.Statut != "En cours" && commandeDTO.Statut != "Clôturée" && commandeDTO.Statut != "Annulée")
            {
                throw new CommandeException($"Statut incorrect (\"En cours\", \"Clôturée\", \"Annulée\" accepté)");
            }

            LidlCommandeLb lidlCommandeLb = new LidlCommandeLb();

            lidlCommandeLb.Date = commandeDTO.Date;
            lidlCommandeLb.Statut = commandeDTO.Statut;
            lidlCommandeLb.LidlDetailCommandeLbs = new List<LidlDetailCommandeLb>();

            foreach (var item in commandeDTO.DetailCommandeDTOs)
            {
                if (item.Quantite == 0)
                {
                    throw new CommandeException($"Quantité absente pour le produit {item.IdProduit}");
                }

                lidlCommandeLb.LidlDetailCommandeLbs.Add(new LidlDetailCommandeLb() 
                {IdProduit = item.IdProduit, Quantite = item.Quantite });
            }

            return _commandeRepository.Post(lidlCommandeLb);
        }

        public List<CommandeDTO> GetAll()
        {
            List<LidlCommandeLb> lidlCommandeLbs = _commandeRepository.GetAll();

            List<CommandeDTO> commandeDTOs = new List<CommandeDTO>();
            

            foreach (var item in lidlCommandeLbs)
            {
                List<DetailCommandeDTO> detailCommandeDTOs = new List<DetailCommandeDTO>();

                foreach (var itemDetail in item.LidlDetailCommandeLbs)
                {
                    detailCommandeDTOs.Add(new DetailCommandeDTO() {Id = itemDetail.Id, IdCommande = itemDetail.IdCommande, IdProduit = itemDetail.IdProduit, Quantite = itemDetail.Quantite, 
                        Produit = new ProduitDTO() {Id = itemDetail.IdProduitNavigation.Id,
                                                    Description = itemDetail.IdProduitNavigation.Description,
                                                    Nom = itemDetail.IdProduitNavigation.Nom,
                                                    IdCategorie = itemDetail.IdProduitNavigation.IdCategorie,
                                                    LienImg = itemDetail.IdProduitNavigation.LienImg,
                                                    Prix = itemDetail.IdProduitNavigation.Prix  
                        } });
                }

                commandeDTOs.Add(new CommandeDTO() {Id = item.Id, Date = item.Date, Statut = item.Statut, DetailCommandeDTOs = detailCommandeDTOs});
            }

            return commandeDTOs;
        }

        public CommandeDTO GetById(int id)
        {
            LidlCommandeLb lidlCommandeLbs = _commandeRepository.GetById(id);

            List<DetailCommandeDTO> detailCommandeDTOs = new List<DetailCommandeDTO>();

            foreach (var item in lidlCommandeLbs.LidlDetailCommandeLbs)
            {
                detailCommandeDTOs.Add(new DetailCommandeDTO()
                {
                    Id = item.Id,
                    IdCommande = item.IdCommande,
                    IdProduit = item.IdProduit,
                    Quantite = item.Quantite,
                    Produit = new ProduitDTO()
                    {
                        Id = item.IdProduitNavigation.Id,
                        Description = item.IdProduitNavigation.Description,
                        Nom = item.IdProduitNavigation.Nom,
                        IdCategorie = item.IdProduitNavigation.IdCategorie,
                        LienImg = item.IdProduitNavigation.LienImg,
                        Prix = item.IdProduitNavigation.Prix
                    }
                });
            }

            CommandeDTO commandeDTO = new CommandeDTO() { Id = lidlCommandeLbs.Id, Date = lidlCommandeLbs.Date, Statut = lidlCommandeLbs.Statut, DetailCommandeDTOs = detailCommandeDTOs };

            return commandeDTO;
        }

        public int Delete(int id)
        {
           var LidlCommandeLbToDelete = _commandeRepository.GetById(id);

           return _commandeRepository.Delete(LidlCommandeLbToDelete);

        }


        public int Put(CommandeDTO commandeDTOUpdated)
        {
            // TRANSFORMATION CommandeDTO en LidlCommandeLb.
            LidlCommandeLb lidlCommandeLbToUpdate = new LidlCommandeLb();
            lidlCommandeLbToUpdate.Id = commandeDTOUpdated.Id;
            lidlCommandeLbToUpdate.Date = commandeDTOUpdated.Date;
            lidlCommandeLbToUpdate.Statut = commandeDTOUpdated.Statut;

            foreach (var item in commandeDTOUpdated.DetailCommandeDTOs)
            {
                lidlCommandeLbToUpdate.LidlDetailCommandeLbs.Add(new LidlDetailCommandeLb() 
                {Id = item.Id, IdCommande= item.IdCommande, IdProduit = item.IdProduit, Quantite = item.Quantite});
            }

 


            return _commandeRepository.Put(lidlCommandeLbToUpdate);
        }
    }
}
