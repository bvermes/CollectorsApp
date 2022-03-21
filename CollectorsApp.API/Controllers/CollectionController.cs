using CollectorsApp.BLL.Interfaces;
using CollectorsApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollectorsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectibleService _collectibleService;
        public CollectionController(ICollectibleService collectibleService)
        {
            _collectibleService = collectibleService;
        }

        // GET: api/<CollectionController>
        [HttpGet]
        public IEnumerable<Collectible> GetForSale()
        {
            return _collectibleService.GetCollectibles();
        }

        [HttpGet("ForSale")]
        public IEnumerable<Collectible> Get()
        {
            return _collectibleService.GetCollectiblesForSale();
        }

        [HttpGet("{id}")]
        public Collectible Get(int id)
        {
            return _collectibleService.GetCollectible(id);
        }

        // POST api/<CollectionController>
        [HttpPost]
        public void Post([FromBody] Collectible collectible)
        {
            _collectibleService.AddCollectible(collectible);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Collectible collectible)
        {
            _collectibleService.UpdateColletctible(id, collectible);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _collectibleService.DeleteCollectible(id);
        }
    }
}
