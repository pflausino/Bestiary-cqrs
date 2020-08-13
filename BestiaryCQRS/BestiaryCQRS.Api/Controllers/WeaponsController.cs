using System;
using System.Linq;
using System.Threading.Tasks;
using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.BestiaryCQRS.Domain.Interfaces;
using BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Interfaces;
using BestiaryCQRS.Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BestiaryCQRS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeaponsController : ControllerBase
    {

        private readonly ICreateWeaponHandler createWeaponHandler;
        private readonly IUpdateWeaponHandler updateWeaponHandler;
        private readonly IDeleteWeaponHandler deleteWeaponHandler;
        private readonly IFilterByNameWeaponHandler filterByNameWeaponHandler;
        private readonly IWeaponRepository repository;
        public WeaponsController(
            ICreateWeaponHandler createWeaponHandler,
            IUpdateWeaponHandler updateWeaponHandler,
            IWeaponRepository repository,
            IDeleteWeaponHandler deleteWeaponHandler,
            IFilterByNameWeaponHandler filterByNameWeaponHandler)
        {
            this.createWeaponHandler = createWeaponHandler;
            this.updateWeaponHandler = updateWeaponHandler;
            this.repository = repository;
            this.deleteWeaponHandler = deleteWeaponHandler;
            this.filterByNameWeaponHandler = filterByNameWeaponHandler;
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
            var query = new FilterByNameQuery(name);
            var result = await filterByNameWeaponHandler.Handler(query);

            return Ok(result);
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

        [HttpPatch]
        public async Task<IActionResult> Patch()
        {

            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await this.deleteWeaponHandler.Handle(id);
            return Ok();

        }


    }

}