using AutoMapper;
using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.Domain.Entities;

namespace BestiaryCQRS.Api.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Weapon, UpdateWeaponCommand>();
            CreateMap<UpdateWeaponCommand, Weapon>();
        }


    }
}