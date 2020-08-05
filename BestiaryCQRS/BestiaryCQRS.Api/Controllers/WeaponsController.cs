using System;
using System.Linq;
using System.Threading.Tasks;
using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.BestiaryCQRS.Domain.Interfaces;
using BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BestiaryCQRS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeaponsController : ControllerBase
    {

        private readonly ICreateWeaponHandler createWeaponHandler;
        //private readonly IUpdateWeaponHandler updateWeaponHandler;
        public WeaponsController(ICreateWeaponHandler createWeaponHandler)
        {
            this.createWeaponHandler = createWeaponHandler;
        }

        [HttpPost]
        public async Task<IActionResult> PostWeapon(CreateWeaponCommand createWeaponCommand)
        {
            createWeaponCommand.Validate(createWeaponCommand, new CreateWeaponCommandValidator());

            if (createWeaponCommand.Invalid)
                return BadRequest(createWeaponCommand.ValidationResult);

            var response = await this.createWeaponHandler.Handle(createWeaponCommand);

            return Ok(response);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutWeapon(Guid id, UpdateWeaponCommand updateWeaponCommand)
        //{

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var response = await this.

        //}

    }

}