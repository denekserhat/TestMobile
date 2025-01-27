using Microsoft.AspNetCore.Mvc;

namespace PuffyMate.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPetById()
        {
            // Evcil hayvan bilgisi getir
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPet()
        {
            // Evcil hayvan ekle
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet()
        {
            // Evcil hayvan güncelle
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet()
        {
            // Evcil hayvan sil
            return Ok();
        }
    }
}
