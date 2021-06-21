using AutoMapper;
using LidlShop.BL.Exceptions;
using LidlShop.BL.Interfaces;
using LidlShop.BL.Models;
using LidlShop.Data.Entities;
using LidlShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LidlShop.BL.Implementations
{
    public class CategorieBL : ICategorieBL
    {
        private readonly ICategorieRepository _categorieRepository;
        private MapperConfiguration configToEntities;
        private MapperConfiguration configToDTO;
        private MapperConfiguration configToDTOBis;

        public CategorieBL(ICategorieRepository categorieRepository)
        {
            _categorieRepository = categorieRepository;

            configToEntities = new MapperConfiguration(cfg => cfg.CreateMap<CategorieDTO, LidlCategorieLb>());
            configToDTO = new MapperConfiguration(cfg => cfg.CreateMap<LidlCategorieLb, CategorieDTO>());
            // Exemple de mappage de propriétés explicites (ici peut de sens car les propriétés portent le même nom
            // mais c'est simplement pour connaitre la synthaxe.
            configToDTOBis = new MapperConfiguration(cfg => cfg.CreateMap<LidlCategorieLb, CategorieDTO>()
            .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description)));
        }


        public int Post(CategorieDTO categorieDTO)
        {
            var mapper = new Mapper(configToEntities);
            LidlCategorieLb lidlCategorieLb = mapper.Map<LidlCategorieLb>(categorieDTO);

            // REMPLACE PAR L'AUTOMAPPER
            //LidlCategorieLb lidlCategorieLb = new LidlCategorieLb();
            //lidlCategorieLb.Nom = categorieDTO.Nom;
            //lidlCategorieLb.Description = categorieDTO.Description;
            //lidlCategorieLb.LienImg = categorieDTO.LienImg;

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
            var mapper = new Mapper(configToDTOBis);
            categorieDTOs = lidlCategorieLBs.Select(lidlCat => mapper.Map<CategorieDTO>(lidlCat)).ToList();

            // REMPLACE PAR L'AUTOMAPPER
            //foreach (var item in lidlCategorieLBs)
            //{
            //    categorieDTOs.Add(new CategorieDTO() { Id = item.Id, Nom = item.Nom, Description = item.Description, LienImg = item.LienImg });

            //}


            return categorieDTOs;

  

  
        }


        public CategorieDTO GetById(int id)
        {
            LidlCategorieLb lidlCategorieLb = _categorieRepository.GetById(id);

            if (lidlCategorieLb == null)
            {
                throw new NotFoundException($"Categorie inexistante :  {id} !");
            }

            var mapper = new Mapper(configToDTO);
            return  mapper.Map<CategorieDTO>(lidlCategorieLb);

            // REMPLACE PAR L'AUTOMAPPER
            //return new CategorieDTO()
            //{
            //    Id = lidlCategorieLb.Id,
            //    Nom = lidlCategorieLb.Nom,
            //    Description = lidlCategorieLb.Description,
            //    LienImg = lidlCategorieLb.LienImg
            //};
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
