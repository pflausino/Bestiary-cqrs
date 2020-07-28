using System.ComponentModel.DataAnnotations;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Commands
{
    public class CreateWeaponCommand
    {
        [Required]
        public string Name { get; set; }
        [Range(0, 99)]
        public int Strength { get; set; }
        [Range(0, 99)]
        public int Magic { get; set; }
    }
}