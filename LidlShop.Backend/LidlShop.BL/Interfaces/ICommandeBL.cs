using LidlShop.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlShop.BL.Interfaces
{
    public interface ICommandeBL
    {
        int Post(CommandeDTO commandeDTO);
    }
}
