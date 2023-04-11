using FraudDetector.Application.Contracts;
using FraudDetector.Application.DTOs.Flag;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FraudDetector.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FraudFlagController : ControllerBase
    {
        protected readonly IFraudFlagService _fraudFlagServie;
        public FraudFlagController(IFraudFlagService fraudFlagService)
        {
            _fraudFlagServie = fraudFlagService;
        }
        // GET: api/<FraudFlagController>
        [HttpGet]
        public async  Task<List<FraudFlagDto>> Get()
        {
            return await _fraudFlagServie.GetAllAsync();
        }

        // GET api/<FraudFlagController>/5
        [HttpGet("{id}")]
        public async Task<FraudFlagDto?> Get(int id)
        {
            return await _fraudFlagServie.GetByIdAsync(id);
        }

        // POST api/<FraudFlagController>
        [HttpPost]
        public async Task<FraudFlagDto> Post([FromBody] FraudFlagDto fraudFlagDto)
        {
           return await _fraudFlagServie.Create(fraudFlagDto);
        }

        // PUT api/<FraudFlagController>/5
        [HttpPut]
        public async Task<FraudFlagDto> Put([FromBody] FraudFlagDto fraudFlagDto)
        {
            return await _fraudFlagServie.Update(fraudFlagDto);
        }

        // DELETE api/<FraudFlagController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _fraudFlagServie.Delete(id);
        }
    }
}
