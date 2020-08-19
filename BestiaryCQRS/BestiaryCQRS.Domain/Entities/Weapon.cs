using System;
using BestiaryCQRS.Domain.Core.Entities;
using BestiaryCQRS.Domain.Enums;
using Microsoft.AspNetCore.JsonPatch;

namespace BestiaryCQRS.Domain.Entities
{
    public class Weapon : Entity
    {
        public Weapon()
        {

        }
        public Weapon(string name, int strength, int magic, RangeEnum rangeType)
        {
            Name = name;
            Strength = strength;
            Magic = magic;
            RangeType = rangeType;

            Validate(this, new WeaponValidator());
        }
        public virtual string Name { get; protected set; }
        public virtual int Strength { get; protected set; }
        public virtual int Magic { get; protected set; }

        public virtual RangeEnum RangeType { get; protected set; }
        public virtual void UpdateWeapon(string name, int magic, int strength, RangeEnum rangeType)
        {
            Name = name;
            Magic = magic;
            Strength = strength;
            RangeType = rangeType;

            Validate(this, new WeaponValidator());
        }
        public virtual void PatchWeapon(JsonPatchDocument<Weapon> jsonPatch)
        {

            jsonPatch.ApplyTo(this);

            Validate(this, new WeaponValidator());

        }

    }

}