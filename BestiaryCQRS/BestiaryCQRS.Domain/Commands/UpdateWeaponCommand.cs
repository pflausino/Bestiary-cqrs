using System;
using System.ComponentModel.DataAnnotations;
using BestiaryCQRS.Domain.Enums;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Commands
{
    public class UpdateWeaponCommand
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Magic { get; set; }
        public RangeEnum RangeType { get; set; }
    }
}