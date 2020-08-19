using BestiaryCQRS.Domain.Core.Commands;
using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Commands
{
    public class CreateWeaponCommand : Command
    {

        public string Name { get; set; }
        public int Strength { get; set; }
        public int Magic { get; set; }
        public RangeEnum RangeType { get; set; }


    }
}