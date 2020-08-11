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
        private readonly IUpdateWeaponHandler updateWeaponHandler;
        private readonly IWeaponRepository repository;
        public WeaponsController(ICreateWeaponHandler createWeaponHandler, IUpdateWeaponHandler updateWeaponHandler, IWeaponRepository repository)
        {
            this.createWeaponHandler = createWeaponHandler;
            this.updateWeaponHandler = updateWeaponHandler;
            this.repository = repository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await this.repository.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Filter([FromQuery] string name)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> PostWeapon(CreateWeaponCommand createWeaponCommand)
        {
            var response = await this.createWeaponHandler.Handle(createWeaponCommand);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeapon(
            [FromRoute] Guid id,
            [FromBody] UpdateWeaponCommand updateWeaponCommand)
        {

            var response = await this.updateWeaponHandler.Handle(id, updateWeaponCommand);

            return Ok(response);

        }
        [HttpDelete]
        [Route("id")]
        public Task<IActionResult> Delete([FromRoute] Guid id)
        {

            throw new NotImplementedException();
        }


    }

}