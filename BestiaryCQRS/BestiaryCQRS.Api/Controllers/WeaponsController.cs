using System.Threading.Tasks;
using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BestiaryCQRS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeaponsController : ControllerBase
    {
        private readonly IWeaponRepository _repository;
        public WeaponsController(IWeaponRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> PostWeapon(Weapon weapon)
        {
            await _repository.AddAsync(weapon);
            var test = _repository.GetAll();

            return Ok();
        }

    }

}