using System;
using System.ComponentModel.DataAnnotations;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Commands
{
    public class UpdateWeaponCommand
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, 200)]
        public int Strength { get; set; }
        [Range(0, 200)]
        public int Magic { get; set; }
    }
}