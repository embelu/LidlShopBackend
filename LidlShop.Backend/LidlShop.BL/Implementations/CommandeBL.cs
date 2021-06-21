using LidlShop.BL.Exceptions;
using LidlShop.BL.Interfaces;
using LidlShop.BL.Models;
using LidlShop.Data.Entities;
using LidlShop.Data.Interfaces;
using System;
using System.Collections.Generic;
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

            foreach (var item in commandeDTO.detailCommandeDTOs)
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
    }
}
